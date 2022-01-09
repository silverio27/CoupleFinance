using System;

namespace Domain.Users
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message){   }

    }
}