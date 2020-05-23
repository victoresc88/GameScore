
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GameScore.UI.ViewModels
{
	public class RateViewModel
	{
		public string GameId { get; set; }
		public string Graphics { get; set; }
		public string Gameplay { get; set; }
		public string Sound { get; set; }
		public string Narrative { get; set; }
		public List<SelectListItem> Grades {get;set;}
	}
}
