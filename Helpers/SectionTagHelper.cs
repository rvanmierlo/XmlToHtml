using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("section")]
    [RestrictChildren("list-item")]
    public class SectionTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            var section = context.Items["Section"] as SectionViewModel;
            output.Content.AppendHtml($"<hr/>");
            output.Content.AppendHtml($"<div><h5>{section.SubTitle}</h5></div>");

            // take care of children
            section.ParseChildren();
            output.Content.AppendHtml("<ul>");
            foreach (ListViewModel list in section.Lists)
            {
                // Render the child (list) content
                context.Items["List"] = list;
                TagHelperContent listContent = await output.GetChildContentAsync(false);
                output.Content.AppendHtml(listContent);
            }
            output.Content.AppendHtml("</ul>");
        }
    }
}