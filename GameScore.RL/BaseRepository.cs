using GameScore.DAL;
using GameScore.RL.Interfaces;

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
		}

		public void Update(T entity)
		{
			_context.Set<T>().Update(entity);
		}
	}
}
