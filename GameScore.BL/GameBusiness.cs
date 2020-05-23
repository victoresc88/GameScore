using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;

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
	}
}
