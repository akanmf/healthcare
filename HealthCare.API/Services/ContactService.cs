using HealthCare.Data;
using HealthCare.Model;
using HealthCare.Model.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{
    public class ContactService : IContactService
    {
        IHealthCareUOW _healthCareContext;

        public ContactService(IHealthCareUOW healthCareContext)
        {
            _healthCareContext = healthCareContext;
        }

        public void InsertContactForm(ContactForm form)
        {
            _healthCareContext.ContactFormRepository.Insert(form);
            _healthCareContext.Save();
        }
    }
}
