using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class YearType : ILookup
  {
    public YearType()
    {
      Users = new HashSet<ApplicationUser>();
      Years = new HashSet<Year>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }

    public virtual ICollection<ApplicationUser> Users { get; set; }
    public virtual ICollection<Year> Years { get; set; }
  }
}
