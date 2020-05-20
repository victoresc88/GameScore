using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.Entities
{
	public class Rate
	{
		public int Id { get; set; }
		public int GameId { get; set; }
		public int Graphics { get; set; }
		public int Gameplay { get; set; }
		public int Sound { get; set; }
		public int Narrative { get; set; }
		public float Total { get; set; }
		public virtual User User { get; set; }
	}
}
