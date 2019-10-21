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
          ;

      CreateMap<ExamGroupModel, ExamGroup>();
    }
  }
}
