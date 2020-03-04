using System.Collections.Generic;

namespace GameScoreFetchDataJob.OriginalModels
{
	public class OriginalGame
	{
      public int id { get; set; }
      public string slug { get; set; }
      public string name { get; set; }
      public string released { get; set; }
      public bool tba { get; set; }
      public string background_image { get; set; }
      public double rating { get; set; }
      public int rating_top { get; set; }
      public List<Rating> ratings { get; set; }
      public int ratings_count { get; set; }
      public int reviews_text_count { get; set; }
      public int added { get; set; }
      public AddedByStatus added_by_status { get; set; }
      public int? metacritic { get; set; }
      public int playtime { get; set; }
      public int suggestions_count { get; set; }
      public object user_game { get; set; }
      public int reviews_count { get; set; }
      public string saturated_color { get; set; }
      public string dominant_color { get; set; }
      public List<OriginalPlatforms> platforms { get; set; }
      public List<ParentPlatforms> parent_platforms { get; set; }
      public List<Genre> genres { get; set; }
      public List<Stores> stores { get; set; }
      public Clip clip { get; set; }
      public List<Tag> tags { get; set; }
      public List<ShortScreenshot> short_screenshots { get; set; }
   }
}
