using GameScore.BL.Interfaces;
using GameScore.RL;
using GameScore.RL.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace GameScore.BL
{
	public static class ServiceExtensions
	{
		public static void ConfigureRepositoryWrapper(this IServiceCollection services)
		{
			services.AddScoped<IWrapperRepository, WrapperRepository>();
		}

		public static void ConfigureBusinessWrapper(this IServiceCollection services)
		{
			services.AddScoped<IWrapperBusiness, WrapperBusiness>();
		}
	}
}
