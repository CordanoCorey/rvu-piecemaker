using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ExamTagXref
  {
    public ExamTagXref()
    {
    }
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public int TagId { get; set; }
    public int Order { get; set; }

    public virtual Tag Tag { get; set; }
    public virtual ExamType ExamType { get; set; }
  }
}
