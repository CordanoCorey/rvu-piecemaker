using CAIU.Common;
using RvuPiecemaker.API.Features.Exams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Services
{
  public class ServiceModel : BaseEntity
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int DoctorTypeId { get; set; }
    public int? ParentId { get; set; }
  }
}
