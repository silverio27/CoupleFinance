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
        IConfigurationRoot _configuration;
        User _user;

        public HandlerAuthTests()
        {
            _credential = new Credential("silverio.des.vargas@gmail.com", "t2tT@x00_@");
            _repository = new Mock<IUsers>();
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            _user =Builders.UserBuild();
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
        public async Task Auth_Bad()
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