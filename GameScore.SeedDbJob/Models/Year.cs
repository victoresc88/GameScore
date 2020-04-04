
using System.Collections.Generic;

namespace GameScore.SeedDbJob.Models
{
	public class Year
	{
      public int from { get; set; }
      public int to { get; set; }
      public string filter { get; set; }
      public int decade { get; set; }
      public List<YearChild> years { get; set; }
      public bool nofollow { get; set; }
      public int count { get; set; }
   }
}
