using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.RL.Interfaces
{
    public interface IGenreRepository
    {
        public IEnumerable<Genre> GetGenres();
    }
}
