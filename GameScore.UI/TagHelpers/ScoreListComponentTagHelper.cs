using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace GameScore.UI.TagHelpers
{
    public class ScoreListComponentTagHelper : TagHelper
    {
        //ToDo: Get score types from DB

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();

            content.Append("<li><a href='#'>Graphics</a></li>");
            content.Append("<li><a href='#'>Gameplay</a></li>");
            content.Append("<li><a href='#'>Sound</a></li>");
            content.Append("<li><a href='#'>Narrative</a></li>");

            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
