using HealthCare.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Services
{
    public interface IContactService
    {
        string InsertContactForm(ContactForm form);
    }

    public class ContactService : IContactService
    {
        public string InsertContactForm(ContactForm form)
        {
            var client = new RestClient("http://localhost:55327/");
            var request = new RestRequest("api/ContactForm", Method.POST, DataFormat.Json);            
            request.AddJsonBody(form);
            var resp=client.Execute(request);
            return string.Empty;
        }
    }
}
