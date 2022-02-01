using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.SeedWork;
using Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Auth.Commands
{
    public class LogoutRequest : IRequest<Response<object>> { }
    public class Logout : IRequestHandler<LogoutRequest, Response<object>>
    {
        private readonly SignInManager<User> _signManager;

        public Logout(SignInManager<User> signManager)
        {
            _signManager = signManager;
        }

        public async Task<Response<object>> Handle(LogoutRequest request, CancellationToken cancellationToken)
        {
             await _signManager.SignOutAsync();
             return Response.Ok().WithMessage("Usuário deslogado");
        }
    }
}