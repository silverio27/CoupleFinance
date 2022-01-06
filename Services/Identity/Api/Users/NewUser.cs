using System;
using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Api.Users
{
    public class NewUser : IRequest<Response>
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class NewUserValidation : AbstractValidator<NewUser>
    {
        public NewUserValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome do usuário não pode ser vazio");
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio");
        }
    }

    public class CreateUser : IRequestHandler<NewUser, Response>
    {
        IUsers _users;
        ILogger<CreateUser> _logger;
        public CreateUser(IUsers users, ILogger<CreateUser> logger)
        {
            _users = users;
            _logger = logger;
        }
        public async Task<Response> Handle(NewUser request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User(request.Name, request.Email);
                await _users.Create(user);
                return new("Usuário criado.");
            }
            catch (Exception e)
            {

                return new(e.Message, false);
            }

        }
    }
}