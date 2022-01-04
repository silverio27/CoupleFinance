using System;
using System.Threading.Tasks;

namespace Domain.Users
{
    public interface IUsers
    {
        Task<User> Get(Guid id);
        Task<User> Get(string email);
        Task Update(User user);
        Task Create(User user);
        Task Delete(User user);
    }
}