
// TODO
using System.Text.Json;
using System.Text.Json.Serialization;

class DateTimeOffsetConverter : JsonConverter<DateTimeOffset>
{
  private static readonly DateTimeOffset Epoch = new DateTimeOffset().LocalDateTime;
  public override DateTimeOffset Read(ref Utf8JsonReader reader, System.Type typeToConvert, JsonSerializerOptions options)
  {
    var delta = reader.GetInt64();
    try
    {
      return DateTimeOffset.Now.AddSeconds(delta);
    } catch (System.ArgumentOutOfRangeException){
      return DateTimeOffset.Now;
    }
  }
  public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
  {
    long delta;
    var now = new DateTimeOffset().LocalDateTime;

     if(default == value) {
      var now0 = TimeZoneInfo.ConvertTime(now, TimeZoneInfo.Local);
      var value0 = value.LocalDateTime;
       writer.WriteStringValue(now0 + now0.Subtract(value0));
     } else {
      writer.WriteStringValue(value);
    }
  }
}

