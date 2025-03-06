using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using Keycloak.AuthServices.Authentication;
using Keycloak.AuthServices.Authorization;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Keycloak.AuthServices.Authentication.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net;
using Keycloak.AuthServices.Sdk;
using Keycloak.AuthServices.Common;
using TodoList.Services;

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => {
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", Constants.KeycloakSecurityScheme);
    options.AddSecurityRequirement(Constants.KeycloakSecurityRequirement);
});

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseSqlite(connectionString);
    options.UseOpenIddict();
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    { 
        // options.SignIn.RequireConfirmedAccount = true;
    })
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication();

builder.Services.AddOpenIddict()
    .AddCore(options =>
    {
        // Configure OpenIddict to use the Entity Framework Core stores and models.
        options.UseEntityFrameworkCore()
               .UseDbContext<ApplicationDbContext>();
    });

builder.Services.AddOpenIddict()
    .AddClient(options =>
    {
        // Allow the OpenIddict client to negotiate the authorization code flow.
        options.AllowAuthorizationCodeFlow();

        // Register the signing and encryption credentials used to protect
        // sensitive data like the state tokens produced by OpenIddict.
        options.AddDevelopmentEncryptionCertificate()
               .AddDevelopmentSigningCertificate();

        // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
        options.UseAspNetCore()
               .EnableRedirectionEndpointPassthrough()
               .DisableTransportSecurityRequirement();

        options.UseWebProviders()
            .AddKeycloak(options => {
                options.SetClientId(config["Keycloak:resource"])
                    .SetClientSecret(config["Keycloak:credentials:secret"])
                    .SetIssuer(config["Keycloak:auth-server-url"] + "realms/develop")
                    .SetRedirectUri("/api/v1/auth/login/keycloak")
                    .SetProviderName("Keycloak");
            });
    });

builder.Services
    .AddAuthorization(options => {
        options.AddPolicy("Authenticated", policy => {
            policy.RequireAuthenticatedUser();
        });
        options.DefaultPolicy = options.GetPolicy("Authenticated");
    })
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

builder.Services.AddScoped<DocumentService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseRouting();
app.UseCors();


app.UseAuthentication();

app.UseAuthorization();

app.UseStaticFiles();
app.MapRazorPages()
   .WithStaticAssets();
app.MapDefaultControllerRoute();
app.MapControllerRoute(name: "default",
    // pattern: "api/v{version}/{controller:lowercase}/{action:lowercase}");
    pattern: "api/v{version}/{controller}/{action}");
    
app.Run();
