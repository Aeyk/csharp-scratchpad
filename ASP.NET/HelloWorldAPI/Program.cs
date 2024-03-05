using HelloWorldAPI.Helpers;
using System.Text.Json.Serialization;

namespace HelloWorldAPI;

public class Program
{
  public static async Task<int> Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    var services = builder.Services;
    // Add services to the container.

    services.AddSingleton<DataContext>()
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
    // services.AddScoped<IUserService, UserService>();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    services.AddEndpointsApiExplorer()
            .AddSwaggerGen();

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

      app.UseAuthorization();

      app.MapControllers();
    }
    app.Run();
    return 0;
  }
}
