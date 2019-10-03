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
        }

        public static RestClient ApiClient { get; private set; }
        public static string CONTENT_FOLDER_ROOT_PATH { get; private set; }
    }
}
