using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.API.Features.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Goals
{
  public interface IGoalsService
  {
    IEnumerable<GoalModel> GetGoals(int userId);
    GoalModel GetGoal(int id);
    GoalModel GetUserGoal(int userId);
    GoalModel InsertGoal(GoalModel model);
    GoalModel UpdateGoal(GoalModel model);
    void DeleteGoal(int id);
  }

  public class GoalsService : IGoalsService
  {
    private readonly IGoalsRepository _repo;
    private readonly IShiftsService _shifts;
    private readonly IUsersRepository _users;

    public GoalsService(IGoalsRepository repo, IShiftsService shifts, IUsersRepository users)
    {
      _repo = repo;
      _shifts = shifts;
      _users = users;
    }

    public void DeleteGoal(int id)
    {
      _repo.Delete(id);
    }

    public GoalModel GetGoal(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<GoalModel> GetGoals(int userId)
    {
      return _repo.FindByUser(userId);
    }

    public GoalModel GetUserGoal(int userId)
    {
      var goal = _repo.FindCurrentYearByUser(userId);
      var totals = _shifts.GetShiftTotals(userId, goal.YearId);
      goal.RvuRate = _users.FindUserRvuRate(userId);
      goal.RvuTotalCompleted = totals.RvuTotalCompleted;
      goal.ShiftHoursCompleted = totals.ShiftHoursCompleted;
      goal.ShiftHoursRemaining = totals.ShiftHoursRemaining;
      return goal;
    }

    public GoalModel InsertGoal(GoalModel model)
    {
      var inserted = _repo.Insert(model);
      return GetGoal(inserted.Id);
    }

    public GoalModel UpdateGoal(GoalModel model)
    {
      var updated = _repo.Update(model);
      return GetGoal(updated.Id);
    }
  }
}
