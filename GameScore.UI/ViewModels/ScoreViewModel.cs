
namespace GameScore.UI.ViewModels
{
	public class ScoreViewModel
	{
		public string GameId { get; set; }
		public float Graphics { get; set; }
		public string GraphicsProgress { get; set; }
		public float Gameplay { get; set; }
		public string GameplayProgress { get; set; }
		public float Sound { get; set; }
		public string SoundProgress { get; set; }
		public float Narrative { get; set; }
		public string NarrativeProgress { get; set; }
		public float Total { get; set; }
		public int NumberOfRates { get; set; }
	}
}
