using AutoMapper;
using GameScore.Entities;
using GameScore.SeedDbJob.Models;

namespace GameScore.SeedDbJob.Mapping.Profiles
{
	public class PlatformProfile : Profile
	{
		public PlatformProfile()
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				CreateMap<PlatformApi, Platform>()
					.ForMember(dto => dto.Id, opt => opt.Ignore())
					.ForMember(dto => dto.OriginalId, opt => opt.MapFrom(src => src.id))
					.ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.name));
			});
		}
	}
}
