using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests.Api.Users
{
    public class HandlerUserTests
    {
        Mock<IUsers> _repository;
        Mock<IMediator> _mediator;
        Mock<ILogger<CreateUser>> _logger;
        public HandlerUserTests()
        {
            _repository = new Mock<IUsers>();
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<CreateUser>>();
        }

        [Fact]
        public async Task CreateUserSuccessfully()
        {
            var newUser = new NewUser()
            {
                Email = "silverio.des.vargas@gmail.com",
                Name = "Lucas Silvério"
            };
            var createUser = new CreateUser(_repository.Object, _mediator.Object, _logger.Object);
            var result = await createUser.Handle(newUser, default(CancellationToken));
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Create_Failed_By_Invalid_Info()
        {
            var newUser = new NewUser();
            var createUser = new CreateUser(_repository.Object, _mediator.Object, _logger.Object);
            var result = await createUser.Handle(newUser, default(CancellationToken));
            Assert.False(result.Success);
        }
    }
}