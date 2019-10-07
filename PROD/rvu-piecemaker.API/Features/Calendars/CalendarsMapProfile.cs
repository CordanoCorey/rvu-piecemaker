using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Calendars
{
  public class CalendarsMapProfile : Profile
  {
    public CalendarsMapProfile()
    {
      CreateMap<Calendar, CalendarModel>()
          ;

      CreateMap<CalendarModel, Calendar>();

      CreateMap<CalendarEvent, CalendarEventModel>()
          .ForMember(dest => dest.AllDayEvent, opt => opt.MapFrom(src => src.CalendarEventType.AllDayEvent))
          .ForMember(dest => dest.CalendarEventTypeName, opt => opt.MapFrom(src => src.CalendarEventType.Name))
          ;

      CreateMap<CalendarEventModel, CalendarEvent>();
    }
  }
}
