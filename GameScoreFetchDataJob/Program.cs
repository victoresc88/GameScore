using System.Threading.Tasks;

namespace GameScoreFetchDataJob
{
	class Program
	{
		static async Task Main(string[] args)
		{
			var fetchDataManager = new FetchDataManager();
			var gamePagesApiList = await fetchDataManager.GetGamesAsyncData();
			
			fetchDataManager.SeedGameScoreDatabase(gamePagesApiList);
		}
	}
}
