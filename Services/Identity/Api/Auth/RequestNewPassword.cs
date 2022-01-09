using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentEmail.Core;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Api.Auth
{
    public record UserRequestNewPassword(string Email) : IRequest<Response>;
    public class UserRequestNewPasswordValidator : AbstractValidator<UserRequestNewPassword>
    {
        public UserRequestNewPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio.");
        }
    }
    public class RequestNewPassword : IRequestHandler<UserRequestNewPassword, Response>
    {
        IUsers _users;
        IFluentEmail _email;
        IConfiguration _configuration;
        public string Token { get; private set; }

        public RequestNewPassword(IUsers users, IFluentEmail email, IConfiguration configuration)
        {
            _users = users;
            _email = email;
            _configuration = configuration;
        }

        public async Task<Response> Handle(UserRequestNewPassword request, CancellationToken cancellationToken)
        {
            var user = await _users.Get(request.Email);
            if (user is null)
                return new("Usuário não encontrado", false);
                
            var link = _configuration["Auth:RecoveryPassword"];
            Token = _configuration.GenerateToken(user.Email, user.Name);

            await _email
                .To(user.Email)
                .Subject("Couple Finance")
                .Body($"Para recuperar sua senha acesse o link: {link}{Token}")
                .SendAsync();

            return new("As instruções para recuperação de senha foi enviado para o seu email.");
        }
    }
}