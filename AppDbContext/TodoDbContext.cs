using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.AppDbContext
{
    public class TodoDbContext : IdentityDbContext<User>
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {
        }
        
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }

    }
}
