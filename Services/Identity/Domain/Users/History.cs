using System;
using Domain.SeedWork;

namespace Domain.Users
{
    public class History : Entity
    {
        public History(string message)
        {
            When = DateTime.UtcNow;
            Message = message;
        }

        public DateTime When { get; private set; }
        public string Message { get; private set; }

    }
}