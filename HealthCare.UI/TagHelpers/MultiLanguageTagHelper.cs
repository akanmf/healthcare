using HealthCare.Model.ServiceContracts;
using Microsoft.AspNetCore.Razor.TagHelpers;
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

        public MultiLanguageTagHelper(ITranslationService translationService)
        {
            _translationService = translationService;
        }


        public string Key { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            var translation = _translationService.GetTranslation(Key, "tr_tr");


            output.TagName = "MLT";
            output.TagMode = TagMode.StartTagAndEndTag;

            string cssClass="btn btn-outline-success";

            var sb = new StringBuilder();

            if (translation == null)
            {
                translation = new Model.Entity.Translation();
                var c = output.GetChildContentAsync().Result;
                translation.Key = Key;
                translation.Message = c.GetContent();
                cssClass = "btn btn-outline-danger";
            }

            sb.AppendFormat($"<a class='{cssClass}' data-messagekey='{Key}' data-toggle='modal' data-target='#exampleModal'>{translation.Message}</a>");

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
