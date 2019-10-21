using AutoMapper;
using CAIU.Common;
using Microsoft.EntityFrameworkCore;
using RvuPiecemaker.Entities.Context;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Exams
{
  public interface IExamsRepository : IBaseRepository<Exam, ExamModel>
  {
    IEnumerable<ExamModel> FindByDate(DateTime date);
    IEnumerable<ExamModel> FindByUser(int userId);
  }

  public class ExamsRepository : BaseRepository<RvuPiecemakerContext, Exam, ExamModel>, IExamsRepository
  {
    public ExamsRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<Exam> IncludeAll(IQueryable<Exam> queryable)
    {
      return queryable
        .Include(x => x.ExamType)
        .ThenInclude(y => y.Modality)
       ;
    }

    protected override IQueryable<Exam> Include(IQueryable<Exam> queryable)
    {
      return queryable
        .Include(x => x.ExamType)
        .ThenInclude(y => y.Modality)
       ;
    }

    protected override IQueryable<Exam> IncludeSingle(IQueryable<Exam> queryable)
    {
      return queryable
        .Include(x => x.ExamType)
        .ThenInclude(y => y.Modality)
       ;
    }

    public IEnumerable<ExamModel> FindByUser(int userId)
    {
      return FindBy(x => x.CreatedById == userId);
    }

    public IEnumerable<ExamModel> FindByDate(DateTime date)
    {
      return FindBy(x => x.StartTime.Date == date);
    }
  }
}
