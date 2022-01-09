using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentValidation;
using MediatR;

namespace Api.Users
{
    public record UpdateUser(Guid Id, string Name, string Email) : IRequest<Response>;
    public class UpdateUserValidator : AbstractValidator<UpdateUser>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage("Informe um Id válido do usuário");
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("O nome do usuário não pode ser vazio");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("O nome não pode conter mais de 100 caracteres");
            RuleFor(x => x.Email).NotEmpty().NotNull().WithMessage("O email do usuário não pode ser vazio");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("O email não pode conter mais de 100 caracteres");
        }
    }

    public class ChangeUser : IRequestHandler<UpdateUser, Response>
    {
        private readonly IUsers _users;

        public ChangeUser(IUsers users)
        {
            _users = users;
        }

        public async Task<Response> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _users.Get(request.Id);
                if (user is null)
                    return new("Usuário não encontrado.", false);

                user.ChangeName(request.Name);
                user.ChangeEmail(request.Email);
                await _users.Update(user);
                return new("Usuário alterado.");
            }
            catch (Exception e)
            {
                return new(e.Message, false);
            }
        }
    }

}