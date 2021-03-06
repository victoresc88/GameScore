﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameScore.Entities
{
	[Table("Genres")]
	public class Genre
	{
		public int Id { get; set; }
		public int OriginalId { get; set; }
		public string Name { get; set; }
		public List<GenreGame> GenreGames { get; set; }
	}
}
