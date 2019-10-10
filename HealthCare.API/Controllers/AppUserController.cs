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
        public async Task<IActionResult> Login([FromBody] LoginRequestModel request)
        {
            var token = await _appUserService.Login(request);
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }
            return Ok(token);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] AppUser request)
        {
            await _appUserService.Register(request);

            return Ok();
        }

    }
}