using System.ComponentModel.DataAnnotations.Schema;

namespace GameScoreFetchDataJob.Models
{
    [Table("Platforms")]
    public class Platform
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
