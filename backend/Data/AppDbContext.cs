using Microsoft.EntityFrameworkCore;
using TaskTrackrAPI.Models;

namespace TaskTrackrAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
    }
}
