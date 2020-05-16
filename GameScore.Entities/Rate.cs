using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.Entities
{
	public class Rate
	{
		public int Id { get; set; }
		public int Graphics { get; set; }
		public int Gameplay { get; set; }
		public int Sound { get; set; }
		public int Narrative { get; set; }
		public int Total { get; set; }
		public User User { get; set; }
	}
}
