//using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.DataClasses;
using System;

namespace RvuPiecemaker.Entities.Context
{
  public partial class RvuPiecemakerContext
  {
    public virtual DbSet<DoctorType> DoctorType { get; set; }
    public virtual DbSet<Modality> Modality { get; set; }
    public virtual DbSet<Year> Year { get; set; }
    public void OnModelCreating_Lookup(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<DoctorType>(entity =>
      {
        entity.ToTable("DoctorType", "Lookup");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasData(
          new DataClasses.DoctorType { Id = 1, Name = "Radiologist", Sort = 1, IsActive = true }
        );
      });

      modelBuilder.Entity<Modality>(entity =>
      {
        entity.ToTable("Modality", "Lookup");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasData(
          new Modality { Id = 1, Name = "CR", Sort = 1, IsActive = true },
          new Modality { Id = 2, Name = "CT", Sort = 2, IsActive = true },
          new Modality { Id = 3, Name = "MG", Sort = 3, IsActive = true },
          new Modality { Id = 4, Name = "MR", Sort = 4, IsActive = true },
          new Modality { Id = 5, Name = "NM", Sort = 5, IsActive = true },
          new Modality { Id = 6, Name = "US", Sort = 6, IsActive = true },
          new Modality { Id = 7, Name = "OT", Sort = 7, IsActive = true },
          new Modality { Id = 8, Name = "PT", Sort = 8, IsActive = true }
        );
      });

      modelBuilder.Entity<Year>(entity =>
      {
        entity.ToTable("Year", "Lookup");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasOne(d => d.YearType)
            .WithMany(p => p.Years)
            .HasForeignKey(d => d.YearTypeId)
            .HasConstraintName("FK_Year_YearType");

        entity.HasData(
          new DataClasses.Year { Id = 1, Name = "2019", Sort = 1, IsActive = true, YearTypeId = 1, StartDate = new DateTime(2019, 1, 1), EndDate = new DateTime(2019, 12, 31) },
          new DataClasses.Year { Id = 2, Name = "2020", Sort = 2, IsActive = true, YearTypeId = 1, StartDate = new DateTime(2020, 1, 1), EndDate = new DateTime(2020, 12, 31) }
        );
      });

      modelBuilder.Entity<YearType>(entity =>
      {
        entity.ToTable("YearType", "Lookup");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.HasData(
          new DataClasses.Year { Id = 1, Name = "Calendar Year", Sort = 1, IsActive = true },
          new DataClasses.Year { Id = 2, Name = "Fiscal Year", Sort = 2, IsActive = true },
          new DataClasses.Year { Id = 3, Name = "School Year", Sort = 3, IsActive = true }
        );
      });
    }
  }
}
