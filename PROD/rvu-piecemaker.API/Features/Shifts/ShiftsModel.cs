using CAIU.Common;
using RvuPiecemaker.API.Features.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Shifts
{
  public class ShiftModel : BaseEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int ShiftTypeId { get; set; }
    public DateTime? StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public decimal? RvuRate { get; set; }
    public decimal? RvuTotal { get; set; }
    public decimal TotalHours => (decimal)((EndTime.Value - StartTime.Value).TotalHours);
    public IEnumerable<ExamModel> Exams { get; set; }
  }
  public class ShiftTypeModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public bool IsAdmin { get; set; }
  }
  public class ShiftTotalsModel
  {
    public decimal RvuTotalCompleted { get; set; }
    public decimal ShiftHoursCompleted { get; set; }
    public decimal ShiftHoursRemaining { get; set; }
  }
}
