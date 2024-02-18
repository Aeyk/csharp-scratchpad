using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using UUIDNext; 

namespace Todo.Models;

public class TodoListContext : DbContext
{
    public DbSet<TodoItem> items { get; set; }
    public DbSet<TodoList> lists { get; set; }
    protected readonly IConfiguration Configuration; 

    public TodoListContext(DbContextOptions<TodoListContext> options, IConfiguration configuration)
    : base(options)
    {
        Configuration = configuration;
    }
}

public class TodoList
{
    public Guid Id { get; set; } = Uuid.NewSequential();
    public string Name { get; set; }
    public List<TodoItem> Items { get; } = new();
}

public enum TodoStateEnum : ushort
{
    Todo = 0,
    Done = 1,
    Wait = 2
}

public class TodoItem
{
    public Guid Id { get; set; } = Uuid.NewSequential();
    public string Content { get; set; }
    public TodoList TodoList { get; set; }
    public TodoStateEnum State { get; set; }
}
