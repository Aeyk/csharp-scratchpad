using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/auth")]
public class AuthenticationController(KeycloakAuthenticationService _authenticationService) : ControllerBase {
    [HttpPost, Route("[action]")]
    public IActionResult Login([FromBody] AuthenticationRequest req) {
        return Ok(_authenticationService.Authenticate(req));
    }
}

public class KeycloakAuthenticationService(IHttpClientFactory _httpClientFactory, IConfiguration _config, ILogger<KeycloakAuthenticationService> _logger, JsonSerializerOptions _jsonSerializerOptions) {
  public record AuthenticationResponse {
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error")]
    public String? Status {get; set;} = null;

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("error_description")]
    public String? Message { get; set;} = null;
    
    [JsonPropertyName("access_token")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

    public string? AccessToken {get; set;} = null;
    
    [JsonPropertyName("expires_in")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    // [JsonConverter(typeof(DateTimeOffsetConverter))]
    // public DateTimeOffset? Expiry {get; set;} = null;
    public int Expiry {get; set;} = 60;

    [JsonConverter(typeof(SplitStringConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scopes {get; set;} = null;
    
  }
  public AuthenticationResponse Authenticate(AuthenticationRequest req) {
    using var client = _httpClientFactory.CreateClient();
    var postData = new FormUrlEncodedContent(new Dictionary<string, string> {
        { "client_id",  _config["OIDC:ClientId"] },
        { "client_secret",  _config["OIDC:ClientSecret"] },
        { "grant_type",  "password" },
        { "username",  req.Username },
        { "password",  req.Password }
    });
    var result = client.PostAsync($"{_config["OIDC:Authority"]}/protocol/openid-connect/token", postData).GetAwaiter().GetResult().Content;
    _logger.LogCritical(result.ReadAsStringAsync().GetAwaiter().GetResult());
    var jsonString = JsonDocument.Parse(result.ReadAsStringAsync().GetAwaiter().GetResult());
    var json = JsonSerializer.Deserialize<AuthenticationResponse>(jsonString, _jsonSerializerOptions);
    return json;
  }
}

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

public class AuthenticationService {
    public bool Authenticate(AuthenticationRequest req) {
      if(req.Username == "me" && req.Password == "") {
        return true;
      }
      return false;
    }
}

public class AuthenticationRequest
{
    [JsonPropertyName("username")]
    [DefaultValue("me")]
    public required string Username {get; set;}

    [JsonPropertyName("password")]
    [DefaultValue("********")]
    public required string Password { get; set;}
}

public class AuthenticationResponse {
    [JsonPropertyName("status")]
    public required string Status {get; set;}

    [JsonPropertyName("message")]
    public required string Message { get; set;}
}