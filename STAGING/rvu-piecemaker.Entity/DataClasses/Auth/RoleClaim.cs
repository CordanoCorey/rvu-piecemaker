using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
    public partial class RoleClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int RoleId { get; set; }

        public virtual ApplicationRole Role { get; set; }
    }
}
