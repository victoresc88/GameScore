using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameScore.UI.TagHelpers
{
    public class PlatformListComponentTagHelper : TagHelper
    {
        private readonly IWrapperBusiness _wrapperBusiness;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public PlatformListComponentTagHelper(IWrapperBusiness wrapperBusiness)
        {
            _wrapperBusiness = wrapperBusiness;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();
            var listOfPlatforms = _wrapperBusiness.Platform.GetPlatforms();
            
            foreach (var platform in listOfPlatforms) { content.Append($"<li><a href='/Platform/Search/{platform.Id}'>{platform.Name}</a></li>"); }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
