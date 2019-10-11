using HealthCare.Model;
using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Session;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.UI.TagHelpers
{

    [HtmlTargetElement("MLT")]
    public class MultiLanguageTagHelper : TagHelper
    {
        ITranslationService _translationService;
        ISession _session;

        public MultiLanguageTagHelper(ITranslationService translationService, IHttpContextAccessor httpContextAccessor)
        {
            _translationService = translationService;
            _session = httpContextAccessor.HttpContext.Session ;

            
        }


        public string Key { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var loggedInUser = _session.Get<LoginResponse>(Globals.LOGGED_IN_USER_SESSION_KEY);


            var translation = _translationService.GetTranslation(Key, "tr_tr");


            output.TagName = "MLT";
            output.TagMode = TagMode.StartTagAndEndTag;

            string cssClass = "btn btn-outline-success";

            var sb = new StringBuilder();

            if (translation == null)
            {
                translation = new Model.Entity.Translation();
                var c = output.GetChildContentAsync().Result;
                translation.Key = Key;
                translation.Message = c.GetContent();
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

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
