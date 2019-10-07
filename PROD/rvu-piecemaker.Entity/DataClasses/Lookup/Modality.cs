using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Modality : ILookup
  {
    public Modality()
    {
      ExamTypes = new HashSet<ExamType>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }

    public virtual ICollection<ExamType> ExamTypes { get; set; }
  }
}
