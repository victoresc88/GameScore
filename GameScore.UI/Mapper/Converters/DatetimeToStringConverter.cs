using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameScore.UI.Mapper.Converters
{
    public class DatetimeToStringConverter : IValueConverter<DateTime, string>
    {
        public string Convert(DateTime sourceMember, ResolutionContext context)
        {
            if (sourceMember == DateTime.MinValue) return string.Empty;
            else return sourceMember.ToString("dd/MM/yyyy");
        }
    }
}
