using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Repository
{
	public interface IGameScoreSeedRepository
	{
		public void AddGames(List<Game> gameList);
		public void AddPlatforms(List<Platform> platformList);
		public void AddGenres(List<Genre> genreList);
		public void AddPlatformGames(List<PlatformGame> platformGameList);
		public void AddGenreGames(List<GenreGame> genreGameList);
	}
}
