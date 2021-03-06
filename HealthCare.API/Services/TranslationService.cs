﻿using HealthCare.Data;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{

    public class TranslationService : ITranslationService
    {
        IHealthCareUOW _healthCareContext;
        public TranslationService(IHealthCareUOW healthCareContext)
        {
            _healthCareContext = healthCareContext;
        }
        public Translation GetTranslation(string key, string language)
        {
            var result = _healthCareContext.TranslationRepository.Get(x => x.Key == key && x.Language == language).FirstOrDefault();
            return result;
        }

        public IEnumerable<Translation> GetTranslations(string key)
        {
            var result = _healthCareContext.TranslationRepository.Get(x => x.Key == key);
            return result;
        }

        public void Insert(string key, string language, string translation)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(Translation translation)
        {
            var entity = _healthCareContext.TranslationRepository.Get(x => x.Key == translation.Key && x.Language == translation.Language).FirstOrDefault();

            if (entity == null)
            {
                _healthCareContext.TranslationRepository.Insert(translation);
            }
            else
            {
                entity.Message = translation.Message;
                _healthCareContext.TranslationRepository.Update(entity);
            }
            _healthCareContext.Save();
        }
    }
}
