using System;
using System.Collections.Generic;
using System.Text;

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
