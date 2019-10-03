using HealthCare.Model;
using HealthCare.Model.ServiceContracts;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Services
{
    public class ContactService : IContactService
    {
        IConfiguration _config;
        Globals _globals;
        public ContactService(IConfiguration config, Globals globals)
        {
            _config = config;
            _globals = globals;
        }
        public void InsertContactForm(ContactForm form)
        {
            var request =
                new RestRequest("api/ContactForm", Method.POST, DataFormat.Json)
                .AddJsonBody(form);
            var resp = _globals.ApiClient.Execute(request);
        }
    }
}
