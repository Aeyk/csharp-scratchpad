using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Duende.AccessTokenManagement;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Common;
using Keycloak.AuthServices.Sdk;
using Keycloak.AuthServices.Sdk.Admin;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var jsonSerializerOptions =  new JsonSerializerOptions {
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.WriteAsString | JsonNumberHandling.AllowReadingFromString,
        WriteIndented = true,
        IncludeFields = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureHttpClientDefaults(b => b.RedactLoggedHeaders([]));
builder.Services.AddHttpLogging(options => {
    options.LoggingFields = HttpLoggingFields.All;
    options.CombineLogs = true;
    options.MediaTypeOptions.AddText("application/json");
    options.MediaTypeOptions.AddText("multipart/form-data");


});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true;
});
builder.Services.AddControllers();
builder.Services.AddSingleton<JsonSerializerOptions>(jsonSerializerOptions);

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme.

Enter your token in the text input below.",
         Name = "Authorization",
         In = ParameterLocation.Header,
         Type = SecuritySchemeType.Http,
         Scheme = "Bearer",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
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
    });
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddKeycloakWebApi(builder.Configuration,
    configureJwtBearerOptions: options =>
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
    });

builder.Services.AddAuthorization(options => {
    options.AddPolicy("Authenticated", policy => {
        policy.RequireAssertion(context => null != context.User || context.User.HasClaim(c => c.Type == "jwt"));
    });
})
.AddKeycloakAuthorization(config)
.AddAuthorizationBuilder()

;
// .AddAuthorizationServer(config);


builder.Services.AddDistributedMemoryCache();
builder.Services
    .AddClientCredentialsTokenManagement()
    .AddClient(
        Constants.KeycloakClient, 
        client =>
        {
            var options = config.GetKeycloakOptions<KeycloakAdminClientOptions>()!;
            client.ClientId = options.Resource;
            client.ClientSecret = options.Credentials.Secret;
            client.TokenEndpoint = options.KeycloakTokenEndpoint;
        });

// builder.Services.AddClientCredentialsHttpClient(Constants.KeycloakClient, Constants.KeycloakClient, client => {
//     client.BaseAddress = new Uri(config["Keycloak:auth-server-url"]);
// });

builder.Services.AddSingleton<UserService>();
// builder.Services.AddSingleton<IKeycloakClient>(sp => {
//     var httpClientFactory = sp.GetRequiredService<IHttpClientFactory>();
//     var httpClient = httpClientFactory.CreateClient(Constants.KeycloakClient);
//     httpClient.BaseAddress = new Uri(config["Keycloak:auth-server-url"]);
//     return new KeycloakClient(httpClient);
// });
builder.Services.AddScoped<KeycloakAuthenticationService>();

builder.Services
    .AddKeycloakAdminHttpClient(config)
    .AddClientCredentialsTokenHandler(Constants.KeycloakClient);

var app = builder.Build();

app.UseHttpLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default",
    pattern: "{controller:lowercase}/{action:lowercase}");

app.Run();