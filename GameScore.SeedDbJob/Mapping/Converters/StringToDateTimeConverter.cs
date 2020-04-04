using AutoMapper;
using System;

namespace GameScore.SeedDbJob.Mapping.Converters
{
    public class StringToDateTimeConverter : IValueConverter<string, DateTime>
    {
        public DateTime Convert(string sourceMember, ResolutionContext context)
        {
            DateTime dateTime;

            if (string.IsNullOrEmpty(sourceMember)) return default(DateTime);
            if (DateTime.TryParse(sourceMember, out dateTime)) return dateTime;

            return default(DateTime);
        }
    }
}
