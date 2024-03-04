using asp_todo.Models;
using Microsoft.EntityFrameworkCore;

namespace asp_todo.Contexts;

public class TodoContext : DbContext{
  public DbSet<Todo> Todos => Set<Todo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=todos.sqlite3");
    }
}