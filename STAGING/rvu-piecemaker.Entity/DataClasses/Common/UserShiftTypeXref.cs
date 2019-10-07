using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class UserShiftTypeXref
  {
    public UserShiftTypeXref()
    {
    }
    public int Id { get; set; }
    public int ShiftTypeId { get; set; }
    public int UserId { get; set; }

    public virtual ApplicationUser User { get; set; }
    public virtual ShiftType ShiftType { get; set; }
  }
}
