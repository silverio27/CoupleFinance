using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Users;
using Domain.Users;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace UnitTests
{
    public class HandlerUserTests
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
            var createUser = new CreateUser(repository.Object, mediator.Object, logger.Object);
            var result = await createUser.Handle(newUser, new System.Threading.CancellationToken());
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Create_Failed_By_Invalid_Info()
        {
            var newUser = new NewUser()
            {
                Email = "",
                Name = ""
            };
            var repository = new Mock<IUsers>();
            var logger = new Mock<ILogger<CreateUser>>(); 
            var mediator = new Mock<IMediator>();
            var createUser = new CreateUser(repository.Object, mediator.Object, logger.Object);
            var result = await createUser.Handle(newUser, new System.Threading.CancellationToken());
            Assert.False(result.Success);
        }
    }
}