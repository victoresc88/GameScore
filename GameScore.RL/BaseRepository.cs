using GameScore.DAL;
using GameScore.RL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.RL
{
	public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
	{
		protected GameScoreDbContext _context;

		public BaseRepository(GameScoreDbContext context)
		{
			_context = context;
		}

		public void Create(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
			_context.SaveChanges();
		}
	}
}
