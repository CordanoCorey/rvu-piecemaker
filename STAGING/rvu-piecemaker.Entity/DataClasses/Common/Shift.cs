using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Shift
  {
    public Shift()
    {
      Exams = new HashSet<Exam>();
      ShiftServices = new HashSet<ShiftServiceXref>();
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShiftTypeId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal? RvuRate { get; set; }
    public decimal? RvuTotal { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public ApplicationUser CreatedBy { get; set; }
    public ApplicationUser LastModifiedBy { get; set; }
    public ApplicationUser User { get; set; }
    public ShiftType ShiftType { get; set; }
    public ICollection<Exam> Exams { get; set; }
    public ICollection<ShiftServiceXref> ShiftServices { get; set; }
  }
}
