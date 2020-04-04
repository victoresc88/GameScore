using System;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameScore.SeedDbJob
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var xdoc = XDocument.Load($"{AppDomain.CurrentDomain.BaseDirectory}/seed_config.xml");
			var startPage = Int32.Parse(xdoc.Root.Element("StartPage").Value);
			var numberOfPages = Int32.Parse(xdoc.Root.Element("PageCounter").Value);

			var gameScoreSeedBusiness = new GameScoreSeedBusiness(startPage, numberOfPages);
			var pageList = await gameScoreSeedBusiness.GetGamesPageList();
			
			gameScoreSeedBusiness.SeedApplicationModels(pageList);
			gameScoreSeedBusiness.SeedData();

			xdoc.Root.Element("StartPage").SetValue(startPage + 500);
			xdoc.Save($"{AppDomain.CurrentDomain.BaseDirectory}/seed_config.xml");
		}
	}
}
