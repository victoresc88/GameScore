using System.ComponentModel.DataAnnotations.Schema;

namespace GameScore.EntityFramework.BL
{
	[Table("Genres")]
	public class Genre
	{
		public int Id { get; set; }
		public int OriginalId { get; set; }
		public string Name { get; set; }
	}
}
