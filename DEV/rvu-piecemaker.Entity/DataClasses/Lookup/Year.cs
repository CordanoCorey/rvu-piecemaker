using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Year : ILookup
  {
    public Year()
    {
      Calendars = new HashSet<Calendar>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }
    public int YearTypeId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public virtual YearType YearType { get; set; }
    public virtual ICollection<Calendar> Calendars { get; set; }
  }
}
