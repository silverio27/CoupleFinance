using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Api.Auth
{
    public record Credential(string Email, string Password) : IRequest<Response>;
    public class CredentialValidator : AbstractValidator<Credential>
    {
        public CredentialValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O nome não pode ser vazio.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("A senha não pode ser vazio.");
        }
    }

    public class Authenticate : IRequestHandler<Credential, Response>
    {
        IUsers _users;
        IConfiguration _configuration;
        public Authenticate(IUsers users, IConfiguration configuration)
        {
            _users = users;
            _configuration = configuration;
        }
        public async Task<Response> Handle(Credential request, CancellationToken cancellationToken)
        {
            var user = await _users.Get(request.Email);
            if (user is null)
                return new("Não existe um usuário com esse email", false);

            if (!user.VerifyPassword(request.Password))
                return new("A senha está incorreta.", false);

            var token = _configuration.GenerateToken(user.Email, user.Name);
            return new("Usuário autenticado.", true, new { token });
        }
    }
}