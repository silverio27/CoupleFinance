using System;
using Identity.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Identity.Data
{
    public class DataContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        IConfiguration _configuration;
        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            Guid adminId = new Guid("1329fa77-e1ee-4f86-81c5-c8112ecbfacc");
            User admin = new(
                name: "admin",
                email: "silverio.des.vargas@gmail.com",
                password: _configuration["Admin:Password"],
                emailConfirmed: true,
                id: adminId
            );
            builder.Entity<User>().HasData(admin);

            Guid adminRoleId = new Guid("e5ca3e84-6ca9-473f-966c-76291e0d84fc");
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );

            Guid regularRoleId = new Guid("4d92915b-fe80-41eb-9c6d-6c6b03801c6b");
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid>
                {
                    Id = regularRoleId,
                    Name = "regular",
                    NormalizedName = "REGULAR"
                }
            );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>()
                {
                    RoleId = adminRoleId,
                    UserId = adminId
                }
            );

        }
    }
}