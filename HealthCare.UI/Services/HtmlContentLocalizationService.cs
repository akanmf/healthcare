using HealthCare.Model;
using HealthCare.Model.ServiceContracts;
using HealthCare.UI.Contracts;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.UI.Services
{
    public class HtmlContentLocalizationService : LocalizationServiceBase
    {
        ITranslationService _translationService;
        ISession _session;
        IRequestCultureFeature _cultureFeature;

        public HtmlContentLocalizationService(
            IHttpContextAccessor httpContextAccessor,
            ITranslationService translationService
            )
        {
            _translationService = translationService;
            _session = httpContextAccessor.HttpContext.Session;
            _cultureFeature = httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
        }


        public override IHtmlContent Html(string key)
        {
            return Html(key, string.Empty);
        }

        public override IHtmlContent Html(string key, string defaultStr)
        {
            return new HtmlString(Translation(key, defaultStr));
        }


        public override string Translation(string Key, string defaultStr)
        {

            var loggedInUser = _session.Get<LoginResponse>(Globals.LOGGED_IN_USER_SESSION_KEY);

            var cultureCode = _cultureFeature.RequestCulture.Culture.Name;

            var translation = _translationService.GetTranslation(Key, cultureCode);

            string cssClass = "btn btn-outline-success";

            var sb = new StringBuilder();

            if (translation == null || string.IsNullOrEmpty(translation.Message))
            {
                translation = new Model.Entity.Translation();
                translation.Key = Key;
                translation.Message = string.IsNullOrEmpty(defaultStr) ? Key : defaultStr;
                cssClass = "btn btn-outline-danger";
            }

            if (loggedInUser != null)
            {
                sb.AppendFormat($"<a class='{cssClass}' data-messagekey='{Key}' data-toggle='modal' data-target='#exampleModal'>{translation.Message}</a>");
            }
            else
            {
                sb.Append(translation.Message);
            }

            return sb.ToString();
        }

        public override string Translation(string key)
        {
            return Translation(key, key);
        }

    }
}
