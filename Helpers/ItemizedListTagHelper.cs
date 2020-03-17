using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using XmlToHtml.Models;

namespace XmlToHtml.Helpers
{
    [HtmlTargetElement("itemized-list")]
    [RestrictChildren("list-item")]
    public class ItemizedListTagHelper : TagHelper
    {
        public override async void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagMode = TagMode.StartTagAndEndTag;
            output.TagName = "ul";
            // output.Content.AppendHtml("<br/>");

            var list = context.Items["List"] as ListViewModel;
            // take care of children
            list.ParseChildren();
            foreach (ListItemViewModel item in list.ListItems)
            {
                ListItemTagHelper tagHelper = new ListItemTagHelper();
                TagHelperOutput listItemOutput = new TagHelperOutput(
                    tagName: "li",
                    attributes: new TagHelperAttributeList(),
                    getChildContentAsync: (useCachedResult, encoder) => Task.Factory.StartNew<TagHelperContent>(() => new DefaultTagHelperContent())
                );
                // Render the child (list-item) content
                context.Items["ListItem"] = item;
                tagHelper.Process(context, listItemOutput);
                var listItemContent = $@"<{listItemOutput.TagName}>{listItemOutput.Content.GetContent()}</{listItemOutput.TagName}>";
                output.Content.AppendHtml(listItemContent);
            }
        }
    }
}