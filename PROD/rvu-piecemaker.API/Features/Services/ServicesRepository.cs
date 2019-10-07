using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
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
      return queryable;
    }

    protected override IQueryable<Service> IncludeSingle(IQueryable<Service> queryable)
    {
      return queryable;
    }
  }
}
