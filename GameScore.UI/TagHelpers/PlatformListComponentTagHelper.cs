using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace GameScore.UI.TagHelpers
{
    public class PlatformListComponentTagHelper : TagHelper
    {
        private readonly IWrapperBusiness _wrapperBusiness;

        public PlatformListComponentTagHelper(IWrapperBusiness wrapperBusiness)
        {
            _wrapperBusiness = wrapperBusiness;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();
            
            var listOfPlatforms = _wrapperBusiness.Platform.GetListOfPlatforms();
            foreach(var platform in listOfPlatforms)
            {
                content.Append($"<li><a href='#'>{platform.Name}</a></li>");
            }

            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
