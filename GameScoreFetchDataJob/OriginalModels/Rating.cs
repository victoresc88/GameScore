using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.OriginalModels
{
   public class Rating
   {
      public int id { get; set; }
      public string title { get; set; }
      public int count { get; set; }
      public double percent { get; set; }
   }
}
