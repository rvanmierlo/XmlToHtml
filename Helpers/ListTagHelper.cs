using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("list-item")]
    public class ListItemTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "li";
            var list = context.Items["List"] as ListViewModel;
            output.Content.AppendHtml($"{list.Content}");
        }
    }
}