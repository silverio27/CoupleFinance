using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Users;
using Domain.Users;
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
            var createUser = new CreateUser(repository.Object, logger.Object);
            var result = await createUser.Handle(newUser, new System.Threading.CancellationToken());
            Assert.True(result.Success);
        }
    }
}