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


            if (translation == null)
            {
                base.Process(context, output);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<a class='fa-edit'>E</a>: {0}", translation.Message);

            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
