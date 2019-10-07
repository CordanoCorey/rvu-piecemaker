using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Shifts
{
  public class ShiftsMapProfile : Profile
  {
    public ShiftsMapProfile()
    {
      CreateMap<Shift, ShiftModel>()
        ;

      CreateMap<ShiftModel, Shift>()
        ;
    }
  }
}
