
namespace GameScore.RL.Interfaces
{
	public interface IWrapperRepository
	{
		public IAccountRepository Account { get; }
		public IGameRepository Game { get; }
		public IRateRepository Rate { get; }
		public IScoreRepository Score { get; }
		public IGenreRepository Genre { get; }
		public IPlatformRepository Platform { get; }
		public void Save();
	}
}
