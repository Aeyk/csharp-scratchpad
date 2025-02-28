using System.Text.Json;
using System.Text.Json.Serialization;

public class SplitStringConverter : JsonConverter<IEnumerable<string>>
{
    public override IEnumerable<string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetString().Split(" ");
    }

    public override void Write(Utf8JsonWriter writer, IEnumerable<string> value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(string.Join(" ", value));
    }
}