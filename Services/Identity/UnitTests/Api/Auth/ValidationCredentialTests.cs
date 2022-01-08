using Api.Auth;
using Xunit;
using FluentValidation.TestHelper;

namespace UnitTests.Api.Auth
{
    public class ValidationCredentialTests
    {
        [Fact]
        public void Credential_Ok()
        {
            var credential = new Credential("silverio.des.vargas@gmail.com","X23jjv_0@");
            var validator = new CredentialValidator();
            var result = validator.TestValidate(credential);

            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void Credential_Errors()
        {
            var credential = new Credential("","");
            var validator = new CredentialValidator();
            var result = validator.TestValidate(credential);

            result.ShouldHaveAnyValidationError();
        }
    }
}