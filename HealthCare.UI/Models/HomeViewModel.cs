using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Models
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {

        }
        public HomeViewModel(HttpContext httpContext) : base(httpContext)
        {

        }
    }
}
