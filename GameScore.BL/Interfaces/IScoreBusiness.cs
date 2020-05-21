using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.BL.Interfaces
{
	public interface IScoreBusiness
	{
		public Rate SetUserRates(Rate rate, string userName);
		public void UpdateGameScore(int gameId);
	}
}
