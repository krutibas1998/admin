using System;
using System.Collections.Generic;

namespace admin.DatabaseEntity
{
    public partial class UserRegistration
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? UserType { get; set; }
    }
}
