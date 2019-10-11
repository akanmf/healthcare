using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Model
{
    public class LoginResponse : ResponseBase
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
