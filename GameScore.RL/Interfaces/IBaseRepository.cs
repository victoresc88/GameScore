using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.RL.Interfaces
{
	public interface IBaseRepository<T>
	{
		void Create(T entity);
		void Update(T entity);
	}
}
