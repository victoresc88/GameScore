using System.ComponentModel.DataAnnotations.Schema;

namespace GameScoreFetchDataJob.Models
{
    [Table("Scores")]
    public class Score
    {
        public int Id { get; set; }
        public int Graphics { get; set; }
        public int Sound { get; set; }
        public int Gameplay { get; set; }
        public int Narrative { get; set; }
        public int Total { get; set; }
    }
}
