using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Auth;
using Domain.Users;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitTests.Api.Auth
{
    public class HandlerRequestNewPassword
    {
        Mock<IUsers> _users;
        Mock<IFluentEmail> _email;
        IConfigurationRoot _configuration;
        User _user;
        public HandlerRequestNewPassword()
        {
            _users = new();
            _email = new();

            _user = Builders.UserBuild();

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();

            _email.Setup(m => m.To(It.IsAny<string>())).Returns(_email.Object);
            _email.Setup(m => m.Subject(It.IsAny<string>())).Returns(_email.Object);
            _email.Setup(m => m.Body(It.IsAny<string>(), false)).Returns(_email.Object);
        }

        [Fact]
        public async Task Request_New_Password_Ok()
        {
            _users.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(_user);
            var userRequestNewPassword = new UserRequestNewPassword("silverio.des.vargas@gmail.com");

            var handler = new RequestNewPassword(_users.Object, _email.Object, _configuration);
            var result = await handler.Handle(userRequestNewPassword, default(CancellationToken));

            var body = $"Para recuperar sua senha acesse o link: http://localhost:4200/identity/recovery-password/{handler.Token}";

            _email.Verify(f => f.To("silverio.des.vargas@gmail.com"), Times.Once());
            _email.Verify(f => f.Subject("Couple Finance"), Times.Once);
            _email.Verify(f => f.Body(body, false), Times.Once);
            _email.Verify(f => f.SendAsync(null), Times.Once);

        }

        [Fact]
        public async Task Request_New_Password_User_Not_Found()
        {
            _user = null;
            _users.Setup(x => x.Get(It.IsAny<string>())).ReturnsAsync(_user);
            var userRequestNewPassword = new UserRequestNewPassword(It.IsAny<string>());

            var handler = new RequestNewPassword(_users.Object, _email.Object, _configuration);
            var result = await handler.Handle(userRequestNewPassword, default(CancellationToken));

            Assert.False(result.Success);
            Assert.Equal("Usuário não encontrado", result.Message);

        }
    }
}