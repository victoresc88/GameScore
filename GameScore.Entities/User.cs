﻿using System.Collections.Generic;

namespace GameScore.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string GoogleId { get; set; }
		public List<Rate> Rates { get; set; }
	}
}
