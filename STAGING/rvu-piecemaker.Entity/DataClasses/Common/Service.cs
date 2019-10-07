using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Service
  {
    public Service()
    {
      Exams = new HashSet<Exam>();
      ServiceExamTypes = new HashSet<ServiceExamTypeXref>();
      ServiceShifts = new HashSet<ShiftServiceXref>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DoctorTypeId { get; set; }
    public int? ParentId { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual DoctorType DoctorType { get; set; }
    public virtual Service Parent { get; set; }
    public virtual ICollection<Exam> Exams { get; set; }
    public virtual ICollection<ServiceExamTypeXref> ServiceExamTypes { get; set; }
    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<ShiftServiceXref> ServiceShifts { get; set; }
  }
}
