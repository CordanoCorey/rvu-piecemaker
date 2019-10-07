using System;
using System.Collections.Generic;

namespace RvuPiecemaker.Entities.DataClasses
{
    public partial class UserLogin
    {
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
