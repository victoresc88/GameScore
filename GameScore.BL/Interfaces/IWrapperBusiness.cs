using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL.Interfaces
{
	public interface IWrapperBusiness
	{
		public IAccountBusiness Account { get; }
		public IGameBusiness Game { get; }
		public IScoreBusiness Score { get; }
	}
}
