
namespace GameScore.SeedDbJob.Models
{
   public class StoresApi
   {
      public int id { get; set; }
      public StoreApi store { get; set; }
      public string url_en { get; set; }
      public string url_ru { get; set; }
   }
}
