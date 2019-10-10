using HealthCare.Model;
using HealthCare.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Data
{
    public interface IHealthCareUOW
    {
        public GenericRepository<Translation> TranslationRepository { get; }

        public GenericRepository<ContactForm> ContactFormRepository { get; }

        public GenericRepository<AppUser> AppUserRepository { get; }

        public void Save();
    }
}
