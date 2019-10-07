using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Tags
{
  public interface ITagsRepository : IBaseRepository<Tag, TagModel>
  {
  }

  public class TagsRepository : BaseRepository<RvuPiecemakerContext, Tag, TagModel>, ITagsRepository
  {
    public TagsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Tag> IncludeAll(IQueryable<Tag> queryable)
    {
      return queryable;
    }

    protected override IQueryable<Tag> Include(IQueryable<Tag> queryable)
    {
      return queryable;
    }

    protected override IQueryable<Tag> IncludeSingle(IQueryable<Tag> queryable)
    {
      return queryable;
    }
  }
}
