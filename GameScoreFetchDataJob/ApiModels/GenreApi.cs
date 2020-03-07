
namespace GameScoreFetchDataJob.ApiModels
{
   public class GenreApi
   {
      public int id { get; set; }
      public string name { get; set; }
      public string slug { get; set; }
      public int games_count { get; set; }
      public string image_background { get; set; }
   }
}
