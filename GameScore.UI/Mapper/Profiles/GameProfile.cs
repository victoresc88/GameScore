using AutoMapper;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameScore.UI.Mapper.Converters;

namespace GameScore.UI.Mapper.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>();
            CreateMap<Game, GameDetailsViewModel>()
                .ForMember(dto => dto.ReleaseDate, opt => 
                    opt.ConvertUsing(new DatetimeToStringConverter(), src => src.ReleaseDate));
        }
    }
}
