using GameScore.BL.Interfaces;
using GameScore.RL.Interfaces;

namespace GameScore.BL
{
	public class WrapperBusiness : IWrapperBusiness
	{
		private IWrapperRepository _wrapperRepository;

		private IAccountBusiness _account;
		private IGameBusiness _game;
		private IScoreBusiness _score;

		public WrapperBusiness(IWrapperRepository wrapperRepository)
		{
			_wrapperRepository = wrapperRepository;
		}

		public IAccountBusiness Account
		{
			get
			{
				if (_account == null) { _account = new AccountBusiness(_wrapperRepository); }
				return _account;
			}
		}

		public IGameBusiness Game
		{
			get
			{
				if (_game == null) { _game = new GameBusiness(_wrapperRepository); }
				return _game;
			}
		}

		public IScoreBusiness Score
		{
			get
			{
				if (_score == null) { _score = new ScoreBusiness(_wrapperRepository); }
				return _score;
			}
		}
	}
}
