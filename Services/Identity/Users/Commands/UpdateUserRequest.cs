using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Identity.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Users.Commands
{
    public class UpdateUserRequest : IRequest<Response<object>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Guid Id {get; set;}
    }

    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email não pode ser vazio.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Nome não pode ser vazio.");
        }
    }

    public class UpdateUser : IRequestHandler<UpdateUserRequest, Response<object>>
    {
        private readonly UserManager<User> _user;

        public UpdateUser(UserManager<User> user)
        {
            _user = user;
        }

        public async Task<Response<object>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _user.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (user is null)
                return Response<object>.Fail().WithMessage("Usuário não encontrado.");
            user.Email = request.Email;
            user.UserName = request.Name;

            await _user.UpdateAsync(user);

            return Response<object>.Ok().WithMessage("Dados atualizados.");
        }
    }
}