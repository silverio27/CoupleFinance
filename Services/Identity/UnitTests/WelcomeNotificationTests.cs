using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Users;
using FluentEmail.Core;
using Moq;
using Xunit;

namespace UnitTests
{
    public class WelcomeNotificationTests
    {
        [Fact]
        public async Task Welcome_test_notification()
        {
            var welcome = new WelcomeNotification("Lucas Silvério", "silverio.des.vargas@gmail.com");
            var fluent = new Mock<IFluentEmail>();
            fluent.Setup(x => x.SendAsync(System.Threading.CancellationToken.None));
            var email = new SendWelcomeEmail(fluent.Object);


            await email.Handle(welcome, System.Threading.CancellationToken.None);
        }
    }
}