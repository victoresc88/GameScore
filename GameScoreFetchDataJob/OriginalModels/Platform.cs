﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.OriginalModels
{
   public class Platform
   {
      public int id { get; set; }
      public string name { get; set; }
      public string slug { get; set; }
      public object image { get; set; }
      public object year_end { get; set; }
      public object year_start { get; set; }
      public int games_count { get; set; }
      public string image_background { get; set; }
   }
}