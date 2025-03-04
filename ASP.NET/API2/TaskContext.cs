using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class TaskContext : DbContext
{
    public DbSet<TaskDto> Tasks { get; set; }

    public string DbPath { get; }

    private readonly IConfiguration config;
    public TaskContext(IConfiguration config)
    {
        this.config = config;
        var folder = Environment.CurrentDirectory;
        DbPath = System.IO.Path.Join(folder, config["Databases:Testing:Data Source"]);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class TaskDto
{
    [Key]
    public int Id { get; set; }
    public UserDto Creator { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}

[Table("User")]
public class UserDto
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
}