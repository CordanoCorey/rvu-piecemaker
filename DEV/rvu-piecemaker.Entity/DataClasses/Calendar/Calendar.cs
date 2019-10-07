using System;
using System.Collections.Generic;
using System.Text;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class Calendar
  {
    public Calendar()
    {
      Calendars = new HashSet<Calendar>();
      CalendarEvents = new HashSet<CalendarEvent>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public bool IsMaster { get; set; }
    public string Description { get; set; }
    public int? YearId { get; set; }
    public int? ParentId { get; set; }
    public string Notes { get; set; }
    public int CreatedById { get; set; }
    public DateTime CreatedDate { get; set; }
    public int LastModifiedById { get; set; }
    public DateTime LastModifiedDate { get; set; }

    public virtual ApplicationUser CreatedBy { get; set; }
    public virtual ApplicationUser LastModifiedBy { get; set; }
    public virtual Calendar Parent { get; set; }
    public virtual Year Year { get; set; }
    public virtual ICollection<Calendar> Calendars { get; set; }
    public virtual ICollection<CalendarEvent> CalendarEvents { get; set; }
  }
}
