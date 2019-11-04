using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Services
{
  public class ServicesMapProfile : Profile
  {
    public ServicesMapProfile()
    {
      CreateMap<Service, ServiceModel>()
          .ForMember(dest => dest.ExamTypes, opt => opt.MapFrom(src => src.ServiceExamTypes))
        ;

      CreateMap<ServiceModel, Service>()
          .ForMember(dest => dest.ServiceExamTypes, opt => opt.MapFrom(src => src.ExamTypes))
        ;

      CreateMap<ServiceExamTypeXref, ServiceExamTypeModel>()
        ;

      CreateMap<ServiceExamTypeModel, ServiceExamTypeXref>()
        ;
    }
  }
}
