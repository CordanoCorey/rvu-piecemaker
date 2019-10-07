using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Shifts
{
  public interface IShiftTypesRepository : IBaseRepository<ShiftType, ShiftTypeModel>
  {
  }

  public class ShiftTypesRepository : BaseRepository<RvuPiecemakerContext, ShiftType, ShiftTypeModel>, IShiftTypesRepository
  {
    public ShiftTypesRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<ShiftType> IncludeAll(IQueryable<ShiftType> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ShiftType> Include(IQueryable<ShiftType> queryable)
    {
      return queryable;
    }

    protected override IQueryable<ShiftType> IncludeSingle(IQueryable<ShiftType> queryable)
    {
      return queryable;
    }
  }
}
