using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Calendars
{
  public interface ICalendarEventsRepository : IBaseRepository<CalendarEvent, CalendarEventModel>
  {
  }
  public class CalendarEventsRepository : BaseRepository<RvuPiecemakerContext, CalendarEvent, CalendarEventModel>, ICalendarEventsRepository
  {
    public CalendarEventsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<CalendarEvent> Include(IQueryable<CalendarEvent> queryable)
    {
      return queryable
          .Include(y => y.CalendarEventType)
      ;
    }

    protected override IQueryable<CalendarEvent> IncludeSingle(IQueryable<CalendarEvent> queryable)
    {
      return Include(queryable);
    }
  }
}
