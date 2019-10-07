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
  public interface ICalendarsRepository : IBaseRepository<Calendar, CalendarModel>
  {
  }
  public class CalendarsRepository : BaseRepository<RvuPiecemakerContext, Calendar, CalendarModel>, ICalendarsRepository
  {
    public CalendarsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Calendar> IncludeAll(IQueryable<Calendar> queryable)
    {
      return queryable
          .Include(x => x.CalendarEvents)
              .ThenInclude(y => y.CalendarEventType)
          .Include(x => x.Parent)
              .ThenInclude(y => y.CalendarEvents)
                  .ThenInclude(z => z.CalendarEventType)
      ;
    }

    protected override IQueryable<Calendar> Include(IQueryable<Calendar> queryable)
    {
      return IncludeAll(queryable);
    }

    protected override IQueryable<Calendar> IncludeSingle(IQueryable<Calendar> queryable)
    {
      return Include(queryable);
    }
  }
}
