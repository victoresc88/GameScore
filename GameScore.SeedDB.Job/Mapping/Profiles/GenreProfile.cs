using AutoMapper;
using GameScore.EntityFramework.BL;
using GameScore.SeedDB.Job.Models;
using GameScore.SeedDB.Job.Models;

namespace GameScore.SeedDB.Job.Mapping.Profiles
{
	public class GenreProfile : Profile
	{
		public GenreProfile()
		{
			var configuration = new MapperConfiguration(cfg =>
			{
				CreateMap<GenreApi, Genre>()
					.ForMember(dto => dto.Id, opt => opt.Ignore())
					.ForMember(dto => dto.OriginalId, opt => opt.MapFrom(src => src.id))
					.ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.name));
			});
		}
	}
}
