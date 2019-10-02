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
        public string Key { get; set; }
        public string Translation { get; set; }        

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "MLT";
            output.TagMode = TagMode.StartTagAndEndTag;

            Translation = "Translation:" + Key;

            if (string.IsNullOrEmpty(Translation))
            {
                base.Process(context, output);
                return;
            }

            var sb = new StringBuilder();
            sb.AppendFormat("<a class='fa-edit'>E</a>: {0}", this.Translation);
            
            output.Content.SetHtmlContent(sb.ToString());
        }
    }
}
