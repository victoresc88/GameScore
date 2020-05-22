using GameScore.DAL;
using GameScore.RL.Interfaces;

namespace GameScore.RL
{
	public class WrapperRepository : IWrapperRepository
	{
		private GameScoreDbContext _context;

		private IAccountRepository _account;
		private IGameRepository _game;
		private IRateRepository _rate;
		private IScoreRepository _score;

		public WrapperRepository()
		{
			_context = new GameScoreDbContextFactory().CreateDbContext();
		}

		public IAccountRepository Account {
			get
			{
				if (_account == null) { _account = new AccountRepository(_context); }
				return _account;
			}
		}

		public IGameRepository Game
		{
			get
			{
				if (_game == null) { _game = new GameRepository(_context); }
				return _game;
			}
		}

		public IRateRepository Rate
		{
			get
			{
				if (_rate == null) { _rate = new RateRepository(_context); }
				return _rate;
			}
		}

		public IScoreRepository Score
		{
			get
			{
				if (_score == null) { _score = new ScoreRepository(_context); }
				return _score;
			}
		}

		public void Save()
		{
			_context.SaveChanges();
		}
	}
}
