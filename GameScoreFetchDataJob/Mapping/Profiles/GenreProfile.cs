using AutoMapper;
using GameScoreFetchDataJob.ApiModels;
using GameScoreFetchDataJob.Models;

namespace GameScoreFetchDataJob.Mapping.Profiles
{
    public class GenreProfile : Profile
    {
        public GenreProfile()
        {
            var configuration = new MapperConfiguration(cfg => {
                CreateMap<GenreApi, Genre>()
                    .ForMember(dto => dto.OriginalId, opt => opt.MapFrom(src => src.id))
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.name));
            });
        }
    }
}
