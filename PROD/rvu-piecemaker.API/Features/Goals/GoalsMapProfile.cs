using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Goals
{
  public class GoalsMapProfile : Profile
  {
    public GoalsMapProfile()
    {
      CreateMap<Goal, GoalModel>()
        .ForMember(dest => dest.YearName, opt => opt.MapFrom(src => src.Year.Name))
        ;

      CreateMap<GoalModel, Goal>()
        ;
    }
  }
}
