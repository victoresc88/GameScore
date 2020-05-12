using GameScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.UI.ViewModels
{
    public class GameDetailsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReleaseDate { get; set; }
        public int PlayTime { get; set; }
        public int Metacritic { get; set; }
        public string ImageUrl { get; set; }
        public Score Score { get; set; }
    }
}
