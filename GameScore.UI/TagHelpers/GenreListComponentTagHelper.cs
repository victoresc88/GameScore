using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace GameScore.UI.TagHelpers
{
    public class GenreListComponentTagHelper : TagHelper
    {
        private readonly IWrapperBusiness _wrapperBusiness;

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public GenreListComponentTagHelper(IWrapperBusiness wrapperBusiness)
        {
            _wrapperBusiness = wrapperBusiness;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();
            var listOfGenres = _wrapperBusiness.Genre.GetGenres();
            
            foreach (var genre in listOfGenres) { content.Append($"<li><a href='/Genre/Search/{genre.Id}'>{genre.Name}</a></li>"); }
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}
