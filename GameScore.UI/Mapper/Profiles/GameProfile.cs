using AutoMapper;
using GameScore.Entities;
using GameScore.UI.ViewModels;
using GameScore.UI.Mapper.Converters;
using System.Collections.Generic;

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
