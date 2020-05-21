using AutoMapper;
using GameScore.Entities;
using GameScore.UI.ViewModels;

namespace GameScore.UI.Mapper.Profiles
{
	public class ScoreProfile : Profile
	{
		public ScoreProfile()
		{
			CreateMap<RateViewModel, Rate>();
		}
	}
}
