using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("list-item")]
    public class ListItemTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "li";
            var listItem = context.Items["ListItem"] as ListItemViewModel;
            output.Content.AppendHtml($"{listItem.Paragraph}");
            listItem.ParseChildren();
            foreach (var list in listItem.Lists)
            {
                ItemizedListTagHelper tagHelper = new ItemizedListTagHelper();
                TagHelperOutput listOutput = new TagHelperOutput(
                    tagName: "ul",
                    attributes: new TagHelperAttributeList(),
                    getChildContentAsync: (useCachedResult, encoder) => Task.Factory.StartNew<TagHelperContent>(() => new DefaultTagHelperContent())
                );
                // Render the child (section) content
                context.Items["List"] = list;
                tagHelper.Process(context, listOutput);
                var listContent = $@"<{listOutput.TagName}>{listOutput.Content.GetContent()}</{listOutput.TagName}>";
                output.Content.AppendHtml(listContent);
            }
        }
    }
}