using AutoMapper;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Tags
{
  public class TagsMapProfile : Profile
  {
    public TagsMapProfile()
    {
      CreateMap<Tag, TagModel>()
          ;

      CreateMap<TagModel, Tag>();
    }
  }
}
