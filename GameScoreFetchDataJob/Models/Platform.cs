using System.ComponentModel.DataAnnotations.Schema;

namespace GameScoreFetchDataJob.Models
{
	[Table("Platforms")]
	public class Platform
	{
		public int Id { get; set; }
		public int OriginalId { get; set; }
		public string Name { get; set; }
	}
}
