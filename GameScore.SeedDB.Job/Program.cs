using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var gameScoreSeedBusiness = new GameScoreSeedBusiness();
			var gamePagesApiList = await gameScoreSeedBusiness.GetGamesAsyncData();
			
			gameScoreSeedBusiness.SeedApplicationDatabase(gamePagesApiList);
		}
	}
}
