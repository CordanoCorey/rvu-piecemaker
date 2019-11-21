using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Exams
{
  public class ExamsMapProfile : Profile
  {
    public ExamsMapProfile()
    {
      CreateMap<Exam, ExamModel>()
          .ForMember(dest => dest.ServiceName, opt => opt.MapFrom(src => src.Service.Name))
          .ForMember(dest => dest.Shift, opt => opt.Ignore())
      ;

      CreateMap<ExamModel, Exam>()
          .ForMember(dest => dest.Shift, opt => opt.Ignore())
      ;

      CreateMap<ExamType, ExamTypeModel>()
          .ForMember(dest => dest.ExamGroupIds, opt => opt.MapFrom(src => src.ExamGroupXref.Select(x => x.ExamGroupId)))
          .ForMember(dest => dest.ModalityName, opt => opt.MapFrom(src => src.Modality.Name))
      ;

      CreateMap<ExamTypeModel, ExamType>()
      ;
    }
  }
}
