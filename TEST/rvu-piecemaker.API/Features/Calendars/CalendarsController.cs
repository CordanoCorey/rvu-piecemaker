using CAIU.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Calendars
{
  [Route("api/calendars")]
  public class CalendarsController : BaseController
  {
    private readonly ICalendarsService _service;

    public CalendarsController(ICalendarsService service, IHttpContextAccessor httpContextAccessor) : base(httpContextAccessor)
    {
      _service = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
      return Get(_service.GetCalendars);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody]CalendarModel model)
    {
      return Put(_service.UpdateCalendar, AuditExisting(model));
    }

    [HttpPost()]
    public IActionResult Post([FromBody]CalendarModel model)
    {
      return Post(_service.InsertCalendar, AuditNew(model));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      return Delete(_service.DeleteCalendar, id);
    }

    [HttpPut("events/{id}")]
    public IActionResult PutEvent(int id, [FromBody]CalendarEventModel model)
    {
      return Put(_service.UpdateCalendarEvent, AuditExisting(model));
    }

    [HttpPost("events")]
    public IActionResult PostEvent([FromBody]CalendarEventModel model)
    {
      return Post(_service.InsertCalendarEvent, AuditNew(model));
    }

    [HttpDelete("events/{id}")]
    public IActionResult DeleteEvent(int id)
    {
      return Delete(_service.DeleteCalendarEvent, id);
    }
  }
}
