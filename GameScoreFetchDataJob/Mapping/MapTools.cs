using AutoMapper;
using GameScoreFetchDataJob.ApiModels;
using GameScoreFetchDataJob.Mapping.Profiles;
using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Mapping
{
	public static class MapTools
	{
		public static Game MapApiGameToApplicationModel(GameApi gameApi)
		{
			var mapper = SetMapperConfiguration();

			return mapper.Map<GameApi, Game>(gameApi);
		}

		public static List<Platform> MapApiPlatformsToApplicationModels(List<PlatformsApi> platformApiList)
		{
			var mapper = SetMapperConfiguration();

			var platformList = new List<Platform>();

			foreach (var platformApi in platformApiList)
				platformList.Add(mapper.Map<PlatformApi, Platform>(platformApi.platform));

			return platformList;
		}

		public static List<Genre> MapApiGenresToApplicationModels(List<GenreApi> genreApiList)
		{
			var mapper = SetMapperConfiguration();

			var genreList = new List<Genre>();

			foreach (var genreApi in genreApiList)
				genreList.Add(mapper.Map<GenreApi, Genre>(genreApi));

			return genreList;
		}

		private static IMapper SetMapperConfiguration()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<GameProfile>();
				cfg.AddProfile<PlatformProfile>();
				cfg.AddProfile<GenreProfile>();
			});

			return config.CreateMapper();
		}
	}
}
