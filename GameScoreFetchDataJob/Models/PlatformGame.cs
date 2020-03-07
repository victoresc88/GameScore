using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.Models
{
    public class PlatformGame
    {
        public int Id { get; set; }
        public Game Game { get; set; }
        public Platform Platform { get; set; }
    }
}
