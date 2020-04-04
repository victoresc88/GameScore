using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GameScore.DAL
{
	public class GameScoreDbContextFactory : IDesignTimeDbContextFactory<GameScoreDbContext>
	{
		private static string _connectionString;

		public GameScoreDbContext CreateDbContext()
		{
			return CreateDbContext(null);
		}

		public GameScoreDbContext CreateDbContext(string[] args)
		{
			if (string.IsNullOrEmpty(_connectionString))
			{
				LoadConnectionString();
			}

			var builder = new DbContextOptionsBuilder<GameScoreDbContext>();
			builder.UseSqlServer(_connectionString);

			return new GameScoreDbContext(builder.Options);
		}

		private static void LoadConnectionString()
		{
			var builder = new ConfigurationBuilder();
			builder.AddJsonFile("appsettings.json", optional: false);

			var configuration = builder.Build();

			_connectionString = configuration.GetConnectionString("DefaultConnection");
		}
	}
}
