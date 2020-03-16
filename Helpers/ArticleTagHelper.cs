using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("article")]
    [RestrictChildren("section", "list-item")]
    public class ArticleTagHelper : TagHelper
    {
        public ArticleViewModel Model { get; set; }

        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            Model.Parse();
            output.Content.AppendHtml($"<h3>{Model.Title}</h3>");
            output.Content.AppendHtml($"<h4>{Model.SubTitle}</h4>");
            output.Content.AppendHtml($"</br>");

            // take care of children
            Model.ParseChildren();
            foreach (SectionViewModel section in Model.Sections)
            {
                // Render the child (section) content
                context.Items["Section"] = section;
                TagHelperContent sectionContent = await output.GetChildContentAsync(false);
                output.Content.AppendHtml(sectionContent);
            }

        }
    }
}