using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Goals
{
  public interface IGoalsRepository : IBaseRepository<Goal, GoalModel>
  {
    IEnumerable<GoalModel> FindByUser(int userId);
    GoalModel FindCurrentYearByUser(int userId);
  }

  public class GoalsRepository : BaseRepository<RvuPiecemakerContext, Goal, GoalModel>, IGoalsRepository
  {
    public GoalsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Goal> IncludeAll(IQueryable<Goal> queryable)
    {
      return queryable
        .Include(x => x.Year)
      ;
    }

    protected override IQueryable<Goal> Include(IQueryable<Goal> queryable)
    {
      return queryable
        .Include(x => x.Year)
      ;
    }

    protected override IQueryable<Goal> IncludeSingle(IQueryable<Goal> queryable)
    {
      return queryable
        .Include(x => x.Year)
      ;
    }

    public IEnumerable<GoalModel> FindByUser(int userId)
    {
      return FindBy(x => x.UserId == userId);
    }

    public GoalModel FindCurrentYearByUser(int userId)
    {
      return FindSingle(x => x.UserId == userId && x.YearId == 1); //TODO: remove hard-coded year
    }
  }
}
