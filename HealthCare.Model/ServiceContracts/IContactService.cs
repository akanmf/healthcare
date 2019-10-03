using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Model.ServiceContracts
{
    public interface IContactService
    {
        void InsertContactForm(ContactForm form);
    }
}
