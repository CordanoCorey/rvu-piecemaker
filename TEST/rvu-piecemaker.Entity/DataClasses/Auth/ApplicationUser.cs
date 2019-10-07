using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ApplicationUser : IdentityUser<int>
  {
    public ApplicationUser()
    {
      CalendarCreatedBy = new HashSet<Calendar>();
      CalendarLastModifiedBy = new HashSet<Calendar>();
      CalendarEventCreatedBy = new HashSet<CalendarEvent>();
      CalendarEventLastModifiedBy = new HashSet<CalendarEvent>();
      ExamCreatedBy = new HashSet<Exam>();
      ExamLastModifiedBy = new HashSet<Exam>();
      ExamTypeCreatedBy = new HashSet<ExamType>();
      ExamTypeLastModifiedBy = new HashSet<ExamType>();
      GoalCreatedBy = new HashSet<Goal>();
      GoalLastModifiedBy = new HashSet<Goal>();
      UserGoals = new HashSet<Goal>();
      ServiceCreatedBy = new HashSet<Service>();
      ServiceLastModifiedBy = new HashSet<Service>();
      ShiftCreatedBy = new HashSet<Shift>();
      ShiftLastModifiedBy = new HashSet<Shift>();
      UserShiftTypes = new HashSet<UserShiftTypeXref>();
      UserShifts = new HashSet<Shift>();
      TagCreatedBy = new HashSet<Tag>();
      TagLastModifiedBy = new HashSet<Tag>();
    }
    public int? DoctorTypeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PasswordResetCode { get; set; }
    public decimal? RvuRate { get; set; }
    public int? ShiftTypeId { get; set; }
    public int? YearTypeId { get; set; }

    public virtual DoctorType DoctorType { get; set; }
    public virtual ShiftType ShiftType { get; set; }
    public virtual YearType YearType { get; set; }
    public virtual ICollection<Calendar> CalendarCreatedBy { get; set; }
    public virtual ICollection<Calendar> CalendarLastModifiedBy { get; set; }
    public virtual ICollection<CalendarEvent> CalendarEventCreatedBy { get; set; }
    public virtual ICollection<CalendarEvent> CalendarEventLastModifiedBy { get; set; }
    public virtual ICollection<Exam> ExamCreatedBy { get; set; }
    public virtual ICollection<Exam> ExamLastModifiedBy { get; set; }
    public virtual ICollection<ExamType> ExamTypeCreatedBy { get; set; }
    public virtual ICollection<ExamType> ExamTypeLastModifiedBy { get; set; }
    public virtual ICollection<Service> ServiceCreatedBy { get; set; }
    public virtual ICollection<Service> ServiceLastModifiedBy { get; set; }
    public virtual ICollection<Shift> ShiftCreatedBy { get; set; }
    public virtual ICollection<Shift> ShiftLastModifiedBy { get; set; }
    public virtual ICollection<UserShiftTypeXref> UserShiftTypes { get; set; }
    public virtual ICollection<Shift> UserShifts { get; set; }
    public virtual ICollection<Goal> GoalCreatedBy { get; set; }
    public virtual ICollection<Goal> GoalLastModifiedBy { get; set; }
    public virtual ICollection<Goal> UserGoals { get; set; }
    public virtual ICollection<Tag> TagCreatedBy { get; set; }
    public virtual ICollection<Tag> TagLastModifiedBy { get; set; }
  }
}
