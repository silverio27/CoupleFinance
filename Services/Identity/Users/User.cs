using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Identity.Users
{
    public class User : IdentityUser<Guid>
    {
        public User(string name, string email, string password, bool emailConfirmed = false, Guid? id = null)
        {
            Id = id is null ? Guid.NewGuid() : (Guid)id;
            UserName = name;
            NormalizedUserName = name.ToUpper();
            Email = email;
            NormalizedEmail = email.ToUpper();
            SecurityStamp = Guid.NewGuid().ToString();
            EmailConfirmed = emailConfirmed;
            PasswordHasher<User> hasher = new();
            PasswordHash = hasher.HashPassword(this, password);
        }
        protected User() { }

    }
}