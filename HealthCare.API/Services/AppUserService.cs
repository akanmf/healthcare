using HealthCare.Data;
using HealthCare.Model;
using HealthCare.Model.Entity;
using HealthCare.Model.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.API.Services
{
    public class AppUserService : IAppUserService
    {
        public IConfiguration _configuration { get; }
        IHealthCareUOW _healthCareContext;
        public AppUserService(IConfiguration configuration, IHealthCareUOW healthCareContext)
        {
            _configuration = configuration;
            _healthCareContext = healthCareContext;
        }

        public LoginResponse Login(LoginRequest loginRequest)
        {
            var response = new LoginResponse();

            var userFromRepo = GetUser(loginRequest);
            if (userFromRepo == null)
            {
                response.ErrorMessage = "Hatalı kullanıcı adı/şifre";
            }
            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("JWTSettings:SecretKey").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier,userFromRepo.Id.ToString()),
                    new Claim(ClaimTypes.Email, userFromRepo.Email),
                    new Claim(ClaimTypes.Name, userFromRepo.FullName),
                    new Claim(ClaimTypes.Role,"Admin"),
                    new Claim(ClaimTypes.Role,"Writer")
                }),
                    Issuer = _configuration.GetSection("JWTSettings:Issuer").Value,
                    Expires = DateTime.Now.AddDays(int.Parse(_configuration.GetSection("JWTSettings:ExpireDays").Value)),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                response.UserName = userFromRepo.FullName;
                response.Token = tokenString;
            }

            return response;

        }

        public AppUser Register(AppUser user)
        {
            user.Password = CreatePasswordHash(user.Password);
            _healthCareContext.AppUserRepository.Insert(user);
            _healthCareContext.Save();
            return user;
        }


        private string CreatePasswordHash(string password)
        {
            var salt = _configuration.GetSection("Salt").Value;
            var provider = new SHA1CryptoServiceProvider();
            var encoding = new UnicodeEncoding();
            var passBytes = provider.ComputeHash(encoding.GetBytes(password + salt));
            password = Convert.ToBase64String(passBytes);
            return password;
        }


        private AppUser GetUser(LoginRequest loginReq)
        {
            var hashedPass = CreatePasswordHash(loginReq.Password);
            var user = _healthCareContext.AppUserRepository
                .Get(x => x.Email == loginReq.Email && x.Password == hashedPass)
                .FirstOrDefault();
            return user;
        }
    }
}
