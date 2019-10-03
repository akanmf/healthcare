using HealthCare.Model;
using HealthCare.Model.ServiceContracts;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Services
{

    public class TranslationService : ITranslationService
    {
        public Translation GetTranslation(string key, string language)
        {
            var request =
                new RestRequest("api/Translation/{Language}/{key}", Method.GET, DataFormat.Json)
                .AddUrlSegment("Language", language)
                .AddUrlSegment("key", key);
            var resp = Globals.ApiClient.Execute<Translation>(request);
            return resp.Data;
        }

        public IEnumerable<Translation> GetTranslations(string key)
        {
            throw new NotImplementedException();
        }

        public void Insert(string key, string language, string translation)
        {
            throw new NotImplementedException();
        }
    }
}
