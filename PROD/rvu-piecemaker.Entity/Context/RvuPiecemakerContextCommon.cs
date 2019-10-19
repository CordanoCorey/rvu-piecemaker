// using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.DataClasses;
using System;

namespace RvuPiecemaker.Entities.Context
{
  public partial class RvuPiecemakerContext
  {
    public virtual DbSet<Exam> Exam { get; set; }
    public virtual DbSet<ExamTagXref> ExamTag { get; set; }
    public virtual DbSet<ExamType> ExamType { get; set; }
    public virtual DbSet<Goal> Goal { get; set; }
    public virtual DbSet<Service> Service { get; set; }
    public virtual DbSet<ServiceExamTypeXref> ServiceExamType { get; set; }
    public virtual DbSet<Shift> Shift { get; set; }
    public virtual DbSet<ShiftServiceXref> ShiftService { get; set; }
    public virtual DbSet<ShiftType> ShiftType { get; set; }
    public virtual DbSet<Tag> Tag { get; set; }
    public virtual DbSet<UserShiftTypeXref> UserShiftType { get; set; }
    public void OnModelCreating_Common(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Exam>(entity =>
      {
        entity.ToTable("Exam", "Common");

        entity.Property(e => e.Notes).HasMaxLength(200);

        entity.HasOne(d => d.ExamType)
            .WithMany(p => p.Exams)
            .HasForeignKey(d => d.ExamTypeId)
            .HasConstraintName("FK_Exam_ExamType");

        entity.HasOne(d => d.Service)
            .WithMany(p => p.Exams)
            .HasForeignKey(d => d.ServiceId)
            .HasConstraintName("FK_Exam_Service");

        entity.HasOne(d => d.Shift)
            .WithMany(p => p.Exams)
            .HasForeignKey(d => d.ShiftId)
            .HasConstraintName("FK_Exam_Shift");

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.ExamCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Exam_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.ExamLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Exam_LastModifiedByUser");

      });

      modelBuilder.Entity<ExamTagXref>(entity =>
      {
        entity.ToTable("ExamTag_xref", "Common");

        entity.HasOne(d => d.ExamType)
            .WithMany(p => p.ExamTagXref)
            .HasForeignKey(d => d.ExamTypeId)
            .HasConstraintName("FK_ExamTag_xref_ExamType");

        entity.HasOne(d => d.Tag)
            .WithMany(p => p.ExamTagXref)
            .HasForeignKey(d => d.TagId)
            .HasConstraintName("FK_ExamTag_xref_Tag");

        //entity.HasData(
        //  new ExamTagXref
        //  {
        //    Id = 1,
        //    ExamTypeId = 1,
        //    TagId = 1
        //  }
        //);
      });

      modelBuilder.Entity<ExamType>(entity =>
      {
        entity.ToTable("ExamType", "Common");

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Description).HasMaxLength(200);

        entity.Property(e => e.CptCode).HasMaxLength(20);

        entity.HasOne(d => d.Modality)
            .WithMany(p => p.ExamTypes)
            .HasForeignKey(d => d.ModalityId)
            .HasConstraintName("FK_ExamType_Modality");

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.ExamTypeCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ExamType_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.ExamTypeLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_ExamType_LastModifiedByUser");

        entity.HasData(
           new ExamType
           {
             Id = 1,
             Name = "CT Chest W/O",
             Description = "",
             RvuTotal = 1.16m,
             ModalityId = 2,
             CptCode = "71250",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 2,
             Name = "CT Chest W",
             Description = "",
             RvuTotal = 1.24m,
             ModalityId = 2,
             CptCode = "71260",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 3,
             Name = "CT Brain WO",
             Description = "",
             RvuTotal = 0.85m,
             ModalityId = 2,
             CptCode = "70450",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 4,
             Name = "CT Brain W/WO",
             Description = "",
             RvuTotal = 1.27m,
             ModalityId = 2,
             CptCode = "70470",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 5,
             Name = "CT Orbit/Sella WO",
             Description = "",
             RvuTotal = 1.28m,
             ModalityId = 2,
             CptCode = "70480",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 6,
             Name = "CT Maxillofacial WO",
             Description = "",
             RvuTotal = 0.85m,
             ModalityId = 2,
             CptCode = "70486",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 7,
             Name = "CT Maxillofacial W",
             Description = "",
             RvuTotal = 1.13m,
             ModalityId = 2,
             CptCode = "70487",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 8,
             Name = "CT Neck W",
             Description = "",
             RvuTotal = 1.38m,
             ModalityId = 2,
             CptCode = "70491",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 9,
             Name = "CTA Head W/WO",
             Description = "",
             RvuTotal = 1.75m,
             ModalityId = 2,
             CptCode = "70496",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 10,
             Name = "CTA Neck W/WO",
             Description = "",
             RvuTotal = 1.75m,
             ModalityId = 2,
             CptCode = "70498",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 11,
             Name = "CT Chest W/WO",
             Description = "",
             RvuTotal = 1.38m,
             ModalityId = 2,
             CptCode = "71270",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 12,
             Name = "CTA Chest W/WO",
             Description = "",
             RvuTotal = 1.82m,
             ModalityId = 2,
             CptCode = "71275",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 13,
             Name = "CT Cervical Spine WO",
             Description = "",
             RvuTotal = 1.07m,
             ModalityId = 2,
             CptCode = "72125",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 14,
             Name = "CT Cervical Spine W",
             Description = "",
             RvuTotal = 1.22m,
             ModalityId = 2,
             CptCode = "72125",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 15,
             Name = "CT Thoracic Spine WO",
             Description = "",
             RvuTotal = 1.0m,
             ModalityId = 2,
             CptCode = "72128",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 16,
             Name = "CT Thoracic Spine W",
             Description = "",
             RvuTotal = 1.22m,
             ModalityId = 2,
             CptCode = "72129",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 17,
             Name = "CT Lumbar Spine WO",
             Description = "",
             RvuTotal = 1.0m,
             ModalityId = 2,
             CptCode = "72131",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 18,
             Name = "CT Lumbar Spine W",
             Description = "",
             RvuTotal = 1.22m,
             ModalityId = 2,
             CptCode = "72132",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 19,
             Name = "CT Pelvis WO",
             Description = "",
             RvuTotal = 1.09m,
             ModalityId = 2,
             CptCode = "721392",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 20,
             Name = "CT Pelvis W",
             Description = "",
             RvuTotal = 1.16m,
             ModalityId = 2,
             CptCode = "72193",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 21,
             Name = "CT Upper Extremity WO",
             Description = "",
             RvuTotal = 1.0m,
             ModalityId = 2,
             CptCode = "73200",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 22,
             Name = "CTA Upper Extremity W/WO",
             Description = "",
             RvuTotal = 1.81m,
             ModalityId = 2,
             CptCode = "73206",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 23,
             Name = "CT Lower Extremity WO",
             Description = "",
             RvuTotal = 1.0m,
             ModalityId = 2,
             CptCode = "73700",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 24,
             Name = "CT Lower Extremity W",
             Description = "",
             RvuTotal = 1.16m,
             ModalityId = 2,
             CptCode = "73701",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 25,
             Name = "CT Lower Extremity W/WO",
             Description = "",
             RvuTotal = 1.9m,
             ModalityId = 2,
             CptCode = "73706",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 26,
             Name = "CT Abdomen WO",
             Description = "",
             RvuTotal = 1.19m,
             ModalityId = 2,
             CptCode = "74150",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 27,
             Name = "CT Abdomen W",
             Description = "",
             RvuTotal = 1.27m,
             ModalityId = 2,
             CptCode = "74160",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 28,
             Name = "CT Abdomen W/WO",
             Description = "",
             RvuTotal = 1.40m,
             ModalityId = 2,
             CptCode = "74170",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 29,
             Name = "CTA Abdomen/Pelvis W/WO",
             Description = "",
             RvuTotal = 2.20m,
             ModalityId = 2,
             CptCode = "74174",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 30,
             Name = "CTA Abdomen W/WO",
             Description = "",
             RvuTotal = 1.82m,
             ModalityId = 2,
             CptCode = "74175",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 31,
             Name = "CT Abdomen/Pelvis WO",
             Description = "",
             RvuTotal = 1.74m,
             ModalityId = 2,
             CptCode = "74146",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 32,
             Name = "CT Abdomen/Pelvis W",
             Description = "",
             RvuTotal = 1.82m,
             ModalityId = 2,
             CptCode = "74177",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 33,
             Name = "CT Abdomen/Pelvis W/WO",
             Description = "",
             RvuTotal = 2.01m,
             ModalityId = 2,
             CptCode = "74178",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 34,
             Name = "CR",
             Description = "",
             RvuTotal = 10.18m,
             ModalityId = 1,
             CptCode = "71046",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 35,
             Name = "MRI Neck/Face WO",
             Description = "",
             RvuTotal = 1.35m,
             ModalityId = 4,
             CptCode = "70540",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 36,
             Name = "MRA Head WO",
             Description = "",
             RvuTotal = 1.2m,
             ModalityId = 2,
             CptCode = "70544",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 37,
             Name = "MRA Neck WO",
             Description = "",
             RvuTotal = 1.20m,
             ModalityId = 4,
             CptCode = "70547",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 38,
             Name = "MRA Neck W/WO",
             Description = "",
             RvuTotal = 1.80m,
             ModalityId = 4,
             CptCode = "70549",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 39,
             Name = "MRI Brain WO",
             Description = "",
             RvuTotal = 1.48m,
             ModalityId = 4,
             CptCode = "70551",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 40,
             Name = "MRI Brain W/WO",
             Description = "",
             RvuTotal = 2.29m,
             ModalityId = 4,
             CptCode = "70553",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 41,
             Name = "MRI Brain W",
             Description = "",
             RvuTotal = 1.78m,
             ModalityId = 4,
             CptCode = "70552",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 42,
             Name = "MRI Chest W/WO",
             Description = "",
             RvuTotal = 2.26m,
             ModalityId = 4,
             CptCode = "71552",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 43,
             Name = "RI Cervical Spine WO",
             Description = "",
             RvuTotal = 1.48m,
             ModalityId = 4,
             CptCode = "72141",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 44,
             Name = "MRI Thoracic Spine WO",
             Description = "",
             RvuTotal = 1.48m,
             ModalityId = 4,
             CptCode = "72146",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 45,
             Name = "MRI Lumbar Spine WO",
             Description = "",
             RvuTotal = 1.48m,
             ModalityId = 4,
             CptCode = "72148",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 46,
             Name = "MRI Cervical Spine W/WO",
             Description = "",
             RvuTotal = 2.29m,
             ModalityId = 4,
             CptCode = "72156",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 47,
             Name = "MRI Thoracic Spine W/WO",
             Description = "",
             RvuTotal = 2.29m,
             ModalityId = 4,
             CptCode = "72157",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 48,
             Name = "MRI Lumbar Spine W/WO",
             Description = "",
             RvuTotal = 2.29m,
             ModalityId = 4,
             CptCode = "72158",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 49,
             Name = "MRI Pelvis WO",
             Description = "",
             RvuTotal = 1.46m,
             ModalityId = 4,
             CptCode = "72195",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 50,
             Name = "MRI Pelvis W/WO",
             Description = "",
             RvuTotal = 2.20m,
             ModalityId = 4,
             CptCode = "72197",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 51,
             Name = "MRI Abdomen WO",
             Description = "",
             RvuTotal = 1.46m,
             ModalityId = 4,
             CptCode = "74181",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 52,
             Name = "MRI Abdomen W/WO",
             Description = "",
             RvuTotal = 2.20m,
             ModalityId = 4,
             CptCode = "74183",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 53,
             Name = "MRI Lower Extremity WO",
             Description = "",
             RvuTotal = 1.35m,
             ModalityId = 4,
             CptCode = "73718",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 54,
             Name = "MRI Lower Extremity W/WO",
             Description = "",
             RvuTotal = 2.15m,
             ModalityId = 4,
             CptCode = "73720",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 55,
             Name = "MRI Lower Extremity Joint WO",
             Description = "",
             RvuTotal = 1.35m,
             ModalityId = 4,
             CptCode = "73721",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 56,
             Name = "US Breast UNI Limited",
             Description = "",
             RvuTotal = 0.68m,
             ModalityId = 6,
             CptCode = "6642",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 57,
             Name = "US Abdomen Limited",
             Description = "",
             RvuTotal = 0.59m,
             ModalityId = 6,
             CptCode = "76705",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 58,
             Name = "US Retroperitoneal Complete",
             Description = "",
             RvuTotal = 0.74m,
             ModalityId = 6,
             CptCode = "776770",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 59,
             Name = "US Retroperitoneal Limited",
             Description = "",
             RvuTotal = 0.58m,
             ModalityId = 6,
             CptCode = "76775",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 60,
             Name = "US Aorta Screen Limited",
             Description = "",
             RvuTotal = 0.55m,
             ModalityId = 6,
             CptCode = "76706",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 61,
             Name = "US Scrotum",
             Description = "",
             RvuTotal = 0.64m,
             ModalityId = 6,
             CptCode = "76870",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 62,
             Name = "US Pelvis Limited",
             Description = "",
             RvuTotal = 0.5m,
             ModalityId = 6,
             CptCode = "76857",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 63,
             Name = "US Extremity Venous Bilateral",
             Description = "",
             RvuTotal = 0.70m,
             ModalityId = 6,
             CptCode = "93970",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 64,
             Name = "US Extremity Venous Unilateral",
             Description = "",
             RvuTotal = 0.45m,
             ModalityId = 6,
             CptCode = "93971",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 65,
             Name = "US Duplex Abd/Pel Complete",
             Description = "",
             RvuTotal = 1.16m,
             ModalityId = 6,
             CptCode = "793975",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 66,
             Name = "CT Chest Low Dose Screen",
             Description = "",
             RvuTotal = 1.02m,
             ModalityId = 2,
             CptCode = "G0297",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 67,
             Name = "US OB <14 Weeks, Single Fetus",
             Description = "",
             RvuTotal = 0.99m,
             ModalityId = 6,
             CptCode = "76801",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 68,
             Name = "CT Neck WO",
             Description = "",
             RvuTotal = 1.28m,
             ModalityId = 2,
             CptCode = "70490",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           },
           new ExamType
           {
             Id = 69,
             Name = "Screening Mammogram 2D CAD",
             Description = "",
             RvuTotal = 0.76m,
             ModalityId = 3,
             CptCode = "77067",
             IsAdmin = true,
             CreatedById = 1,
             CreatedDate = new DateTime(2019, 9, 22),
             LastModifiedById = 1,
             LastModifiedDate = new DateTime(2019, 9, 22)
           }
         );
      });

      modelBuilder.Entity<Goal>(entity =>
      {
        entity.ToTable("Goal", "Common");

        entity.HasOne(d => d.User)
            .WithMany(p => p.UserGoals)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Goal_User");

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.GoalCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Goal_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.GoalLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Goal_LastModifiedByUser");

        entity.HasData(
          new Goal
          {
            Id = 1,
            UserId = 1,
            YearId = 1,
            DollarAmount = 100000,
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          }
        );

      });

      modelBuilder.Entity<Service>(entity =>
      {
        entity.ToTable("Service", "Common");

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Description).HasMaxLength(200);

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.ServiceCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Service_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.ServiceLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Service_LastModifiedByUser");

        entity.HasOne(d => d.DoctorType)
            .WithMany(p => p.Services)
            .HasForeignKey(d => d.DoctorTypeId)
            .HasConstraintName("FK_Service_DoctorType");

        entity.HasOne(x => x.Parent)
            .WithMany(x => x.Services);

        entity.HasMany(x => x.Services)
            .WithOne(x => x.Parent);

        entity.HasData(
          new Service
          {
            Id = 1,
            Name = "1-9PM",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 2,
            Name = "3-11PM",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 3,
            Name = "BI (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 4,
            Name = "BI (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 5,
            Name = "BI 3 (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 6,
            Name = "BODY CT WL 1 (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 7,
            Name = "BODY CT WL 1 (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 8,
            Name = "DOB (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 9,
            Name = "ED/TRAUMA (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 10,
            Name = "GENERAL (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 11,
            Name = "GENERAL (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 12,
            Name = "MAMMO 1 (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 13,
            Name = "MAMMO 1 (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 14,
            Name = "MAMMO 2 (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 15,
            Name = "MAMMO 2 (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 16,
            Name = "MAMMO 3 (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 17,
            Name = "NEURO 4 (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 18,
            Name = "NEURO ACUTE (AM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 19,
            Name = "NEURO ACUTE (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 20,
            Name = "NEURO NH/INPT (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 21,
            Name = "NEURO NON ACUTE (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          },
          new Service
          {
            Id = 22,
            Name = "DOB (PM)",
            DoctorTypeId = 1,
            Description = "",
            CreatedById = 1,
            CreatedDate = new DateTime(2019, 9, 22),
            LastModifiedById = 1,
            LastModifiedDate = new DateTime(2019, 9, 22)
          }
        );

      });

      modelBuilder.Entity<ServiceExamTypeXref>(entity =>
      {
        entity.ToTable("ServiceExamType_xref", "Common");

        entity.HasOne(d => d.Service)
            .WithMany(p => p.ServiceExamTypes)
            .HasForeignKey(d => d.ServiceId)
            .HasConstraintName("FK_ServiceExamType_xref_Service");

        entity.HasOne(d => d.ExamType)
            .WithMany(p => p.ExamTypeServices)
            .HasForeignKey(d => d.ExamTypeId)
            .HasConstraintName("FK_ServiceExamType_xref_ExamType");
      });

      modelBuilder.Entity<Shift>(entity =>
      {
        entity.ToTable("Shift", "Common");

        entity.HasOne(d => d.ShiftType)
            .WithMany(p => p.Shifts)
            .HasForeignKey(d => d.ShiftTypeId)
            .HasConstraintName("FK_Shift_ShiftType");

        entity.HasOne(d => d.User)
            .WithMany(p => p.UserShifts)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_Shift_User");

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.ShiftCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Shift_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.ShiftLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Shift_LastModifiedByUser");
      });

      modelBuilder.Entity<ShiftServiceXref>(entity =>
      {
        entity.ToTable("ShiftService_xref", "Common");

        entity.HasOne(d => d.Service)
            .WithMany(p => p.ServiceShifts)
            .HasForeignKey(d => d.ServiceId)
            .HasConstraintName("FK_ShiftService_xref_Service");

        entity.HasOne(d => d.Shift)
            .WithMany(p => p.ShiftServices)
            .HasForeignKey(d => d.ShiftId)
            .HasConstraintName("FK_ShiftService_xref_Shift");
      });

      modelBuilder.Entity<ShiftType>(entity =>
      {
        entity.ToTable("ShiftType", "Common");

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Description).HasMaxLength(200);

        entity.HasData(
          new ShiftType
          {
            Id = 1,
            Name = "Default Day",
            StartHour = 7,
            StartMinute = 30,
            EndHour = 16,
            EndMinute = 45,
            IsAdmin = true,
            Description = "Default Radiology Hours"
          },
          new ShiftType
          {
            Id = 2,
            Name = "1-9PM",
            StartHour = 13,
            StartMinute = 0,
            EndHour = 21,
            EndMinute = 0,
            IsAdmin = true,
            Description = ""
          },
          new ShiftType
          {
            Id = 3,
            Name = "3-11PM",
            StartHour = 15,
            StartMinute = 0,
            EndHour = 23,
            EndMinute = 0,
            IsAdmin = true,
            Description = ""
          }
        );
      });

      modelBuilder.Entity<Tag>(entity =>
      {
        entity.ToTable("Tag", "Common");

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Description).HasMaxLength(200);

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.TagCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Tag_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.TagLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Tag_LastModifiedByUser");

        //entity.HasData(
        //  new Tag
        //  {
        //    Id = 1,
        //    Name = "Exam Group 1",
        //    Description = "",
        //    CreatedById = 1,
        //    CreatedDate = new DateTime(2019, 9, 22),
        //    LastModifiedById = 1,
        //    LastModifiedDate = new DateTime(2019, 9, 22)
        //  }
        //);

      });

      modelBuilder.Entity<UserShiftTypeXref>(entity =>
      {
        entity.ToTable("UserShiftType_xref", "Common");

        entity.HasOne(d => d.User)
            .WithMany(p => p.UserShiftTypes)
            .HasForeignKey(d => d.UserId)
            .HasConstraintName("FK_UserShiftType_xref_ApplicationUser");

        entity.HasOne(d => d.ShiftType)
            .WithMany(p => p.ShiftTypeUsers)
            .HasForeignKey(d => d.ShiftTypeId)
            .HasConstraintName("FK_UserShiftType_xref_ShiftType");

        entity.HasData(
          new UserShiftTypeXref
          {
            Id = 1,
            UserId = 1,
            ShiftTypeId = 1
          },
          new UserShiftTypeXref
          {
            Id = 2,
            UserId = 2,
            ShiftTypeId = 1
          },
          new UserShiftTypeXref
          {
            Id = 3,
            UserId = 3,
            ShiftTypeId = 1
          },
          new UserShiftTypeXref
          {
            Id = 4,
            UserId = 1,
            ShiftTypeId = 2
          },
          new UserShiftTypeXref
          {
            Id = 5,
            UserId = 2,
            ShiftTypeId = 2
          },
          new UserShiftTypeXref
          {
            Id = 6,
            UserId = 3,
            ShiftTypeId = 2
          },
          new UserShiftTypeXref
          {
            Id = 7,
            UserId = 1,
            ShiftTypeId = 3
          },
          new UserShiftTypeXref
          {
            Id = 8,
            UserId = 2,
            ShiftTypeId = 3
          },
          new UserShiftTypeXref
          {
            Id = 9,
            UserId = 3,
            ShiftTypeId = 3
          }
        );
      });
    }
  }
}
