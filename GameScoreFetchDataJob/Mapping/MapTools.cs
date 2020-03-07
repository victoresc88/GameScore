using AutoMapper;
using GameScoreFetchDataJob.ApiModels;
using GameScoreFetchDataJob.Mapping.Profiles;
using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Mapping
{
    public static class MapTools
    {
		public static IEnumerable<Game> MapApiModelsToApplicationModels(List<GameApi> gameApiList)
		{
			var mapper = SetMapperConfiguration();
			var gameList = new List<Game>();

			foreach (var gameApi in gameApiList)
			{
				var game = MapApiGameToGameModel(gameApi, mapper);
				game.Platforms = MapApiPlatformsToPlatformModels(gameApi.platforms, game, mapper);
				game.Genres = MapApiGenreToGenreModels(gameApi.genres, game, mapper);

				gameList.Add(game);
			}
			
			return gameList;
		}

		private static Game MapApiGameToGameModel(GameApi gameApi, IMapper mapper)
		{
			return mapper.Map<GameApi, Game>(gameApi);
		}

		private static List<PlatformGame> MapApiPlatformsToPlatformModels(List<PlatformsApi> platformApiList, Game game, IMapper mapper)
		{
			var platformGameList = new List<PlatformGame>();

			foreach (var platformApi in platformApiList)
			{
				platformGameList.Add(new PlatformGame() {
					Game = game,
					Platform = mapper.Map<PlatformApi, Platform>(platformApi.platform)
				});
			}

			return platformGameList;
		}

		private static List<GenreGame> MapApiGenreToGenreModels(List<GenreApi> genreApiList, Game game, IMapper mapper)
		{
			var genreGameList = new List<GenreGame>();
			foreach (var genreApi in genreApiList)
			{		
				genreGameList.Add(new GenreGame()
				{
					Game = game,
					Genre = mapper.Map<GenreApi, Genre>(genreApi)
				});
			}

			return genreGameList;
		}

		private static IMapper SetMapperConfiguration()
		{
			var config = new MapperConfiguration(cfg => {
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<PlatformProfile>();
				cfg.AddProfile<GenreProfile>();
			});
			
			return config.CreateMapper();
		}
	}
}
