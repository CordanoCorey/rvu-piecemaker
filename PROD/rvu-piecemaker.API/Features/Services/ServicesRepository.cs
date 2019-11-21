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

namespace RvuPiecemaker.API.Features.Services
{
  public interface IServicesRepository : IBaseRepository<Service, ServiceModel>
  {
    IEnumerable<ServiceModel> FindByUser(int userId);
  }

  public class ServiceExamTypeComparer : IEqualityComparer<ServiceExamTypeXref>
  {
    public bool Equals(ServiceExamTypeXref b1, ServiceExamTypeXref b2)
    {
      return b1.ExamTypeId == b2.ExamTypeId;
    }

    public int GetHashCode(ServiceExamTypeXref obj)
    {
      return obj.Id.GetHashCode();
    }
  }

  public class ServicesRepository : BaseRepository<RvuPiecemakerContext, Service, ServiceModel>, IServicesRepository
  {
    public ServicesRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Service> IncludeAll(IQueryable<Service> queryable)
    {
      return queryable;
    }

    protected override IQueryable<Service> Include(IQueryable<Service> queryable)
    {
      return queryable
        .Include(x => x.ServiceExamTypes)
        ;
    }

    protected override IQueryable<Service> IncludeSingle(IQueryable<Service> queryable)
    {
      return queryable
        .Include(x => x.ServiceExamTypes)
        ;
    }

    public IEnumerable<ServiceModel> FindByUser(int userId)
    {
      return FindBy(x => true);
    }

    public override ServiceModel Update(ServiceModel model)
    {
      var entity = _mapper.Map<Service>(model);
      var remove = FindEntityByKey(model.Id)?.ServiceExamTypes.Except(entity.ServiceExamTypes, new ServiceExamTypeComparer()).ToList();
      _context.ChangeTracker.TrackGraph(entity, (EntityEntryGraphNode node) =>
      {
        var entry = node.Entry;
        entry.State = entry.IsKeySet ? EntityState.Modified : EntityState.Added;
      });
      foreach (var item in remove)
      {
        _context.Set<ServiceExamTypeXref>().Remove(item);
      }
      Save();
      return Map(entity);
    }
  }
}
