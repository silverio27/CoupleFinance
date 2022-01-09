using Api.Auth;
using Xunit;
using FluentValidation.TestHelper;

namespace UnitTests.Api.Auth
{
    public class ValidationNewPasswordTests
    {
        NewPasswordValidator _validator;

        public ValidationNewPasswordTests()
        {
            _validator = new NewPasswordValidator();
        }

        [Fact]
        public void New_Password_Ok()
        {
            var newPassword = new NewPassword("silverio.des.vargas@gmail.com", "LLtt8800_@!", "LLtt8800_@!");

            var result = _validator.TestValidate(newPassword);

            result.ShouldNotHaveAnyValidationErrors();

        }
        [Fact]
        public void New_Password_Invalid()
        {
            var newPassword = new NewPassword("", "", "LLtt8800_@!");

            var result = _validator.TestValidate(newPassword);

            result.ShouldHaveAnyValidationError();
        }
    }
}