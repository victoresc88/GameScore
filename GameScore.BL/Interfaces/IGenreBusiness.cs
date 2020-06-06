using GameScore.Entities;
using System.Collections.Generic;

namespace GameScore.BL.Interfaces
{
    public interface IGenreBusiness
    {
        public IEnumerable<Genre> GetListOfGenres();
    }
}
