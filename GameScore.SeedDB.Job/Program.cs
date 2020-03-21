using System.Threading.Tasks;

namespace GameScore.SeedDB.Job
{
	class Program
	{
		private const int NUMBER_OF_PAGES = 5000;

		static async Task Main(string[] args)
		{
			var gameScoreSeedBusiness = new GameScoreSeedBusiness();
			
			var pageList = await gameScoreSeedBusiness.GetGamesPageList(NUMBER_OF_PAGES);
			gameScoreSeedBusiness.SeedApplicationModels(pageList);
		}
	}
}
