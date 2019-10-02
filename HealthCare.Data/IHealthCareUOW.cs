using HealthCare.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Data
{
    public interface IHealthCareUOW
    {
        public GenericRepository<Translation> TranslationRepository { get; }

        public GenericRepository<ContactForm> ContactFormRepository { get;}

        public void Save();
    }
}
