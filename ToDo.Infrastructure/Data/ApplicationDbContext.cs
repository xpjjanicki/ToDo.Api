using Microsoft.EntityFrameworkCore;
using ToDo.Core.Entities;

namespace ToDo.Infrastructure.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<ToDoItem> ToDos { get; set; }
    }
}
