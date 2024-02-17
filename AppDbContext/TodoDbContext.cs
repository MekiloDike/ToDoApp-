using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.AppDbContext
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
