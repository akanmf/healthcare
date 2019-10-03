using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI
{
    public static class Globals
    {
        public static readonly string CONTENT_FOLDER_ROOT_PATH = "..";
        public static readonly RestClient ApiClient = new RestClient("http://localhost:55327/");
    }
}
