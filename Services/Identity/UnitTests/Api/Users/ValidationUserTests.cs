using Api.Users;
using Xunit;
using FluentValidation.TestHelper;

namespace UnitTests.Api.Users
{
    public class ValidationUserTests
    {
        [Fact]
        public void New_User_Validation_OK()
        {
            var validator = new NewUserValidation();
            var newUser = new NewUser()
            {
                Email = "silverio.des.vargas@gmail.com",
                Name = "Lucas Silverio"
            };
            var result = validator.TestValidate(newUser);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void New_User_Validation_Bad()
        {
            var validator = new NewUserValidation();
            var newUser = new NewUser()
            {
                Email = "",
                Name = "Lucas Silverio"
            };
            var result = validator.TestValidate(newUser);

            result.ShouldHaveAnyValidationError();
        }
    }
}