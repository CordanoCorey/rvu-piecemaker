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
    IEnumerable<ExamModel> FindBy(int userId);
    IEnumerable<ExamModel> FindBy(DateTime date);
    IEnumerable<ExamModel> FindBy(int userId, DateTime date);
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
        .Include(x => x.Service)
       ;
    }

    protected override IQueryable<Exam> Include(IQueryable<Exam> queryable)
    {
      return queryable
        .Include(x => x.ExamType)
          .ThenInclude(y => y.Modality)
        .Include(x => x.Service)
       ;
    }

    protected override IQueryable<Exam> IncludeSingle(IQueryable<Exam> queryable)
    {
      return queryable
        .Include(x => x.ExamType)
          .ThenInclude(y => y.Modality)
        .Include(x => x.Service)
       ;
    }

    public IEnumerable<ExamModel> FindBy(int userId)
    {
      return FindBy(x => x.CreatedById == userId);
    }

    public IEnumerable<ExamModel> FindBy(DateTime date)
    {
      return FindBy(x => x.StartTime.Date == date);
    }

    public IEnumerable<ExamModel> FindBy(int userId, DateTime date)
    {
      return FindBy(x => x.CreatedById == userId && x.StartTime.Date == date);
    }
  }
}
