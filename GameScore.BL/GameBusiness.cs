using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace GameScore.BL
{
	public class GameBusiness : IGameBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public const int ITEMS_PER_PAGE = 20;

		public GameBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public Game GetGameById(int id)
		{
			return _wrapperRepository.Game.GetGameById(id);
		}

		public IEnumerable<Game> GetListOfGames()
		{
			return _wrapperRepository.Game.GetListOfGames();
		}

		public Dictionary<int, Game> GetGamesByIndexForPage(Dictionary<int, Game> gamesByIndex, int numberOfPage)
		{
			var indexFrom = numberOfPage * ITEMS_PER_PAGE;
			var indexTo = indexFrom + ITEMS_PER_PAGE;

			return gamesByIndex
				.Where(g => g.Key > indexFrom && g.Key <= indexTo)
				.ToDictionary(g => g.Key, g => g.Value);
		}
    }
}
