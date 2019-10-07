using System;
using System.Collections.Generic;
using System.Text;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class CalendarEventType : ILookup
  {
    public CalendarEventType()
    {
      CalendarEvents = new HashSet<CalendarEvent>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }
    public bool? AllDayEvent { get; set; }

    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
  }
}
