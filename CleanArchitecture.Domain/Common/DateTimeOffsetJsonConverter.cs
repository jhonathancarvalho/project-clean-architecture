using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Common
{
    public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
    {
        private readonly string _format;

        public DateTimeOffsetJsonConverter(string format)
        {
            _format = format;
        }

        public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            return DateTimeOffset.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
    }
}
