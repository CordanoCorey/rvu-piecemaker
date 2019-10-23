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
          ;

      CreateMap<ServiceModel, Service>()
        ;
    }
  }
}
