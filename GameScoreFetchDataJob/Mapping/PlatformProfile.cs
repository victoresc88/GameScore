using AutoMapper;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.ApiModels;

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
