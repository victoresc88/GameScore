
namespace GameScoreFetchDataJob.ApiModels
{
   public class PlatformsApi
   {
      public PlatformApi platform { get; set; }
      public string released_at { get; set; }
      public RequirementsEn requirements_en { get; set; }
      public RequirementsRu requirements_ru { get; set; }
   }
}
