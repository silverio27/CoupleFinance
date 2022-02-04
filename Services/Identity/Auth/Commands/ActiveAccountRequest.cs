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
    public class ActiveAccountRequest : IRequest<Response<object>>
    {
        public Guid UserId { get; set; }
        public string CodeActivation { get; set; }

    }
    public class ActiveAccountValidator : AbstractValidator<ActiveAccountRequest>
    {
        public ActiveAccountValidator()
        {
            RuleFor(x => x.UserId).NotEmpty().WithMessage("Id do usuário inválido.");
            RuleFor(x => x.CodeActivation).NotEmpty().WithMessage("Código de ativação inválido.");
        }
    }

    public class ActiveAccount : IRequestHandler<ActiveAccountRequest, Response<object>>
    {
        private readonly UserManager<User> _users;
        public ActiveAccount(UserManager<User> user)
        {
            _users = user;
        }

        public async Task<Response<object>> Handle(ActiveAccountRequest request, CancellationToken cancellationToken)
        {
            var user = await _users.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
            if (user is null)
                return Response<object>.Fail().WithMessage("Usuário não encontrado");

            await _users.ConfirmEmailAsync(user, request.CodeActivation);

            return Response<object>.Ok().WithMessage("Conta ativada");
        }
    }
}