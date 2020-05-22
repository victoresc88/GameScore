
namespace GameScore.RL.Interfaces
{
	public interface IWrapperRepository
	{
		IAccountRepository Account { get; }
		IGameRepository Game { get; }
		IRateRepository Rate { get; }
		IScoreRepository Score { get; }
		void Save();
	}
}
