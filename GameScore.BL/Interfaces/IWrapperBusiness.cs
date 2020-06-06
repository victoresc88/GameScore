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
		public IRateBusiness Rate { get; }
		public ICacheBusiness Cache { get; }
		public IGenreBusiness Genre { get; }
		public IPlatformBusiness Platform { get; }
	}
}
