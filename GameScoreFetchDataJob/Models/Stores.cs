using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.Models
{
   public class Stores
   {
      public int id { get; set; }
      public Store store { get; set; }
      public string url_en { get; set; }
      public string url_ru { get; set; }
   }
}
