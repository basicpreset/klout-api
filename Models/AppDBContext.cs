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
        public DbSet<Like> likes { get; set; }
        public DbSet<Dislike> dislikes { get; set; }
        public DbSet<Follow> follows { get; set; }
        public DbSet<Repost> reposts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
