using GameScoreFetchDataJob.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GameScoreFetchDataJob.Repository
{
    public class GameScoreSeedRepository : IGameScoreSeedRepository
    {
        public void SeedDB(IEnumerable<Game> gameList)
        {
			var context = new GameScoreSeedContextFactory().CreateDbContext();
			try
			{
				context.Database.OpenConnection();
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games ON");
				context.Games.AddRange(gameList);
				//context.SaveChanges();
				context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Games OFF");
			}
			finally
			{
				context.Database.CloseConnection();
			}
		}
    }
}
