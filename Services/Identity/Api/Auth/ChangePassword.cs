using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Domain.Users;
using FluentValidation;
using MediatR;


namespace Api.Auth
{
    public record NewPassword(string Email, string Password, string ConfirmPassword) : IRequest<Response>;
    public class NewPasswordValidator : AbstractValidator<NewPassword>
    {
        public NewPasswordValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("O email não pode ser vazio");
            RuleFor(x => x.Password).Equal(x => x.ConfirmPassword).WithMessage("A confirmação da senha não é idêntica.");
            RuleFor(x => x.Password.Validate()).Must(x => x.valid).WithMessage(x => x.Password.Validate().message);
        }
    }
    public class ChangePassword : IRequestHandler<NewPassword, Response>
    {
        IUsers _users;

        public ChangePassword(IUsers users)
        {
            _users = users;
        }

        public async Task<Response> Handle(NewPassword request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _users.Get(request.Email);
                user.ChangePassword(request.Password, request.ConfirmPassword);
                return new("Senha alterada");
            }
            catch (System.Exception e)
            {

                return new(e.Message, false);
            }
        }
    }
}