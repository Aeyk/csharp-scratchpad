using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Threading.Tasks;

public static class Constants
{
    public static readonly string KeycloakClient = "Keycloak";

    public static readonly string KeycloakUserClient = "KeycloakUser";
    public static readonly OpenApiSecurityScheme KeycloakSecurityScheme =
        new OpenApiSecurityScheme
        {
            Description = @"JWT Authorization header using the Bearer scheme.

Enter your token in the text input below.",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
        };
    public static readonly OpenApiSecurityRequirement KeycloakSecurityRequirement =
        new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    },
                    Scheme = "oauth2",
                    Name = "Bearer",
                    In = ParameterLocation.Header,

                },
                new List<string>()
            }
        };
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions
    {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString,
        WriteIndented = true,
        IncludeFields = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static readonly Action<HttpLoggingOptions> configureHttpLogging = options =>
    {
        options.LoggingFields = HttpLoggingFields.All;
        options.CombineLogs = true;
        options.MediaTypeOptions.AddText("application/json");
        options.MediaTypeOptions.AddText("application/json; charset=utf-8");
        options.MediaTypeOptions.AddText("multipart/form-data");
        options.RequestHeaders.Clear();
        options.ResponseHeaders.Clear();
        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            foreach (var item in new[] { "Authorization", "Authentication", "Cookie", "Origin", "Referer", "Content-Length", "WWW-Authenticate", "Content-Type", "Host", "User-Agent", "Accept-Encoding", "Accept-Language", "Accept", "Connection" })
            {
                options.RequestHeaders.Add(item);
                options.ResponseHeaders.Add(item);
            }
        }
    };

    public static Action<JwtBearerOptions> ConfigureKeycloakHttpClient(IConfiguration config)
    {
        return options =>
        {
            var client = new HttpClient();
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidAudiences = config.GetSection("Keycloak:Audiences").AsEnumerable().Select(c => c.Value),
                ValidateIssuer = true,
                ValidateAudience = true,
                SignatureValidator = delegate (string token, TokenValidationParameters parameters)
                {
                    return new JsonWebToken(token);
                }
            };
            // Capture the JWT and store it as a claim
            options.Events = new JwtBearerEvents
            {
                OnMessageReceived = context => {
                    var stringlyToken = context?.Request?.Headers?.Authorization.FirstOrDefault(string.Empty) ?? String.Empty;
                    if(stringlyToken == default || stringlyToken.Split(" ").Length <= 1) return Task.CompletedTask;
                    var token = new JsonWebToken(stringlyToken.Split(" ")[1]);
                    var identity = new ClaimsPrincipal(new ClaimsIdentity(token.Claims));
                    // ((ClaimsIdentity)context.HttpContext.User.Identity).Name = token.Claims.Select(c=> c.Type == ClaimTypes.Name).FirstOrDefault();
                    ((ClaimsIdentity)context.HttpContext.User.Identity).AddClaims(token.Claims);
                    return Task.CompletedTask;
                }
            };
        };
    }
}