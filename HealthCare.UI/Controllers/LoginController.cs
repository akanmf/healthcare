using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace HealthCare.UI.Controllers
{
    public class LoginController : Controller
    {

        IAppUserService _appUserService;
        public LoginController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpGet]

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var response = _appUserService.Login(request);
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                TempData["ErrorMessage"] = response.ErrorMessage;
                return RedirectToAction("Index");
            }

            HttpContext.Session.Set(Globals.LOGGED_IN_USER_SESSION_KEY, response);
            HttpContext.Response.Cookies.Append(Globals.LOGGED_IN_USER_TOKEN_COOKIE_KEY, response.Token);
            
            Globals.ApiClient.AddDefaultHeader("Authentication", $"Bearer {response.Token}");


            return RedirectToAction("Index", "Home");
        }

        [HttpPost("Register")]
        public  IActionResult Register([FromBody] AppUser request)
        {
            _appUserService.Register(request);

            return Ok();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove(Globals.LOGGED_IN_USER_SESSION_KEY);
            Globals.ApiClient.RemoveDefaultParameter("Authentication");
            return RedirectToAction("Index", "Home");
        }
    }
}