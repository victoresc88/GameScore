using GameScore.DAL;
using GameScore.Entities;
using GameScore.RL.Interfaces;
using System.Collections.Generic;

namespace GameScore.RL
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(GameScoreDbContext context) : base(context)
        {
        }

        public IEnumerable<Genre> GetListOfGenres()
        {
            return _context.Genres;
        }
    }
}
