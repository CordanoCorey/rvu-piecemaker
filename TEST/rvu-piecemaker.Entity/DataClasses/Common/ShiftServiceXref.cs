using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ShiftServiceXref
  {
    public ShiftServiceXref()
    {
    }
    public int Id { get; set; }
    public int ServiceId { get; set; }
    public int ShiftId { get; set; }
    public int? DurationMinutes { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }

    public virtual Service Service { get; set; }
    public virtual Shift Shift { get; set; }
  }
}
