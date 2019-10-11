using HealthCare.Model;
using HealthCare.Model.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Models
{
    public class BaseViewModel
    {
        public BaseViewModel()
        {

        }

        readonly HttpContext HttpContext;
        public BaseViewModel(HttpContext httpContext)
        {
            this.HttpContext = httpContext;
            LoginUser = this.HttpContext.Session.Get<LoginResponse>(Globals.LOGGED_IN_USER_SESSION_KEY);
        }

        public LoginResponse LoginUser { get; set; }

    }
}
