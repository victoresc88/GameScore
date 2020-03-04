using System.Collections.Generic;

namespace GameScoreFetchDataJob.OriginalModels
{
	public class OriginalGamePage
	{
      public int count { get; set; }
      public string next { get; set; }
      public object previous { get; set; }
      public List<OriginalGame> results { get; set; }
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
