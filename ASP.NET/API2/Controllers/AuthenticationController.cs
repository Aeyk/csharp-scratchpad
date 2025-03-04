using System.ComponentModel;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using Keycloak.AuthServices.Sdk.Admin;
using Keycloak.AuthServices.Sdk.Admin.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/v1/auth/[action]")]
public class AuthenticationController(KeycloakAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost]
    public Task<KeycloakAuthenticationService.AuthenticationResponse> LoginAsync([FromBody] AuthenticationRequest req)
    {
        return _authenticationService.AuthenticateAsync(req);
    }

    [HttpGet]
    [Authorize]
    public IActionResult Info()
    {
        Request.Headers.TryGetValue("Authorization", out var temp);
        var jwt = temp.FirstOrDefault().Split(' ')[1];
        if(null == jwt) return BadRequest(KeycloakAuthenticationService.Unauthenticated);
        return Ok(_authenticationService.UserInfo(new JwtSecurityToken(jwt)));
    }
}

public class KeycloakAuthenticationService(IHttpClientFactory _httpClientFactory, IConfiguration _config, ILogger<KeycloakAuthenticationService> _logger, JsonSerializerOptions _jsonSerializerOptions)
{
    public static AuthenticationResponse Unauthenticated = new AuthenticationResponse {
        Status = "error", Message = "Unable to sign in. Check username and password. "
    };
    private AuthenticationResponse token;
    public record AuthenticationResponse
    {
        public AuthenticationResponse() {
            ExpiresAt = DateTime.Now.AddSeconds(Expiry);
        }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("error")]
        public String? Status { get; set; } = null;

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("error_description")]
        public String? Message { get; set; } = null;

        [JsonPropertyName("access_token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public string? AccessToken { get; set; } = null;

        [JsonPropertyName("refresh_token")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? RefreshToken{ get; set; } = null;

        [JsonPropertyName("expires_in")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        // [JsonConverter(typeof(DateTimeOffsetConverter))]
        // public DateTimeOffset? Expiry {get; set;} = null;
        public int Expiry { get; set; } = 0;

        [JsonIgnore]
        public DateTimeOffset ExpiresAt { get; set; }

        [JsonConverter(typeof(SplitStringConverter))]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [JsonPropertyName("scope")]
        public IEnumerable<string>? Scopes { get; set; } = null;

    }
    public async Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest req)
    {
        using var client = _httpClientFactory.CreateClient(Constants.KeycloakUserClient);
        var postData = new FormUrlEncodedContent(new Dictionary<string, string> {
            { "client_id",  _config["OIDC:ClientId"] },
            { "client_secret",  _config["OIDC:ClientSecret"] },
            { "scopes",  "openid" },
            { "grant_type",  "password" },
            { "username",  req.Username },
            { "password",  req.Password }
        });
        var result = client.PostAsync($"{_config["OIDC:Authority"]}/protocol/openid-connect/token", postData).GetAwaiter().GetResult().Content;
        var jsonString = JsonDocument.Parse(result.ReadAsStringAsync().GetAwaiter().GetResult());
        var json = JsonSerializer.Deserialize<AuthenticationResponse>(jsonString, _jsonSerializerOptions);
        if(json == null || json.AccessToken == null) return Unauthenticated;
        token = json;
        return json;
    }

    public object UserInfo(JwtSecurityToken jwt)
    {
        // if(jwt == null || token.ExpiresAt >= DateTimeOffset.Now) return Unauthenticated;
        using var client = _httpClientFactory.CreateClient(Constants.KeycloakUserClient);
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", jwt.RawData);
        var result = client.GetAsync($"{_config["OIDC:Authority"]}/protocol/openid-connect/userinfo").GetAwaiter().GetResult().Content.ReadAsStringAsync().GetAwaiter().GetResult();
        _logger.LogTrace(result);
        return result;
    }
}

public class AuthenticationRequest
{
    [JsonPropertyName("username")]
    [DefaultValue("me")]
    public required string Username { get; set; }

    [JsonPropertyName("password")]
    [DefaultValue("********")]
    public required string Password { get; set; }
}

public class AuthenticationResponse
{
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    [JsonPropertyName("message")]
    public required string Message { get; set; }
}

[Route("api/v1/user/[action]")]
public class UserController(UserService userService) : ControllerBase {
    private readonly UserService userService = userService;
    
    [Authorize(Roles = "manage-users")]
    [HttpPost]
    [DefaultValue("""
    {
        "username": "test",
        "credentials": [{
            "value": "password_change_me"
        }]
    }
    """)]
    public async Task<HttpResponseMessage> Create([FromBody] UserRepresentation user) {
        return await userService.Create(user);
    }
}



public class UserService(IKeycloakClient keycloakClient) {
    private readonly IKeycloakClient keycloakClient = keycloakClient;
    private string RandomPassword(int length = 8)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-=_+[]\\{}|;':\",.<>/?";
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[RandomNumberGenerator.GetInt32(chars.Length)]).ToArray());
    }
    
    public async Task<HttpResponseMessage> Create(UserRepresentation user) {
        var result = await keycloakClient.CreateUserWithResponseAsync("develop", user);
        return result;
    }
}