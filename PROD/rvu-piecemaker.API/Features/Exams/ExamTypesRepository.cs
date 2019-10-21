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
  public interface IExamTypesRepository : IBaseRepository<ExamType, ExamTypeModel>
  {
    IEnumerable<ExamTypeModel> FindByUser(int userId);
  }

  public class ExamTypesRepository : BaseRepository<RvuPiecemakerContext, ExamType, ExamTypeModel>, IExamTypesRepository
  {
    public ExamTypesRepository(RvuPiecemakerContext context, IMapper mapper) : base(context, mapper)
    {
    }

    protected override IQueryable<ExamType> IncludeAll(IQueryable<ExamType> queryable)
    {
      return queryable
        .Include(x => x.Modality)
        .Include(x => x.ExamGroupXref)
      ;
    }

    protected override IQueryable<ExamType> Include(IQueryable<ExamType> queryable)
    {
      return queryable
        .Include(x => x.Modality)
        .Include(x => x.ExamGroupXref)
      ;
    }

    protected override IQueryable<ExamType> IncludeSingle(IQueryable<ExamType> queryable)
    {
      return queryable
        .Include(x => x.Modality)
        .Include(x => x.ExamGroupXref)
      ;
    }

    public IEnumerable<ExamTypeModel> FindByUser(int userId)
    {
      return FindBy(x => x.CreatedById == userId || x.CreatedById == 1); //TODO: Logic to find "admin exam types"
    }
  }
}
