using AutoMapper;
using System;

namespace GameScore.UI.Mapper.Converters
{
	public class DatetimeToStringConverter : IValueConverter<DateTime, string>
	{
		public string Convert(DateTime sourceMember, ResolutionContext context)
		{
			if (sourceMember == DateTime.MinValue) 
				return string.Empty;
			else 
				return sourceMember.ToString("dd/MM/yyyy");
		}
	}
}
