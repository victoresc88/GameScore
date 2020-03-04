using AutoMapper;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.RawgApiModels;

namespace GameScoreFetchDataJob.Mapping
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<PlatformApi, Platform>();

            ReplaceMemberName("id", "Id");
            ReplaceMemberName("name", "Name");
        }
    }
}
