
namespace GameScore.RL.Interfaces
{
	public interface IBaseRepository<T>
	{
		public void Create(T entity);
		public void Update(T entity);
	}
}
