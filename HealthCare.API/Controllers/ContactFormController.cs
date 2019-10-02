using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Data;
using HealthCare.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactFormController : ControllerBase
    {

        IHealthCareUOW _healthCareContext;

        public ContactFormController(IHealthCareUOW healthCareContext)
        {
            _healthCareContext = healthCareContext;
        }

        // GET: api/Contact
        [HttpGet]
        public IEnumerable<ContactForm> Get()
        {

            var res= _healthCareContext.ContactFormRepository.Get().ToList();
            return res;
        }

        // GET: api/Contact/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Contact
        [HttpPost]
        public void Post(ContactForm form)
        {
            _healthCareContext.ContactFormRepository.Insert(form);
            _healthCareContext.Save();
        }

        // PUT: api/Contact/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
