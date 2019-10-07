using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class ShiftType
  {
    public ShiftType()
    {
      Shifts = new HashSet<Shift>();
      ShiftTypeUsers = new HashSet<UserShiftTypeXref>();
      Users = new HashSet<ApplicationUser>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndHour { get; set; }
    public int EndMinute { get; set; }
    public bool IsAdmin { get; set; }

    public virtual ICollection<Shift> Shifts { get; set; }
    public virtual ICollection<UserShiftTypeXref> ShiftTypeUsers { get; set; }
    public virtual ICollection<ApplicationUser> Users { get; set; }
  }
}
