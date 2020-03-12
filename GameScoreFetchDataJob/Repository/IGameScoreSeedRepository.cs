using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Repository
{
	public interface IGameScoreSeedRepository
	{
		public void AddGame(Game game);
		public void AddPlatformGame(List<Platform> platform, Game game);
		public void AddGenreGame(List<Genre> genre, Game game);
	}
}
