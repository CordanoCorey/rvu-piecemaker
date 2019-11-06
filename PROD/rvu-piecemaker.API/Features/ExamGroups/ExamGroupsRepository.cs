using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
    IEnumerable<ExamGroupModel> FindForUser(int userId);
  }

  public class ExamGroupXrefComparer : IEqualityComparer<ExamGroupXref>
  {
    public bool Equals(ExamGroupXref b1, ExamGroupXref b2)
    {
      if (b1.ExamTypeId == b2.ExamTypeId)
      {
        return true;
      }
      else
      {
        return false;
      }
    }

    public int GetHashCode(ExamGroupXref obj)
    {
      return obj.Id.GetHashCode();
    }
  }

  public class ExamGroupsRepository : BaseRepository<RvuPiecemakerContext, ExamGroup, ExamGroupModel>, IExamGroupsRepository
  {
    public ExamGroupsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<ExamGroup> IncludeAll(IQueryable<ExamGroup> queryable)
    {
      return queryable
        .Include(x => x.ExamGroupXref)
      ;
    }

    protected override IQueryable<ExamGroup> Include(IQueryable<ExamGroup> queryable)
    {
      return queryable
        .Include(x => x.ExamGroupXref)
      ;
    }

    protected override IQueryable<ExamGroup> IncludeSingle(IQueryable<ExamGroup> queryable)
    {
      return queryable
        .Include(x => x.ExamGroupXref)
      ;
    }

    public override ExamGroupModel Update(ExamGroupModel model)
    {
      var entity = _mapper.Map<ExamGroup>(model);
      var existing = FindEntityByKey(model.Id)?.ExamGroupXref;
      var add = entity.ExamGroupXref.Except(existing, new ExamGroupXrefComparer()).ToList();
      var remove = existing.Except(entity.ExamGroupXref, new ExamGroupXrefComparer()).ToList();
      _context.ChangeTracker.TrackGraph(entity, (EntityEntryGraphNode node) =>
      {
        var entry = node.Entry;
        entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
      });
      foreach (var item in remove)
      {
        _context.Set<ExamGroupXref>().Remove(item);
      }
      Save();
      return Map(entity);
    }

    public IEnumerable<ExamGroupModel> FindForUser(int userId)
    {
      return FindBy(x => x.CreatedById == userId);
    }
  }
}
