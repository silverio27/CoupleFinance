using System;
using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using Domain.Users;
using Moq;
using Xunit;

namespace UnitTests.Api.Users
{
    public class HandlerUpdateUserTests
    {
        Mock<IUsers> _users;
        User _user;
        public HandlerUpdateUserTests()
        {
            _users = new();
            _user = Builders.UserBuild();
        }
        [Fact]
        public async Task Update_User_ok()
        {
            var updateUser = new UpdateUser(Guid.NewGuid(), "Lucas Silvério", "silverio.des.vargas@gmail.com");
            _users.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(_user);
            var handler = new ChangeUser(_users.Object);

            var result = await handler.Handle(updateUser, default(CancellationToken));

            Assert.True(result.Success);
            Assert.Equal("Usuário alterado.", result.Message);
            _users.Verify(x => x.Update(It.IsAny<User>()), Times.Once);
        }

        [Fact]
        public async Task Update_User_Failed()
        {
            var updateUser = new UpdateUser(Guid.Empty, "Lucas Silvério", "silverio.des.vargas@gmail.com");
            _user = null;
            _users.Setup(x => x.Get(It.IsAny<Guid>())).ReturnsAsync(_user);
            var handler = new ChangeUser(_users.Object);

            var result = await handler.Handle(updateUser, default(CancellationToken));

            Assert.False(result.Success);
            Assert.Equal("Usuário não encontrado.", result.Message);
        }

    }
}