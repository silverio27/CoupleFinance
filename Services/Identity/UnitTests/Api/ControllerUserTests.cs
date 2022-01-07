using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Api.Users;
using MediatR;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Api
{
    public class ControllerUserTests
    {
        [Fact]
        public async Task Create_User_OK()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)))
                  .ReturnsAsync(new Response("Usuário criado"));

            var controller = new UserController(mockMediator.Object);

            var result = await controller.Create(It.IsAny<NewUser>());

            mockMediator.Verify(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)), Times.Once);
            ObjectResult objectResult = (result.Result as ObjectResult);
            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal("Usuário criado", ((Response)objectResult.Value).Message);

        }
        [Fact]
        public async Task Create_User_Bad()
        {
            var mockMediator = new Mock<IMediator>();
            mockMediator.Setup(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)))
                  .ReturnsAsync(new Response("Não foi possível criar o usuário", false));

            var controller = new UserController(mockMediator.Object);

            var result = await controller.Create(It.IsAny<NewUser>());

            mockMediator.Verify(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)), Times.Once);
            ObjectResult objectResult = (result.Result as ObjectResult);
            Assert.Equal(400, objectResult?.StatusCode);
            Assert.False(((Response)objectResult.Value).Success);

        }
    }
}