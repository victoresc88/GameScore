using System.ComponentModel.DataAnnotations.Schema;

namespace GameScoreFetchDataJob.Models
{
    [Table("Genres")]
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
