using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.Entities
{
	public class PlatformGame
	{
		public int GameId { get; set; }
		public Game Game { get; set; }
		public int PlatformId { get; set; }
		public Platform Platform { get; set; }
	}
}
