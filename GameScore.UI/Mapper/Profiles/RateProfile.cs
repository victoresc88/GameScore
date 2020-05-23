using AutoMapper;
using GameScore.Entities;
using GameScore.UI.ViewModels;

namespace GameScore.UI.Mapper.Profiles
{
	public class RateProfile : Profile
	{
		public RateProfile()
		{
			CreateMap<RateViewModel, Rate>();
			CreateMap<Rate, RateViewModel>();
		}
	}
}
