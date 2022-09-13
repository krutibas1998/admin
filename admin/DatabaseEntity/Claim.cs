using System;
using System.Collections.Generic;

namespace admin.DatabaseEntity
{
    public partial class Claim
    {
        public int ClaimId { get; set; }
        public int UserId { get; set; }
        public string? ClaimType { get; set; }
        public int? ClaimAmmount { get; set; }
        public string? Remarks { get; set; }
        public DateTime? ClaimDate { get; set; }

       // public virtual User User { get; set; } = null!;
    }
}
