using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace PilotProject.Services
{
    internal class DateTimeConverterService : JsonConverter<DateTime>
    {
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString() ?? string.Empty, "MM/dd/yyyy HH:mm:ss UTC", new CultureInfo("be-BY"));
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("MM/dd/yyyy HH:mm:ss UTC", new CultureInfo("be-BY")));
        }
    }
}