using CAIU.Common;
using RvuPiecemaker.API.Features.Shifts;
using RvuPiecemaker.Entities.DataClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RvuPiecemaker.API.Features.Users
{
  public class UserModel
  {
    public int Id { get; set; }
    public int? DoctorTypeId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string PasswordResetCode { get; set; }
    public ShiftTypeModel ShiftType { get; set; }
    public int? ShiftTypeId { get; set; }
    public decimal? RvuRate { get; set; }
    public Year Year { get; set; }
    public decimal? YearGoalDollarAmount { get; set; }
    public int? YearTypeId { get; set; }
  }
}
