using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.DataClasses;

namespace RvuPiecemaker.Entities.Context
{
  public partial class RvuPiecemakerContext
  {
    public virtual DbSet<Calendar> Calendar { get; set; }
    public virtual DbSet<CalendarEvent> CalendarEvent { get; set; }
    public virtual DbSet<CalendarEventType> CalendarEventType { get; set; }

    public void OnModelCreating_Calendar(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Calendar>(entity =>
      {
        entity.ToTable("Calendar", "Common");

        entity.Property(e => e.IsMaster).HasDefaultValue(false);

        entity.Property(e => e.Description).HasMaxLength(100);

        entity.Property(e => e.Name).HasMaxLength(100);

        entity.Property(e => e.Notes).HasMaxLength(250);

        entity.HasOne(x => x.Parent)
            .WithMany(x => x.Calendars);

        entity.HasMany(x => x.Calendars)
            .WithOne(x => x.Parent);

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.CalendarCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Calendar_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.CalendarLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Calendar_LastModifiedByUser");
      });

      modelBuilder.Entity<CalendarEvent>(entity =>
      {
        entity.ToTable("CalendarEvent", "Common");

        entity.Property(e => e.Description).HasMaxLength(100);

        entity.HasOne(d => d.Calendar)
            .WithMany(p => p.CalendarEvents)
            .HasForeignKey(d => d.CalendarId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_CalendarEvent_Calendar");

        entity.HasOne(d => d.CalendarEventType)
            .WithMany(p => p.CalendarEvents)
            .HasForeignKey(d => d.CalendarEventTypeId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_CalendarEvent_CalendarEventType");

        entity.HasOne(d => d.CreatedBy)
            .WithMany(p => p.CalendarEventCreatedBy)
            .HasForeignKey(d => d.CreatedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_CalendarEvent_CreatedByUser");

        entity.HasOne(d => d.LastModifiedBy)
            .WithMany(p => p.CalendarEventLastModifiedBy)
            .HasForeignKey(d => d.LastModifiedById)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_CalendarEvent_LastModifiedByUser");

      });

      modelBuilder.Entity<CalendarEventType>(entity =>
      {
        entity.ToTable("CalendarEventType", "Lookup");

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
      });
    }
  }
}
