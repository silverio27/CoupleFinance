using System;
using System.Threading.Tasks;
using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Users : IUsers
    {
        private readonly UserContext _context;
        public Users(UserContext context)
        {
            _context = context;
        }

        public async Task Create(User user)
        {
            await _context.User.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(User user)
        {
            _context.User.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> Get(Guid id)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> Get(string email)
        {
             return await _context.User.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}