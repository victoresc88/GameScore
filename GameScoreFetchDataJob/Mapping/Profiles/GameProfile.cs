using AutoMapper;
using GameScoreFetchDataJob.Mapping.Converters;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.ApiModels;

namespace GameScoreFetchDataJob.Mapping.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            var configuration = new MapperConfiguration(cfg => {
                CreateMap<GameApi, Game>()
                    .ForMember(dto => dto.Id, opt => opt.Ignore())
                    .ForMember(dto => dto.OriginalId, opt => opt.MapFrom(src => src.id))
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.name))
                    .ForMember(dto => dto.Description, opt => opt.Ignore())
                    .ForMember(dto => dto.ReleaseDate, opt => opt.ConvertUsing(new StringToDateTimeConverter(), src => src.released))
                    .ForMember(dto => dto.PlayTime, opt => opt.MapFrom(src => src.playtime))
                    .ForMember(dto => dto.Metacritic, opt => opt.MapFrom(src => src.metacritic))
                    .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(src => src.background_image))
                    .ForMember(dto => dto.Score, opt => opt.Ignore());
            });
        }
    }
}
