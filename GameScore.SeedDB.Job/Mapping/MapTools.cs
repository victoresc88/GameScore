using AutoMapper;
using GameScore.SeedDB.Job.Models;
using GameScore.SeedDB.Job.Mapping.Profiles;
using System.Collections.Generic;
using GameScore.EntityFramework.BL;

namespace GameScore.SeedDB.Job.Mapping
{
	public class MapTools
	{
		private IMapper m_mapper;

		public MapTools()
		{
			m_mapper = SetMapperConfiguration();
		}

		public Game MapApiGame(GameApi gameApi)
		{
			return m_mapper.Map<GameApi, Game>(gameApi);
		}

		public List<Platform> MapApiPlatforms(List<PlatformsApi> platformApiList)
		{
			var platformList = new List<Platform>();

			foreach (var platformApi in platformApiList)
				platformList.Add(m_mapper.Map<PlatformApi, Platform>(platformApi.platform));

			return platformList;
		}

		public List<Genre> MapApiGenres(List<GenreApi> genreApiList)
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
