using HealthCare.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Model.ServiceContracts
{
    public interface IAppUserService
    {
        public AppUser Register(AppUser user);
        public LoginResponse Login(LoginRequest loginRequest);

    }
}
