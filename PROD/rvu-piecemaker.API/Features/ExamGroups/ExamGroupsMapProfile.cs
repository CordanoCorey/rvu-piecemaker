using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.ExamGroups
{
  public class ExamGroupsMapProfile : Profile
  {
    public ExamGroupsMapProfile()
    {
      CreateMap<ExamGroup, ExamGroupModel>()
          .ForMember(dest => dest.ExamTypes, opt => opt.MapFrom(src => src.ExamGroupXref))
      ;

      CreateMap<ExamGroupModel, ExamGroup>()
          .ForMember(dest => dest.ExamGroupXref, opt => opt.MapFrom(src => src.ExamTypes))
      ;

      CreateMap<ExamGroupXref, ExamGroupXrefModel>()
      ;

      CreateMap<ExamGroupXrefModel, ExamGroupXref>()
      ;
    }
  }
}
