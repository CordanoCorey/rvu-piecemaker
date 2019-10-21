using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.ExamGroups
{
  public interface IExamGroupsRepository : IBaseRepository<ExamGroup, ExamGroupModel>
  {
  }

  public class ExamGroupsRepository : BaseRepository<RvuPiecemakerContext, ExamGroup, ExamGroupModel>, IExamGroupsRepository
  {
    public ExamGroupsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<ExamGroup> IncludeAll(IQueryable<ExamGroup> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ExamGroup> Include(IQueryable<ExamGroup> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ExamGroup> IncludeSingle(IQueryable<ExamGroup> queryable)
    {
      return queryable;
    }
  }
}
