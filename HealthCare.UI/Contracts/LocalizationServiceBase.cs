using Microsoft.AspNetCore.Html;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.UI.Contracts
{
    public abstract class LocalizationServiceBase
    {

        public abstract IHtmlContent Html(string key);
        public abstract IHtmlContent Html(string key,string defaultStr);

        public abstract string Translation(string key);
        public abstract string Translation(string key,string defaultStr);
    }
}
