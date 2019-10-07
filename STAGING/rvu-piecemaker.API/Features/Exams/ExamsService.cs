using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.API.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Exams
{
  public interface IExamsService
  {
    IEnumerable<ExamModel> GetAllExams();
    IEnumerable<ExamModel> GetUserExams(int userId);
    IEnumerable<ExamTypeModel> GetUserExamTypes(int userId);
    ExamModel GetExam(int id);
    ExamTypeModel GetExamType(int id);
    IEnumerable<ExamTypeModel> GetAllExamTypes();
    ExamModel InsertExam(ExamModel model);
    ExamTypeModel InsertExamType(ExamTypeModel model);
    ExamModel UpdateExam(ExamModel model);
    ExamTypeModel UpdateExamType(ExamTypeModel model);
    void DeleteExam(int id);
    void DeleteExamType(int id);
  }

  public class ExamsService : IExamsService
  {
    private readonly IExamsRepository _repo;
    private readonly IExamTypesRepository _examTypes;
    private readonly IShiftsService _shifts;
    private readonly IUsersRepository _users;

    public ExamsService(IExamsRepository repo, IExamTypesRepository examTypes, IShiftsService shifts, IUsersRepository users)
    {
      _repo = repo;
      _examTypes = examTypes;
      _shifts = shifts;
      _users = users;
    }

    public void DeleteExam(int id)
    {
      _repo.Delete(id);
    }

    public ExamModel GetExam(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<ExamModel> GetAllExams()
    {
      return _repo.All();
    }

    public IEnumerable<ExamModel> GetUserExams(int userId)
    {
      return _repo.FindByUser(userId);
    }

    public ExamModel InsertExam(ExamModel model)
    {
      if (model.Shift != null && model.ShiftId == 0)
      {
        model.Shift.CreatedById = model.CreatedById;
        model.Shift.CreatedDate = model.CreatedDate;
        model.Shift.LastModifiedById = model.LastModifiedById;
        model.Shift.LastModifiedDate = model.LastModifiedDate;
        var shift = _shifts.InsertShift(model.Shift);
        model.ShiftId = shift.Id;
      }

      var inserted = _repo.Insert(model);
      return GetExam(inserted.Id);
    }

    public ExamModel UpdateExam(ExamModel model)
    {
      var updated = _repo.Update(model);
      return GetExam(updated.Id);
    }

    public IEnumerable<ExamTypeModel> GetUserExamTypes(int userId)
    {
      return _examTypes.FindByUser(userId);
    }

    public ExamTypeModel InsertExamType(ExamTypeModel model)
    {
      var inserted = _examTypes.Insert(model);
      return GetExamType(inserted.Id);
    }

    public ExamTypeModel UpdateExamType(ExamTypeModel model)
    {
      var updated = _examTypes.Update(model);
      return GetExamType(model.Id);
    }

    public void DeleteExamType(int id)
    {
      _repo.Delete(id);
    }

    public ExamTypeModel GetExamType(int id)
    {
      return _examTypes.FindByKey(id);
    }

    public IEnumerable<ExamTypeModel> GetAllExamTypes()
    {
      return _examTypes.All();
    }
  }
}
