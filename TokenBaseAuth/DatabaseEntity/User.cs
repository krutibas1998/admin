using System;
using System.Collections.Generic;

namespace TokenBaseAuth.DatabaseEntity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string State { get; set; } = null!;
        public string? UserName { get; set; }
    }
}
