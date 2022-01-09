using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentValidation;
using MediatR;

namespace Api.Users
{
    public record UserToDisable(Guid Id, string Cause) : IRequest<Response>;
    public class UserToDisableValidator : AbstractValidator<UserToDisable>
    {
        public UserToDisableValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Informe um Id de usuário válido.");
            RuleFor(x => x.Cause).NotEmpty().NotNull().MinimumLength(10)
                .WithMessage("O motivo para desabilitar um usuário deve conter no mínimo 10 caracteres.");
        }
    }
    public class DisableUser : IRequestHandler<UserToDisable, Response>
    {
        private readonly IUsers _users;

        public DisableUser(IUsers users)
        {
            _users = users;
        }

        public async Task<Response> Handle(UserToDisable request, CancellationToken cancellationToken)
        {
            var user = await _users.Get(request.Id);
            if (user is null)
                return new("Usuário não encontrado.", false);
            
            user.Disable(request.Cause);
            await _users.Update(user);
            
            return new("Usuário desabilitado.",true, user.History.Last());
        }
    }
}