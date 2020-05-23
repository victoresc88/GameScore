using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.BL
{
	public class HomeBusiness : IHomeBusiness
	{
		private readonly IWrapperRepository _wrapperRepository;

		public HomeBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public IEnumerable<Game> GetAllGames()
		{
			return _wrapperRepository.Game.GetListOfGames();
		}
	}
}
