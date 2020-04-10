using AutoMapper;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.UI.Mapper.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<Game, GameViewModel>();
        }
    }
}
