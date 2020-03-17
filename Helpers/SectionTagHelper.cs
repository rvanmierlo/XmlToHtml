using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("section")]
    [RestrictChildren("itemized-list", "list-item")]
    public class SectionTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            var section = context.Items["Section"] as SectionViewModel;
            output.Content.AppendHtml($"<hr/>");
            if (section.SubTitle != null)
                output.Content.AppendHtml($"<h5>{section.SubTitle}</h5>");
            if (section.Paragraph != null)
                output.Content.AppendHtml($"<p>{section.Paragraph}</p>");

            // take care of children
            section.ParseChildren();
            // output.Content.AppendHtml("<ul>");
            foreach (ListViewModel list in section.Lists)
            {
                // Render the child (itemized-list) content
                context.Items["List"] = list;
                TagHelperContent listContent = await output.GetChildContentAsync(false);
                output.Content.AppendHtml(listContent);
            }
            // output.Content.AppendHtml("</ul>");
        }
    }
}