using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FluentValidation;
using Identity.SeedWork;
using Identity.Users.Notifications;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Users.Commands
{
    public class NewUserRequest : IRequest<Response<User>>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class NewUserValidator : AbstractValidator<NewUserRequest>
    {
        public NewUserValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("O nome não pode ser vazio.");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("A senha não pode ser vazia.");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("O email não pode ser vazio.");
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("A confirmação de senha não é idêntica a senha.");
        }
    }

    public class NewUser : IRequestHandler<NewUserRequest, Response<User>>
    {
        private readonly UserManager<User> _manager;
        private readonly IMediator _mediator;
        public NewUser(UserManager<User> manager, IMediator mediator)
        {
            _manager = manager;
            _mediator = mediator;
        }

        public async Task<Response<User>> Handle(NewUserRequest request, CancellationToken cancellationToken)
        {
            User user = new(request.Name, request.Email, request.Password);
            var result = await _manager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
                return Response<User>.Fail()
                    .WithMessage("Não foi possível criar o usuário")
                    .WithErrors(result.Errors);

            await _manager.AddToRoleAsync(user, "regular");

            var emailToken = await _manager.GenerateEmailConfirmationTokenAsync(user);
            var codeToConfirmAccountOnEmail = HttpUtility.UrlEncode(emailToken);

            await _mediator.Publish(new NewUserNotification(){
                Subject= "Bem Vindo",
                To = user.Email
            });

            return Response<User>.Ok()
                .WithMessage("Conta criada. Veja seu email para confirmar sua conta")
                .WithData(user);
        }
    }
}