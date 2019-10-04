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
        public ContactService(IConfiguration config)
        {
            _config = config;
        }
        public void InsertContactForm(ContactForm form)
        {
            var request =
                new RestRequest("api/ContactForm", Method.POST, DataFormat.Json)
                .AddJsonBody(form);
            var resp = Globals.ApiClient.Execute(request);
        }
    }
}
