using AutoMapper;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.RawgApiModels;

namespace GameScoreFetchDataJob.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<GameApi, Game>();

            ReplaceMemberName("id", "Id");
            ReplaceMemberName("name", "Name");
            ReplaceMemberName("platforms", "Platforms");
        }
    }
}
