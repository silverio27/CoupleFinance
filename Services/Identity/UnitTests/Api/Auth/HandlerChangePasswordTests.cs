using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Auth;
using Domain.Users;
using Moq;
using Xunit;

namespace UnitTests.Api.Auth
{
    public class HandlerChangePasswordTests
    {
        Mock<IUsers> _users;
        User user;
        public HandlerChangePasswordTests()
        {
            _users = new Mock<IUsers>();
            user = Builders.UserBuild();
        }

        [Fact]
        public async Task Change_Password_Ok()
        {
            var newPassword = new NewPassword("silverio.des.vargas@gmail.com", "yyU39_@pPP", "yyU39_@pPP");
            _users.Setup(x => x.Get(newPassword.Email)).ReturnsAsync(user);
            var handler = new ChangePassword(_users.Object);
            var response = await handler.Handle(newPassword, default(CancellationToken));
            Assert.True(response.Success);
            _users.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Change_Password_Failed()
        {
            var newPassword = new NewPassword("", "yyU39_@pPP", "yyU39_@pPP");
            user = null;
            _users.Setup(x => x.Get(newPassword.Email)).ReturnsAsync(user);
            var handler = new ChangePassword(_users.Object);
            var response = await handler.Handle(newPassword, default(CancellationToken));
            Assert.False(response.Success);


        }
    }
}