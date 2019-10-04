using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.API.Services;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslationController : ControllerBase
    {
        ITranslationService _translationService;
        public TranslationController(ITranslationService translationService)
        {
            _translationService = translationService;
        }


        // GET: api/Translation/{language}/{key}
        [HttpGet("{language}/{key}")]
        public Translation Get(string language, string key)
        {
            var response = _translationService.GetTranslation(key, language);
            return response;
        }

        // GET: api/Translation/Hello
        [HttpGet("{key}")]
        public List<Translation> Get(string key)
        {
            var response = _translationService.GetTranslations(key);
            return response.ToList();
        }

        // POST: api/Translation
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Translation/5
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
