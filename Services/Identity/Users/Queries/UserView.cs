using System;

namespace Identity.Users.Queries
{
    public class UserView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}