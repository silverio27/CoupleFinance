using System.Threading;
using System.Threading.Tasks;
using Api.SeedWork;
using Api.Users;
using MediatR;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace UnitTests.Api.Users
{
    public class ControllerUserTests
    {
        Mock<IMediator> _mediator;
        public ControllerUserTests()
        {
            _mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Create_User_OK()
        {
            _mediator.Setup(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)))
                  .ReturnsAsync(new Response("Usuário criado"));

            var controller = new UserController(_mediator.Object);
            var result = await controller.Create(It.IsAny<NewUser>());
            var objectResult = (result.Result as ObjectResult);

            _mediator.Verify(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)), Times.Once);
            Assert.Equal(200, objectResult?.StatusCode);
            Assert.Equal("Usuário criado", ((Response)objectResult.Value).Message);
        }

        [Fact]
        public async Task Create_User_Bad()
        {
            _mediator.Setup(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)))
                  .ReturnsAsync(new Response("Não foi possível criar o usuário", false));

            var controller = new UserController(_mediator.Object);
            var result = await controller.Create(It.IsAny<NewUser>());
            var objectResult = (result.Result as ObjectResult);

            _mediator.Verify(x => x.Send(It.IsAny<NewUser>(), default(CancellationToken)), Times.Once);
            Assert.Equal(400, objectResult?.StatusCode);
            Assert.False(((Response)objectResult.Value).Success);
        }
    }
}