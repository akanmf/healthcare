using HealthCare.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Model.ServiceContracts
{
    public interface ITranslationService
    {
        public Translation GetTranslation(string key, string language);

        public IEnumerable<Translation> GetTranslations(string key);

        public void Insert(string key, string language, string translation);

        public void InsertOrUpdate(Translation translation);
    }
}
