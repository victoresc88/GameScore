using GameScore.BL.Interfaces;
using GameScore.DAL;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameScore.BL
{
	public class ScoreBusiness : IScoreBusiness
	{
		private readonly GameScoreDbContext _context;

		public ScoreBusiness()
		{
			_context = new GameScoreDbContextFactory().CreateDbContext();
		}

		public Rate SetUserRates(Rate rate, string username)
		{
			var userRate = _context.Rates.Where(r => r.GameId == rate.GameId 
														&& r.User.Name == username).FirstOrDefault();

			rate.User = _context.Users.Where(u => u.Name == username).FirstOrDefault();
			rate.Total = (rate.Graphics + rate.Gameplay + rate.Sound + rate.Narrative) / 4;

			if (userRate == null)
				_context.Rates.Add(rate);
			else
				userRate = rate;

			_context.SaveChanges();

			return rate;
		}

		public void UpdateGameScore(Rate rate)
		{
			var score = _context.Games
								.Where(g => g.Id == rate.GameId)
								.FirstOrDefault().Score?.FirstOrDefault();

			if (score != null)
			{
				score.Graphics = (score.Graphics + rate.Graphics) / 2;
				score.Gameplay = (score.Gameplay + rate.Gameplay) / 2;
				score.Sound = (score.Sound + rate.Sound) / 2;
				score.Narrative = (score.Narrative + rate.Narrative) / 2;
				score.Total = (score.Graphics + score.Gameplay + score.Sound + score.Narrative) / 4;
			}
			else
			{
				score = new Score();
				score.Graphics = rate.Graphics;
				score.Gameplay = rate.Gameplay;
				score.Sound = rate.Sound;
				score.Narrative = rate.Narrative;

				try
				{
					_context.Games
						.Where(g => g.Id == rate.GameId)
						.FirstOrDefault().Score = new List<Score>();
					_context.Games
						.Where(g => g.Id == rate.GameId)
						.FirstOrDefault().Score.Add(score);
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}		
			}

			_context.SaveChanges();
		}
	}
}
