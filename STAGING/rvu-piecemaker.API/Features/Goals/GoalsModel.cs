using CAIU.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Goals
{
  public class GoalModel : BaseEntity
  {
    public int Id { get; set; }
    public int UserId { get; set; }
    public int YearId { get; set; }
    public string YearName { get; set; }
    public decimal DollarAmount { get; set; }
    public decimal? RvuRate { get; set; }
    public decimal? RvuTotalCompleted { get; set; }
    public decimal? ShiftHoursCompleted { get; set; }
    public decimal? ShiftHoursRemaining { get; set; }
  }
}
