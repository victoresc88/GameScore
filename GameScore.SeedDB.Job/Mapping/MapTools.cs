using AutoMapper;
using GameScoreFetchDataJob.ApiModels;
using GameScoreFetchDataJob.Mapping.Profiles;
using GameScoreFetchDataJob.Models;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Mapping
{
	public class MapTools
	{
		private IMapper m_mapper;

		public MapTools()
		{
			m_mapper = SetMapperConfiguration();
		}

		public Game MapApiGameToApplicationModel(GameApi gameApi)
		{
			return m_mapper.Map<GameApi, Game>(gameApi);
		}

		public List<Platform> MapApiPlatformsToApplicationModels(List<PlatformsApi> platformApiList)
		{
			var platformList = new List<Platform>();

			foreach (var platformApi in platformApiList)
				platformList.Add(m_mapper.Map<PlatformApi, Platform>(platformApi.platform));

			return platformList;
		}

		public List<Genre> MapApiGenresToApplicationModels(List<GenreApi> genreApiList)
		{
			var genreList = new List<Genre>();

			foreach (var genreApi in genreApiList)
				genreList.Add(m_mapper.Map<GenreApi, Genre>(genreApi));

			return genreList;
		}

		private IMapper SetMapperConfiguration()
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
