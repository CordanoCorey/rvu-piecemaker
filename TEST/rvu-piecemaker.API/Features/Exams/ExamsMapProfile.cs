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
          .ForMember(dest => dest.Shift, opt => opt.Ignore())
      ;

      CreateMap<ExamModel, Exam>()
          .ForMember(dest => dest.Shift, opt => opt.Ignore())
      ;

      CreateMap<ExamType, ExamTypeModel>()
          .ForMember(dest => dest.ModalityName, opt => opt.MapFrom(src => src.Modality.Name))
          .ForMember(dest => dest.TagIds, opt => opt.MapFrom(src => src.ExamTagXref.Select(x => x.TagId)))
      ;

      CreateMap<ExamTypeModel, ExamType>()
      ;
    }
  }
}
