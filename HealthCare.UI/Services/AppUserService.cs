using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Services
{
    public class AppUserService : IAppUserService
    {
        public  LoginResponse Login(LoginRequest loginRequest)
        {
            var request =
                 new RestRequest("api/AppUser", Method.POST, DataFormat.Json)
                 .AddJsonBody(loginRequest);
            var resp = Globals.ApiClient.Execute<LoginResponse>(request);
            return resp.Data;
        }

        public AppUser Register(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
