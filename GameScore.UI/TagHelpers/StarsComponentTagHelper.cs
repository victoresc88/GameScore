using GameScore.BL.Interfaces;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameScore.UI.TagHelpers
{
	public class StarsComponentTagHelper : TagHelper
	{
		public float Score { get; set; }

		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			var content = new StringBuilder();

			for (var i = 0; i < 10; i++)
			{
				if (i < Score && (i + 1) > Score)
					content.Append("<span class='fas fa-star-half-alt'></span>");
				else if (i < Score)
					content.Append("<span class='fas fa-star'></span>");
				else
					content.Append("<span class='far fa-star'></span>");
			}

			output.TagName = "div";
			output.Attributes.SetAttribute("class", "stars");
			output.Content.SetHtmlContent(content.ToString());
		}
	}
}
