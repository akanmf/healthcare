using HealthCare.Model;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI
{
    public static class Globals
    {
        public static void SetGlobals(IConfiguration configuration)
        {
            ApiClient = new RestClient(configuration["HealthCare.Api:Host"]);
            

            CONTENT_FOLDER_ROOT_PATH = "..";

            SupportedLanguages = new List<Language>();
            SupportedLanguages.Add(new Language { Code = "tr-tr", Description = "Türkçe" });
            SupportedLanguages.Add(new Language { Code = "bs", Description = "Bosnian" });
            SupportedLanguages.Add(new Language { Code = "en-us", Description = "Enlish" });
            SupportedLanguages.Add(new Language { Code = "ar-sa", Description = "Arabic" });
            SupportedLanguages.Add(new Language { Code = "es-es", Description = "Spanish" });
        }

        public static RestClient ApiClient { get; private set; }
        public static string CONTENT_FOLDER_ROOT_PATH { get; private set; }
        public static List<Language> SupportedLanguages { get; private set; }

        public static readonly string LOGGED_IN_USER_SESSION_KEY="LoggedInUser";

        public static readonly string LOGGED_IN_USER_TOKEN_COOKIE_KEY = "USER_TOKEN";

    }
}
