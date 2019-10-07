using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
    public partial class UserClaim
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
