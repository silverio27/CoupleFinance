using Api.Auth;
using FluentValidation.TestHelper;
using Xunit;

namespace UnitTests.Api.Authty
{
    public class ValidationUserNewRequestPasswordTests
    {
        UserRequestNewPasswordValidator _validator;
        public ValidationUserNewRequestPasswordTests()
        {
            _validator = new();
        }

        [Fact]
        public void UserRequestNewPassword_Ok()
        {
            var userNewRequestPassword = new UserRequestNewPassword("silverio.des.vargas@gmail.com");

            var response = _validator.TestValidate(userNewRequestPassword);

            response.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void UserRequestNewPassword_Failed()
        {
            var userNewRequestPassword = new UserRequestNewPassword("");

            var response = _validator.TestValidate(userNewRequestPassword);

            response.ShouldHaveAnyValidationError();
        }
    }
}