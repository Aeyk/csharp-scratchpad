using HelloWorldAPI.Helpers;
using HelloWorldAPI.Authorization;
using HelloWorldAPI.Services;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HelloWorldAPI;


// TODO move api commits to feature branch
// TODO move api authc/authn to feature branch
public class Program
{
  public static async Task<int> Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

    services.Configure<AppSettings>(builder.Configuration.GetSection("Jwt"))
            .AddSingleton<DataContext>()
            .AddCors()
            .AddControllers()
            .AddJsonOptions(options =>
            {
              // serialize enums as strings
              options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

              // ignore omitted parameters on models to enable optional params 
              options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            });

    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    // services.AddScoped<IUserRepository, UserRepository>();
    services.AddScoped<IJwtUtils, JwtUtils>();
    services.AddScoped<IUserService, UserService>();


    // services.AddAuthentication(options =>
    // {
    //   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //   options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    // })
    //     .AddJwtBearer(options =>
    //     {
    //       // x.AuthenticationScheme = "Bearer";
    //       options.Audience = "http://localhost:4000";
    //       options.Authority = "ABCXYZ";
    //       options.TokenValidationParameters = new TokenValidationParameters
    //       {
    //         ValidateIssuerSigningKey = true,
    //         ValidateLifetime = true,
    //         ValidateIssuer = false,
    //         // ValidIssuer = "ABCXYZ",
    //         ValidateAudience = false,
    //         IssuerSigningKey = new SymmetricSecurityKey(
    //           Encoding.UTF8.GetBytes(
    //             config.GetValue<string>("AppSettings:JwtSigningKey")))
    //       };
    //     });


    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services
      .AddEndpointsApiExplorer()
      .AddSwaggerGen(options =>
        {
          options.AddSecurityDefinition(String.Empty, new OpenApiSecurityScheme
          {
            In = ParameterLocation.Header,
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            BearerFormat = "JWT",
            Scheme = String.Empty,
          });
          options.AddSecurityRequirement(new OpenApiSecurityRequirement
          {
            {
              new OpenApiSecurityScheme
                  {
                    Reference = new OpenApiReference
                    {
                      Type = ReferenceType.SecurityScheme,
                      Id = String.Empty
                    },
                    In = ParameterLocation.Header
                  },
                  new List<string>()
                }
          });
        });

    var app = builder.Build();
    {
      using var scope = app.Services.CreateScope();
      var context = scope.ServiceProvider.GetRequiredService<DataContext>();
      await context.Init();
    }

    {
      // Configure the HTTP request pipeline.
      if (app.Environment.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
          {
            options.InjectStylesheet("/swagger/custom.css");
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "HelloWorldAPI v1");
            options.RoutePrefix = "";
          });
      }

      app.UseCors(options =>
      options.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

      app.UseMiddleware<ErrorHandlerMiddleware>();

      app.UseMiddleware<JwtMiddleware>();

      // app.UseAuthentication();

      app.UseAuthorization();

      app.MapControllers();
    }
    app.Run();
    return 0;
  }
}
