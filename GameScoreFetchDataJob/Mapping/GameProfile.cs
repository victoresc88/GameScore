using AutoMapper;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.OriginalModels;

namespace GameScoreFetchDataJob.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<OriginalGame, Game>();

            ReplaceMemberName("id", "Id");
            ReplaceMemberName("name", "Name");
            ReplaceMemberName("platforms", "Platforms");
        }
    }
}
