using RvuPiecemaker.API.Features.Users;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Shifts
{
  public interface IShiftsService
  {
    IEnumerable<ShiftModel> GetShifts();
    IEnumerable<ShiftModel> GetUserShifts(int userId);
    IEnumerable<ShiftModel> GetUserShifts(string email);
    ShiftModel GetShift(int id);
    ShiftModel InsertShift(ShiftModel model);
    ShiftModel UpdateShift(ShiftModel model);
    void DeleteShift(int id);
    IEnumerable<ShiftModel> GetAllShiftsForYear(UserModel user);
    IEnumerable<ShiftModel> GetAllShiftsForYear(UserModel user, IEnumerable<ShiftModel> shifts);
    ShiftTotalsModel GetShiftTotals(int userId, int yearId);
    ShiftTotalsModel GetShiftTotals(int userId, DateTime startDate, DateTime endDate);
  }

  public class ShiftsService : IShiftsService
  {
    private readonly IShiftsRepository _repo;
    private readonly IUsersRepository _users;

    public ShiftsService(IShiftsRepository repo, IUsersRepository users)
    {
      _repo = repo;
      _users = users;
    }

    public void DeleteShift(int id)
    {
      _repo.Delete(id);
    }

    public IEnumerable<ShiftModel> GetAllShiftsForYear(UserModel user)
    {
      var year = user.Year;
      var shiftType = user.ShiftType;
      var shifts = new List<ShiftModel>();
      var date = year.StartDate;
      while (date < year.EndDate)
      {
        if (!(date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday))
        {
          shifts.Add(new ShiftModel()
          {
            StartTime = new DateTime(date.Year, date.Month, date.Day, shiftType.StartHour, shiftType.StartMinute, 0),
            EndTime = new DateTime(date.Year, date.Month, date.Day, shiftType.EndHour, shiftType.EndMinute, 0),
            UserId = user.Id,
            RvuRate = user.RvuRate
          });
        }
        date = date.AddDays(1);
      }
      return shifts;
    }

    public IEnumerable<ShiftModel> GetAllShiftsForYear(UserModel user, IEnumerable<ShiftModel> shifts)
    {
      var yearShifts = GetAllShiftsForYear(user);
      var allShifts = yearShifts.Select(x =>
      {
        var shift = shifts.FirstOrDefault(y => y.StartTime.Value.Date == x.StartTime.Value.Date);
        return shift == null ? x : shift;
      }).ToList();
      foreach (var s in shifts)
      {
        if(!allShifts.Contains(s))
        {
          allShifts.Add(s);
        }
      }
      return allShifts;
    }

    public ShiftModel GetShift(int id)
    {
      return _repo.FindByKey(id);
    }

    public IEnumerable<ShiftModel> GetShifts()
    {
      return _repo.All();
    }

    public ShiftTotalsModel GetShiftTotals(int userId, int yearId)
    {
      var year = _repo.FindYear(yearId);
      if (year != null)
      {
        return GetShiftTotals(userId, year.StartDate, year.EndDate);
      }
      return null;
    }

    public ShiftTotalsModel GetShiftTotals(int userId, DateTime startDate, DateTime endDate)
    {
      var totals = new ShiftTotalsModel();
      var shifts = GetUserShifts(userId);
      var past = shifts.Where(x => x.StartTime < DateTime.Now);
      var future = shifts.Where(x => x.StartTime > DateTime.Now);
      totals.ShiftHoursCompleted = past.Aggregate(0m, (acc, x) => acc + x.TotalHours);
      totals.ShiftHoursRemaining = future.Aggregate(0m, (acc, x) => acc + x.TotalHours);
      totals.RvuTotalCompleted = past.Aggregate(0m, (acc, x) => x.Id == 0 ? 0 : (x.RvuTotal != null ? x.RvuTotal.Value : _repo.FindShiftRvuTotal(x.Id)));
      return totals;
    }

    public IEnumerable<ShiftModel> GetUserShifts(int userId)
    {
      UserModel user = _users.FindByKey(userId);
      if (user != null)
      {
        IEnumerable<ShiftModel> allShifts = _repo.FindByUser(userId);
        return GetAllShiftsForYear(user, allShifts);
      }
      return null;
    }

    public IEnumerable<ShiftModel> GetUserShifts(string email)
    {
      var user = _users.FindUserByEmail(email);
      if (user != null)
      {
        IEnumerable<ShiftModel> allShifts = _repo.FindByUser(user.Id);
        return GetAllShiftsForYear(user, allShifts);
      }
      return null;
    }

    public ShiftModel InsertShift(ShiftModel model)
    {
      if (model.RvuRate == null)
      {
        model.RvuRate = _users.FindUserRvuRate(model.UserId);
      }
      var inserted = _repo.Insert(model);
      return GetShift(inserted.Id);
    }

    public ShiftModel UpdateShift(ShiftModel model)
    {
      var updated = _repo.Update(model);
      return GetShift(updated.Id);
    }
  }
}
