using System.Collections.Generic;

namespace GameScore.SeedDB.Job.Models
{
	public class GameApiPage
	{
      public int count { get; set; }
      public string next { get; set; }
      public object previous { get; set; }
      public List<GameApi> results { get; set; }
      public string seo_title { get; set; }
      public string seo_description { get; set; }
      public string seo_keywords { get; set; }
      public string seo_h1 { get; set; }
      public bool noindex { get; set; }
      public bool nofollow { get; set; }
      public string description { get; set; }
      public Filters filters { get; set; }
      public List<string> nofollow_collections { get; set; }
   }
}
