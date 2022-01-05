using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ControllerUserTests
    {
        [Fact]
        public async Task CreateUserSuccessfully()
        {
            var newUser = new NewUser()
            {
                Email = "silverio.des.vargas@gmail.com",
                Name = "Lucas Silvério"
            };
            var repository = new Mock<IUsers>();
            var logger = new Mock<ILogger<CreateUser>>();
            var mediator = new Mock<IMediator>();
            mediator.Setup(x=> x.Send(It.IsAny<NewUser>(),It.IsAny<CancellationToken>()));
            var controller = new UserController(mediator.Object);
            var result = await controller.Create(newUser);
            Assert.True(result.Value.Success);
        }
    }
}