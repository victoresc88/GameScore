using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.Models
{
    public class GenreGame
    {
        public int Id { get; set; }
        public Genre Genre { get; set; }
        public Game Game { get; set; }
    }
}
