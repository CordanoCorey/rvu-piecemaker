using CAIU.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Calendars
{
  public class CalendarModel : BaseEntity
  {
    public int Id { get; set; }
    public IEnumerable<CalendarEventModel> CalendarEvents { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsMaster { get; set; }
    public string Name { get; set; }
    public string Notes { get; set; }
    public int? ParentId { get; set; }
    public DateTime? StartDate { get; set; }
  }

  public class CalendarEventModel : BaseEntity
  {
    public int Id { get; set; }
    public bool AllDayEvent { get; set; }
    public int CalendarId { get; set; }
    public int CalendarEventTypeId { get; set; }
    public string CalendarEventTypeName { get; set; }
    public string Description { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? StartDate { get; set; }
  }
}
