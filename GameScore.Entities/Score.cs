﻿
namespace GameScore.Entities
{
	public class Score
	{
		public int Id { get; set; }
		public int GameId { get; set; }
		public float Graphics { get; set; }
		public float Gameplay { get; set; }
		public float Sound { get; set; }
		public float Narrative { get; set; }
		public float Total { get; set; }
	}
}
