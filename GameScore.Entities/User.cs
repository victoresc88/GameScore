using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.Entities
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Password { get; set; }
		public string GoogleId { get; set; }
		public ICollection<Rate> Rates { get; set; }
	}
}
