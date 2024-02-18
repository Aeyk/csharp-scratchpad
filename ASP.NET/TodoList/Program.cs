using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.EntityFrameworkCore;
using Todo.Models;
var builder = WebApplication.CreateBuilder(args);

var configBuilder = new ConfigurationBuilder()
  .SetBasePath(builder.Environment.ContentRootPath)
  .AddJsonFile("appsettings.json")
  .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true);

var config = configBuilder.Build();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services
 .AddEntityFrameworkSqlite()
    .AddDbContext<TodoListContext>(optionsBuilder =>
        optionsBuilder.UseSqlite(config.GetConnectionString("WebApiDatabase")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "todo",
    pattern: "{controller=TodoList}/{action=Index}/{id?}");

app.Run();
