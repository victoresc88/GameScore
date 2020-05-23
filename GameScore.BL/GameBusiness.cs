using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.BL
{
	public class GameBusiness : IGameBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

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
	}
}
