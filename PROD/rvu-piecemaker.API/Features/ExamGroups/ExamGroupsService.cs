using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.ExamGroups
{
  public interface IExamGroupsService
  {
    IEnumerable<ExamGroupModel> GetExamGroups(int userId);
    ExamGroupModel GetExamGroup(int id);
    ExamGroupModel InsertExamGroup(ExamGroupModel model);
    ExamGroupModel UpdateExamGroup(ExamGroupModel model);
    void DeleteExamGroup(int id);
  }

  public class ExamGroupsService : IExamGroupsService
  {
    private readonly IExamGroupsRepository _repo;

    public ExamGroupsService(IExamGroupsRepository repo)
    {
      _repo = repo;
    }

    public void DeleteExamGroup(int id)
    {
      _repo.Delete(id);
    }

    public ExamGroupModel GetExamGroup(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<ExamGroupModel> GetExamGroups(int userId)
    {
      return _repo.FindForUser(userId);
    }

    public ExamGroupModel InsertExamGroup(ExamGroupModel model)
    {
      var inserted = _repo.Insert(model);
      return GetExamGroup(inserted.Id);
    }

    public ExamGroupModel UpdateExamGroup(ExamGroupModel model)
    {
      var updated = _repo.Update(model);
      return GetExamGroup(updated.Id);
    }
  }
}
