using System;
using System.Collections.Generic;

namespace HealthCare.Model.Entity
{
    public partial class AppUser
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
