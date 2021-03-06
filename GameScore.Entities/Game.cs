﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameScore.Entities
{
	[Table("Games")]
	public class Game
	{
		public int Id { get; set; }
		public int OriginalId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int PlayTime { get; set; }
		public int Metacritic { get; set; }
		public string ImageUrl { get; set; }
		public Score Score { get; set; }
		public List<PlatformGame> PlatformGames { get; set; }
		public List<GenreGame> GenreGames { get; set; }
	}
}
