using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using HealthCare.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.UI.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendForm(ContactForm form)
        {
            _contactService.InsertContactForm(form);
            TempData["Status"] = "Mesajınız alınmıştır. En kısa sürede dönüş yapılacaktır.";
            return RedirectToAction("Index");
        }
    }
}