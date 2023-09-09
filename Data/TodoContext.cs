using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data; 

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> opts) : base(opts)
    {
        
    }

    public DbSet<User> Users {get; set;}
    public DbSet<Models.Task> Tasks {get; set;}
    public DbSet<Category> Categories {get; set;}
}