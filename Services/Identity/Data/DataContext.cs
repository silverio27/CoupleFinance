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
            string adminId = "1329fa77-e1ee-4f86-81c5-c8112ecbfacc";
            User admin =new(){
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "silverio.des.vargas@gmail.com",
                NormalizedEmail = "SILVERIO.DES.VARGAS@GMAIL.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = new Guid(adminId)
            };
            
            PasswordHasher<User> hasher = new();
            admin.PasswordHash = hasher.HashPassword(admin,_configuration.GetValue<string>("admin:password"));

            builder.Entity<User>().HasData(admin);

            string adminRoleId = "e5ca3e84-6ca9-473f-966c-76291e0d84fc";
            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> {
                    Id = new Guid(adminRoleId),
                    Name = "admin",
                    NormalizedName = "ADMIN"
                }
            );

            string regularRoleId = "4d92915b-fe80-41eb-9c6d-6c6b03801c6b";

            builder.Entity<IdentityRole<Guid>>().HasData(
                new IdentityRole<Guid> {
                    Id = new Guid(regularRoleId),
                    Name = "regular",
                    NormalizedName = "REGULAR"
                }
            );

            builder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>(){
                    RoleId = new Guid( adminRoleId),
                    UserId = new Guid(adminId)
                }
            );


        }
    }
}