using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public static class Constants {
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
    public static readonly JsonSerializerOptions DefaultJsonSerializerOptions = new JsonSerializerOptions {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString,
        WriteIndented = true,
        IncludeFields = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static readonly Action<HttpLoggingOptions> configureHttpLogging = options => {
        options.LoggingFields = HttpLoggingFields.All;
        options.CombineLogs = true;
        options.MediaTypeOptions.AddText("application/json");
        options.MediaTypeOptions.AddText("application/json; charset=utf-8");
        options.MediaTypeOptions.AddText("multipart/form-data");
        options.RequestHeaders.Clear();
        options.ResponseHeaders.Clear();
        if (builder.Environment.IsDevelopment()) {
            foreach(var item in new [] {"Authorization", "Authentication", "Cookie", "Origin", "Referer", "Content-Length", "WWW-Authenticate", "Content-Type", "Host", "User-Agent", "Accept-Encoding", "Accept-Language", "Accept", "Connection"} ) {
                options.RequestHeaders.Add(item);
                options.ResponseHeaders.Add(item);
            }
        }
    }

    public static readonly Action<JwtBearerOptions> configureKeycloakHttpClient = options =>
    {
        var client = new HttpClient();
        options.TokenValidationParameters = new TokenValidationParameters() {
            ValidAudiences = config.GetSection("Keycloak:Audiences").AsEnumerable().Select(c => c.Value),
            ValidateIssuer = true,
            ValidateAudience = true,
            SignatureValidator = delegate (string token, TokenValidationParameters parameters)
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var result = client.GetAsync($"{config["Keycloak:auth-server-url"]}/realms/develop/protocol/openid-connect/userinfo").GetAwaiter().GetResult();
                if(result.StatusCode == HttpStatusCode.OK) {
                    return new JsonWebToken(token);
                } else return null;
            }
        };
        
        // Capture the JWT and store it as a claim
        options.Events = new JwtBearerEvents
        {
            OnTokenValidated = context =>
            {
                if (context.SecurityToken is System.IdentityModel.Tokens.Jwt.JwtSecurityToken jwtToken)
                {
                    var claimsIdentity = context.Principal?.Identity as ClaimsIdentity;
                    claimsIdentity?.AddClaim(new Claim("jwt", jwtToken.RawData));
                }

                return Task.CompletedTask;
            }
        };
    };
}