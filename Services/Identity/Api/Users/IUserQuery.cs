using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using Infra;
using Microsoft.EntityFrameworkCore;

namespace Api.Users
{
    public interface IUsersQuery
    {
        Task<Pagination<UserView>> Get(UserQueryParams queryParams);
        Task<UserView> Get(Guid id);
    }
    public class UserView
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }

    public class UserQueryParams : PaginationQueryParams { }
    public class UsersQuery : IUsersQuery
    {
        UserContext _context;

        public UsersQuery(UserContext context)
        {
            _context = context;
        }

        public async Task<Pagination<UserView>> Get(UserQueryParams queryParams)
        {
            IQueryable<UserView> query = _context.User.Select(EntityToView());
            var result = new Pagination<UserView>(query, queryParams.PageIndex, queryParams.PageSize);
            await result.ToListAsync();
            return result;
        }

        public async Task<UserView> Get(Guid id)
        {
            return await _context.User.Select(EntityToView()).FirstOrDefaultAsync(x => x.Id == id);
        }

        private static Expression<Func<User, UserView>> EntityToView()
        {
            return x => new UserView()
            {
                Id = x.Id,
                Active = x.Active,
                Email = x.Email,
                Name = x.Name
            };
        }
    }
}