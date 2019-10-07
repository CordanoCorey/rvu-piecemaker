using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Exam
  {
    public Exam()
    {
    }
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public int ServiceId { get; set; }
    public int ShiftId { get; set; }
    public string Notes { get; set; }
    public decimal? RvuTotal { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual ExamType ExamType { get; set; }
    public virtual Service Service { get; set; }
    public virtual Shift Shift { get; set; }
  }
}
