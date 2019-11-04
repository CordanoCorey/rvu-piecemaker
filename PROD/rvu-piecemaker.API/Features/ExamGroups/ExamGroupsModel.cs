using CAIU.Common;
using RvuPiecemaker.API.Features.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.ExamGroups
{
  public class ExamGroupModel : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public IEnumerable<ExamGroupXrefModel> ExamTypes { get; set; }
  }

  public class ExamGroupXrefModel
  {
    public int Id { get; set; }
    public int Order { get; set; }
    public int ExamTypeId { get; set; }
    public int ExamGroupId { get; set; }
  }
}
