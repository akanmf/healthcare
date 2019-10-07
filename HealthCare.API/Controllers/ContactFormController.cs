using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Data;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {
        IContactService _contactService;
        public ContactFormController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // POST: api/Contact
        [HttpPost]
        public void Post(ContactForm form)
        {
            _contactService.InsertContactForm(form);
        }
    }
}
