using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Identity.SeedWork;
using Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Auth.Commands
{
    public class SignInRequest : IRequest<Response<object>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class SignInValidation : AbstractValidator<SignInRequest>
    {
        public SignInValidation()
        {
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("O email não pode ser vazio.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("A senha não pode ser vazia");
        }
    }

    public class SignIn : IRequestHandler<SignInRequest, Response<object>>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _token;

        public SignIn(SignInManager<User> signInManager, TokenService token)
        {
            _signInManager = signInManager;
            _token = token;
        }

        public async Task<Response<object>> Handle(SignInRequest request, CancellationToken cancellationToken)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is null)
                return Response.Fail().WithMessage("Usuário não encontrado");

            var identityResult = await _signInManager.PasswordSignInAsync(user, request.Password, false, false);
            if (!identityResult.Succeeded)
                return Response.Fail().WithMessage("Senha errada.");

            var role = (await _signInManager.UserManager.GetRolesAsync(user)).FirstOrDefault();
            var token = _token.GenerateToken(user, role);

            return Response.Ok().WithMessage("Usuário logado.").WithData(new { Token = token });

        }

    }

}