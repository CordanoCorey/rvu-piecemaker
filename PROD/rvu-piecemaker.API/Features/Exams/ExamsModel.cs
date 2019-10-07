using CAIU.Common;
using RvuPiecemaker.API.Features.Shifts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Exams
{
  public class ExamModel : BaseEntity
  {
    public int Id { get; set; }
    public int ExamTypeId { get; set; }
    public string Notes { get; set; }
    public decimal? RvuTotal { get; set; }
    public int ServiceId { get; set; }
    public int ShiftId { get; set; }
    public ExamTypeModel ExamType { get; set; }
    public ShiftModel Shift { get; set; }
  }

  public class ExamTypeModel : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal RvuTotal { get; set; }
    public string CptCode { get; set; }
    public int ModalityId { get; set; }
    public string ModalityName { get; set; }
    public bool IsAdmin { get; set; }
    public IEnumerable<int> TagIds { get; set; }
  }
}
