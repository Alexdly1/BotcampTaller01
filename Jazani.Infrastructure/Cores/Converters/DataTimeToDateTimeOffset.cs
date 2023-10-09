using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Jazani.Infrastructure.Cores.Converters
{
    internal class DataTimeToDateTimeOffset : ValueConverter<DateTime, DateTimeOffset>
    {
        public DataTimeToDateTimeOffset() : base
            (
                dateTime => DateTimeOffset.UtcNow,
                dateTimeOffset => dateTimeOffset.DateTime
            )
        { }
    }
}
