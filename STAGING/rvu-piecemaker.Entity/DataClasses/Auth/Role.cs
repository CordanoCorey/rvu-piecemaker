using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
    public partial class Role
    {
        public Role()
        {
            RoleClaim = new HashSet<RoleClaim>();
            UserRole = new HashSet<UserRole>();
        }

        public int Id { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }

        public virtual ICollection<RoleClaim> RoleClaim { get; set; }
        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
