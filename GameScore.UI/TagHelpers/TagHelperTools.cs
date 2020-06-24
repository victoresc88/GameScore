using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameScore.UI.TagHelpers
{
    public static class TagHelperTools
    {
        public static TagHelperContext CreateTagHelperContext(string action, string controller, int routeValue)
        {
            var tagHelperContext = new TagHelperContext(
                    new TagHelperAttributeList(
                        new[] {
                            new TagHelperAttribute("asp-action", new HtmlString(action)),
                            new TagHelperAttribute("asp-controller", new HtmlString(controller)),
                            new TagHelperAttribute("asp-route-id", new HtmlString(routeValue.ToString()))
                        }
                    ),
                    new Dictionary<object, object>(),
                    Guid.NewGuid().ToString()
                );

            return tagHelperContext;
        }

        public static TagHelperOutput CreateTagHelperOutput(string htmlTag)
        {
            var tagHelperOutput = new TagHelperOutput(htmlTag,
                    new TagHelperAttributeList(),
                    (useCachedResult, encoder) => Task.Factory.StartNew<TagHelperContent>(() => new DefaultTagHelperContent())
                );

            return tagHelperOutput;
        }
    }
}
