using AutoMapper;
using GameScoreFetchDataJob.Models;
using GameScoreFetchDataJob.OriginalModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameScoreFetchDataJob.Mapping
{
    public class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<OriginalPlatform, Platform>();

            ReplaceMemberName("id", "Id");
            ReplaceMemberName("name", "Name");
        }
    }
}
