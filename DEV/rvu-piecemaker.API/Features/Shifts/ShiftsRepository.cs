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
  public interface IShiftsRepository : IBaseRepository<Shift, ShiftModel>
  {
    IEnumerable<ShiftModel> FindByUser(int userId);
    decimal FindShiftRvuTotal(int shiftId);
    Year FindYear(int yearId);
  }

  public class ShiftsRepository : BaseRepository<RvuPiecemakerContext, Shift, ShiftModel>, IShiftsRepository
  {
    public ShiftsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Shift> IncludeAll(IQueryable<Shift> queryable)
    {
      return queryable;
    }

    protected override IQueryable<Shift> Include(IQueryable<Shift> queryable)
    {
      return queryable;
    }

    protected override IQueryable<Shift> IncludeSingle(IQueryable<Shift> queryable)
    {
      return queryable
        .Include(x => x.Exams)
          .ThenInclude(y => y.ExamType)
            .ThenInclude(z => z.Modality)
      ;
    }

    public IEnumerable<ShiftModel> FindByUser(int userId)
    {
      return FindBy(x => x.UserId == userId);
    }

    public Year FindYear(int yearId)
    {
      return _context.Set<Year>().FirstOrDefault(x => x.Id == yearId);
    }

    public decimal FindShiftRvuTotal(int shiftId)
    {
      var exams = FindByKey(shiftId)?.Exams;
      if (exams != null)
      {
        return exams.Aggregate(0m, (acc, exam) =>
        {
          var examRvuTotal = exam.RvuTotal != null && exam.RvuTotal != 0m ? exam.RvuTotal.Value : exam.ExamType.RvuTotal;
          return acc + examRvuTotal;
        });
      }
      return 0;
    }
  }
}
