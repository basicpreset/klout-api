using System;
using Microsoft.EntityFrameworkCore;

namespace KloutAPI.Models
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<User> users { get; set; }
        public DbSet<Post> posts { get; set; }
    }
}
