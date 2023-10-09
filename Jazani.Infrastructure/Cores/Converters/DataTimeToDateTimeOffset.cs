using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Cores.Converters
{
    public class DataTimeToDateTimeOffset : ValueConverter<DateTime, DateTimeOffset>
    {
        public DataTimeToDateTimeOffset() : base
            (
                dateTime => DateTimeOffset.UtcNow,
                dateTimeOffset => dateTimeOffset.DateTime
            )
        { }
    }
}
