using DatingApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApi.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AppUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .Property(a => a.Username)
                .IsRequired()
                .HasMaxLength(255);

            base.OnModelCreating(modelBuilder);
        }
    }
}
