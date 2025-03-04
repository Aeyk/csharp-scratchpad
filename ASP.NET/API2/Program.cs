using System.Net;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Serialization;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Keycloak.AuthServices.Common;
using Keycloak.AuthServices.Sdk;
using static Keycloak.AuthServices.Sdk.Kiota.Admin.KeycloakAdminApiClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Http.Logging;
using Microsoft.AspNetCore.Authentication.Cookies;
using API2.Components;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.ConfigureHttpClientDefaults(b => b.RedactLoggedHeaders(_ => false));

builder.Services.AddHttpLogging(Constants.configureHttpLogging);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true;
});
builder.Services.AddControllers();
builder.Services.AddSingleton<JsonSerializerOptions>(Constants.DefaultJsonSerializerOptions);

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", Constants.KeycloakSecurityScheme);
    options.AddSecurityRequirement(Constants.KeycloakSecurityRequirement);
});

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddKeycloakWebApi(builder.Configuration,
    configureJwtBearerOptions: Constants.ConfigureKeycloakHttpClient(config));

// builder.Services
//     .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//     options => {
//     });

builder.Services
    .AddAuthorization()
    .AddKeycloakAuthorization(config)
    .AddAuthorizationBuilder();

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

builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<TaskContext>();
builder.Services.AddScoped<KeycloakAuthenticationService>();
builder.Services.AddOpenIdConnectAccessTokenManagement();
builder.Services.AddUserAccessTokenHttpClient(Constants.KeycloakUserClient, configureClient: client => 
{
    client.BaseAddress = new Uri(config["Keycloak:auth-server-url"]);
});

Keycloak.AuthServices.Sdk.Kiota.ServiceCollectionExtensions
    .AddKeycloakAdminHttpClient(builder.Services, config)
    .AddClientCredentialsTokenHandler(Constants.KeycloakClient);

Keycloak.AuthServices.Sdk.ServiceCollectionExtensions
    .AddKeycloakAdminHttpClient(builder.Services, config)
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

    
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();