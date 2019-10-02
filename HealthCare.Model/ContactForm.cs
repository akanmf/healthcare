using System;
using System.Collections.Generic;

namespace HealthCare.Models
{
    public partial class ContactForm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
