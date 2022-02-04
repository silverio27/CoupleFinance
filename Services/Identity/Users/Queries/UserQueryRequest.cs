using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Users.Queries
{
    public class UserQueryRequest : IRequest<Pagination<UserView>>
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class UserQuery : IRequestHandler<UserQueryRequest, Pagination<UserView>>
    {
        private readonly SignInManager<User> _signInManager;

        public UserQuery(SignInManager<User> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<Pagination<UserView>> Handle(UserQueryRequest request, CancellationToken cancellationToken)
        {
            var users = _signInManager.UserManager.Users.Select(x => new UserView()
            {
                Id = x.Id,
                Name = x.UserName,
                Email = x.Email
            })
            .OrderBy(x => x.Id);

            if (!string.IsNullOrEmpty(request.Name))
                users.Where(x => x.Name.Contains(request.Name));

            if (!string.IsNullOrEmpty(request.Email))
                users.Where(x => x.Email.Contains(request.Email));

            var pagination = new Pagination<UserView>(users, request.PageIndex, request.PageSize);
            return await pagination.ToListAsync();
        }
    }
}