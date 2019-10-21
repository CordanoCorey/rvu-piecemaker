using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ExamType
  {
    public ExamType()
    {
      Exams = new HashSet<Exam>();
      ExamGroupXref = new HashSet<ExamGroupXref>();
      ExamTypeServices = new HashSet<ServiceExamTypeXref>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal RvuTotal { get; set; }
    public string CptCode { get; set; }
    public int ModalityId { get; set; }
    public bool IsAdmin { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual Modality Modality { get; set; }
    public virtual ICollection<Exam> Exams { get; set; }
    public virtual ICollection<ExamGroupXref> ExamGroupXref { get; set; }
    public virtual ICollection<ServiceExamTypeXref> ExamTypeServices { get; set; }
  }
}
