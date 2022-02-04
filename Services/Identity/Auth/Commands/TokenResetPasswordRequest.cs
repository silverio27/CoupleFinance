using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using Identity.Auth.Notifications;
using Identity.SeedWork;
using Identity.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Auth.Commands
{
    public class TokenResetPasswordRequest : IRequest<Response<object>>
    {
        public string Email { get; set; }
    }

    public class TokenResetPasswordValidator : AbstractValidator<TokenResetPasswordRequest>
    {
        public TokenResetPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio");
        }
    }
    public class TokenResetPassword : IRequestHandler<TokenResetPasswordRequest, Response<object>>
    {
        private readonly SignInManager<User> _signInManager;
        private readonly IMediator _mediator;
        public TokenResetPassword(SignInManager<User> signInManager, IMediator mediator)
        {
            _signInManager = signInManager;
            _mediator = mediator;
        }

        public async Task<Response<object>> Handle(TokenResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var user = await _signInManager.UserManager.Users.FirstOrDefaultAsync(x => x.Email == request.Email);
            if (user is null)
                return Response<object>.Fail().WithMessage("Usuário não encontrado");

            string codeToResetPassword = await _signInManager.UserManager.GeneratePasswordResetTokenAsync(user);
            await _mediator.Publish(new TokenResetPasswordNotification()
            {
                CodeToResetPassword = codeToResetPassword,
                Subject = "Resetar senha",
                To = user.Email
            });

            return Response<object>.Ok().WithMessage("Um email foi enviado com as instruções de redefinição de senha");
        }
    }
}