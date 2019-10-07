using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Tag
  {
    public Tag()
    {
      ExamTagXref = new HashSet<ExamTagXref>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual ICollection<ExamTagXref> ExamTagXref { get; set; }
  }
}
