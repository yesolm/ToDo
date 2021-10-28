using Microsoft.EntityFrameworkCore;
using ToDo.Core.Models;

namespace ToDo.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }

    }
}