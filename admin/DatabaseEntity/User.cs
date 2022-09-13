using System;
using System.Collections.Generic;

namespace admin.DatabaseEntity
{
    public partial class User
    {
        //public User()
        //{
        //    Claims = new HashSet<Claim>();
        //}

        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? State { get; set; }
        public string? UserName { get; set; }
        public string? Physician { get; set; }

       // public virtual ICollection<Claim> Claims { get; set; }
    }
}
