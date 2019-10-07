using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Goal
  {
    public Goal()
    {
    }
    public int Id { get; set; }
    public int UserId { get; set; }
    public int YearId { get; set; }
    public decimal DollarAmount { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual ApplicationUser User { get; set; }
    public virtual Year Year { get; set; }
  }
}
