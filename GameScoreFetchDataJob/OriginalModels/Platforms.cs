using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.OriginalModels
{
   public class Platforms
   {
      public Platform platform { get; set; }
      public string released_at { get; set; }
      public RequirementsEn requirements_en { get; set; }
      public RequirementsRu requirements_ru { get; set; }
   }
}
