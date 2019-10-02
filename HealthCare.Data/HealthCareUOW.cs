using HealthCare.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthCare.Data
{
    public class HealthCareUOW : IHealthCareUOW, IDisposable
    {        
        private DbContext context = new HealthCareContext();

        GenericRepository<Translation> translationRepository;
        public GenericRepository<Translation> TranslationRepository
        {
            get
            {
                if (this.translationRepository == null)
                {
                    this.translationRepository = new GenericRepository<Translation>(context);
                }
                return this.translationRepository;
            }
        }

        private GenericRepository<ContactForm> contactFormRepository;
        public GenericRepository<ContactForm> ContactFormRepository
        {
            get
            {
                if (this.contactFormRepository == null)
                {
                    this.contactFormRepository = new GenericRepository<ContactForm>(context);
                }
                return this.contactFormRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
