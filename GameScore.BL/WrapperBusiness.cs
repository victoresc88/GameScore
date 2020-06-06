using GameScore.BL.Interfaces;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace GameScore.BL
{
	public class WrapperBusiness : IWrapperBusiness
	{
		private IWrapperRepository _wrapperRepository;
		private IMemoryCache _memoryCache;

		private IAccountBusiness _account;
		private IGameBusiness _game;
		private IScoreBusiness _score;
		private IRateBusiness _rate;
		private ICacheBusiness _cache;
		private IGenreBusiness _genre;
		private IPlatformBusiness _platform;

		public WrapperBusiness(IWrapperRepository wrapperRepository, IMemoryCache memoryCache)
		{
			_wrapperRepository = wrapperRepository;
			_memoryCache = memoryCache;
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

		public IRateBusiness Rate
		{
			get
			{
				if (_rate == null) { _rate = new RateBusiness(_wrapperRepository); }
				return _rate;
			}
		}

		public ICacheBusiness Cache
        {
			get
            {
				if (_cache == null) { _cache = new CacheBusiness(_memoryCache); }
				return _cache;
            }
        }

        public IGenreBusiness Genre
        {
			get
			{
				if (_genre == null) { _genre = new GenreBusiness(_wrapperRepository); }
				return _genre;
			}
		}

        public IPlatformBusiness Platform
        {
			get
			{
				if (_platform == null) { _platform = new PlatformBusiness(_wrapperRepository); }
				return _platform;
			}
		}
    }
}
