using GameScore.BL.Interfaces;
using GameScore.DAL;
using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
			var user = _context.Users
					.Where(u => u.Name == username)
					.FirstOrDefault();

			var currentRateOfUser = _context.Rates
				.Include(r => r.User)
				.Where(r => r.GameId == rate.GameId 
					&& r.User.Name == username)
				.FirstOrDefault();

			rate.UserId = user.Id;
			rate.User = user;
			rate.Total = (rate.Graphics + rate.Gameplay + rate.Sound + rate.Narrative) / 4;

			if (currentRateOfUser == null)
			{
				_context.Rates.Add(rate);
			}
			else
			{
				currentRateOfUser.Graphics = rate.Graphics;
				currentRateOfUser.Gameplay = rate.Gameplay;
				currentRateOfUser.Sound = rate.Sound;
				currentRateOfUser.Narrative = rate.Narrative;
				currentRateOfUser.Total = rate.Total;
			}

			_context.SaveChanges();

			return rate;
		}

		public void UpdateGameScore(int gameId)
		{
			var score = new Score();

			var game = _context.Games
				.Where(g => g.Id == gameId)
				.Include(g => g.Score)
				.FirstOrDefault();
			
			var listOfRates = _context.Rates
				.Where(r => r.GameId == gameId);

			if (listOfRates != null)
			{
				score.Graphics = (float)listOfRates.Average(item => item.Graphics);
				score.Gameplay = (float)listOfRates.Average(item => item.Gameplay);
				score.Sound = (float)listOfRates.Average(item => item.Sound);
				score.Narrative = (float)listOfRates.Average(item => item.Narrative);
				score.Total = listOfRates.Average(item => item.Total);

				game.Score = score;
			}

			_context.SaveChanges();
		}
	}
}
