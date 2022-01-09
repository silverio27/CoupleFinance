using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class UserContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public UserContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(x => x.Name).HasColumnType("varchar(100)");
            builder.Entity<User>().Property(x => x.Email).HasColumnType("varchar(100)");
        }
    }
}