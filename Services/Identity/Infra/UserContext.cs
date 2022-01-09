using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class UserContext : DbContext
    {
        public DbSet<User> User {get; set;}
        public UserContext(DbContextOptions options) : base(options)
        {
        }
    }
}