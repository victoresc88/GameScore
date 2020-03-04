using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GameScoreFetchDataJob.Repository
{
    public class GameScoreSeedContextFactory : IDesignTimeDbContextFactory<GameScoreSeedContext>
    {
        private static string _connectionString;

        public GameScoreSeedContext CreateDbContext()
        {
            return CreateDbContext(null);
        }

        public GameScoreSeedContext CreateDbContext(string[] args)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                LoadConnectionString();
            }

            var builder = new DbContextOptionsBuilder<GameScoreSeedContext>();
            builder.UseSqlServer(_connectionString);

            return new GameScoreSeedContext(builder.Options);
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
