using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ExamGroupXref
  {
    public ExamGroupXref()
    {
    }
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public int ExamGroupId { get; set; }
    public int Order { get; set; }

    public virtual ExamGroup ExamGroup { get; set; }
    public virtual ExamType ExamType { get; set; }
  }
}
