using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace GameScore.Entities
{
	[Table("Platforms")]
	public class Platform
	{
		public int Id { get; set; }
		public int OriginalId { get; set; }
		public string Name { get; set; }
		public List<PlatformGame> PlatformGames { get; set; }
	}
}
