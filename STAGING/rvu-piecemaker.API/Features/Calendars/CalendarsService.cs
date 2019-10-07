using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Calendars
{
  public interface ICalendarsService
  {
    IEnumerable<CalendarModel> GetCalendars();
    CalendarModel GetCalendar(int id);
    CalendarModel InsertCalendar(CalendarModel model);
    CalendarModel UpdateCalendar(CalendarModel model);
    void DeleteCalendar(int id);
    CalendarEventModel GetCalendarEvent(int id);
    CalendarEventModel InsertCalendarEvent(CalendarEventModel model);
    CalendarEventModel UpdateCalendarEvent(CalendarEventModel model);
    void DeleteCalendarEvent(int id);
    void RemoveAllDayEvents(int calendarId, DateTime date);
  }

  public class CalendarsService : ICalendarsService
  {
    private readonly ICalendarsRepository _repo;
    private readonly ICalendarEventsRepository _events;

    public CalendarsService(ICalendarsRepository repo, ICalendarEventsRepository events)
    {
      _repo = repo;
      _events = events;
    }

    public void DeleteCalendar(int id)
    {
      _repo.Delete(id);
    }

    public void DeleteCalendarEvent(int id)
    {
      _events.Delete(id);
    }

    public CalendarModel GetCalendar(int id)
    {
      return _repo.FindByKey(id);
    }

    public CalendarEventModel GetCalendarEvent(int id)
    {
      return _events.FindByKey(id);
    }

    public IEnumerable<CalendarModel> GetCalendars()
    {
      return _repo.All();
    }

    public CalendarModel InsertCalendar(CalendarModel model)
    {
      var inserted = _repo.Insert(model);
      return GetCalendar(inserted.Id);
    }

    public CalendarEventModel InsertCalendarEvent(CalendarEventModel model)
    {
      if (model.AllDayEvent && model.StartDate != null)
      {
        RemoveAllDayEvents(model.CalendarId, model.StartDate.Value);
      }
      var inserted = _events.Insert(model);
      return GetCalendarEvent(inserted.Id);
    }

    public void RemoveAllDayEvents(int calendarId, DateTime date)
    {
      var calendar = GetCalendar(calendarId);
      if (calendar != null && calendar.CalendarEvents != null)
      {
        foreach (CalendarEventModel calendarEvent in calendar.CalendarEvents.Where(x => x.AllDayEvent && x.StartDate != null && x.StartDate.Value.Date == date.Date))
        {
          DeleteCalendarEvent(calendarEvent.Id);
        }
      }
    }

    public CalendarModel UpdateCalendar(CalendarModel model)
    {
      _repo.Update(model);
      return GetCalendar(model.Id);
    }

    public CalendarEventModel UpdateCalendarEvent(CalendarEventModel model)
    {
      _events.Update(model);
      return GetCalendarEvent(model.Id);
    }
  }
}
