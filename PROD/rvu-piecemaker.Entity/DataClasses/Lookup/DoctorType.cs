using System;
using System.Collections.Generic;
using System.Text;

namespace RvuPiecemaker.Entities.DataClasses
{
  public partial class DoctorType : ILookup
  {
    public DoctorType()
    {
      Services = new HashSet<Service>();
      Users = new HashSet<ApplicationUser>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
    public int Sort { get; set; }

    public virtual ICollection<Service> Services { get; set; }
    public virtual ICollection<ApplicationUser> Users { get; set; }
  }
}
