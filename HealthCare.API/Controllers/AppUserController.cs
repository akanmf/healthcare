using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthCare.API.Services;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthCare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        IAppUserService _appUserService;
        public AppUserController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            var response =  _appUserService.Login(request);
            if (!string.IsNullOrEmpty(response.ErrorMessage))
            {
                return Unauthorized(response);
            }
            return Ok(response);
        }

        [HttpPost("Register")]
        public IActionResult Register([FromBody] AppUser request)
        {
            _appUserService.Register(request);

            return Ok();
        }

    }
}