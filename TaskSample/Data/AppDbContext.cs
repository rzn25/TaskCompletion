using Microsoft.EntityFrameworkCore;
using TaskSample.Models;

namespace TaskSample.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
            
        }

        public DbSet<User> Users {get; set;}

    }
}