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
        public async Task<string> Login(LoginRequestModel loginRequest)
        {
            var request =
                 new RestRequest("api/AppUser", Method.POST, DataFormat.Json)
                 .AddJsonBody(loginRequest);
            var resp =Globals.ApiClient.Execute(request);
            return resp.Content;
        }

        public Task<AppUser> Register(AppUser user)
        {
            throw new NotImplementedException();
        }
    }
}
