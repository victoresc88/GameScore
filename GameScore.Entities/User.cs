using System;
using System.Collections.Generic;
using System.Text;

namespace GameScore.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Score> Scores{ get; set; }
    }
}
