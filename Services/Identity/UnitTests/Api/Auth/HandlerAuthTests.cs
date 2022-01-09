using System.Threading;
using System.Threading.Tasks;
using Api.Auth;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Domain.Users;

namespace UnitTests.Api.Auth
{
    public class HandlerAuthTests
    {
        Credential _credential;
        Mock<IUsers> _repository;
        IConfiguration _configuration;
        User _user;

        public HandlerAuthTests()
        {
            _credential = new Credential("silverio.des.vargas@gmail.com", "t2tT@x00_@");
            _repository = new Mock<IUsers>();

            _configuration = Builders.ConfigurationBuilder();
            _user = Builders.UserBuild();
        }

        [Fact]
        public async Task Auth_ok()
        {
            _user.ChangePassword(_credential.Password, _credential.Password);
            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(_user);

            var handler = new Authenticate(_repository.Object, _configuration);
            var result = await handler.Handle(_credential, default(CancellationToken));

            Assert.True(result.Success);

        }

        [Fact]
        public async Task Auth_when_user_provider_wrong_password()
        {
            _user.ChangePassword("t2tT@x00_@ERRO", "t2tT@x00_@ERRO");
            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(_user);

            var handler = new Authenticate(_repository.Object, _configuration);
            var result = await handler.Handle(_credential, default(CancellationToken));

            Assert.False(result.Success);
            Assert.Equal("A senha está incorreta.", result.Message);
        }

        [Fact]
        public async Task Auth_When_User_Not_Found()
        {
            _user = null;
            _repository.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(_user);

            var handler = new Authenticate(_repository.Object, _configuration);
            var result = await handler.Handle(_credential, default(CancellationToken));

            Assert.False(result.Success);
            Assert.Equal("Não existe um usuário com esse email", result.Message);
        }

    }
}