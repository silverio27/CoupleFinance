using System;
using Api.Users;
using Xunit;
using FluentValidation.TestHelper;

namespace UnitTests.Api.Users
{
    public class ValidateUpdateUserTests
    {
        UpdateUserValidator _validator;
        public ValidateUpdateUserTests()
        {
            _validator = new();
        }

        [Fact]
        public void Validate_User_OK()
        {
            var updateUser = new UpdateUser(Guid.NewGuid(), "Lucas Silvério", "silverio.des.vargas@gmail.com");

            var result = _validator.TestValidate(updateUser);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Validate_User_With_Errors()
        {
            var updateUser = new UpdateUser(Guid.Empty, "Lucas Silvério", "silverio.des.vargas@gmail.com");

            var result = _validator.TestValidate(updateUser);

            result.ShouldHaveAnyValidationError();
        }
    }
}