using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Users
{
  public class UsersMapProfile : Profile
  {
    public UsersMapProfile()
    {
      CreateMap<ApplicationUser, UserModel>()
        .ForMember(dest => dest.YearGoalDollarAmount, opt => opt.MapFrom(src => src.UserGoals.FirstOrDefault(x => x.Year.IsActive) == null ?
        0 : src.UserGoals.FirstOrDefault(x => x.Year.IsActive).DollarAmount))
        .ForMember(dest => dest.Year, opt => opt.MapFrom(src => src.YearType != null ? src.YearType.Years.FirstOrDefault(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now) : null))
      //.ForMember(dest => dest.YearGoalDollarAmount, opt => opt.Ignore())
      //.ForMember(dest => dest.Year, opt => opt.Ignore())
      ;

      CreateMap<UserModel, ApplicationUser>();
    }
  }
}
