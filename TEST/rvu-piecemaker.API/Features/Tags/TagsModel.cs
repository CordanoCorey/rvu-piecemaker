using CAIU.Common;
using RvuPiecemaker.API.Features.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Tags
{
  public class TagModel : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
