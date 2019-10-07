using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ServiceExamTypeXref
  {
    public ServiceExamTypeXref()
    {
    }
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public int ServiceId { get; set; }

    public virtual Service Service { get; set; }
    public virtual ExamType ExamType { get; set; }
  }
}
