using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using FluentEmail.Core;
using Moq;
using Xunit;

namespace UnitTests.Api
{
    public class WelcomeNotificationTests
    {
        [Fact]
        public async Task Welcome_test_notification()
        {

            var mockFluentEmail = new Mock<IFluentEmail>();

            mockFluentEmail.Setup(m => m.To(It.IsAny<string>())).Returns(mockFluentEmail.Object);
            mockFluentEmail.Setup(m => m.Subject(It.IsAny<string>())).Returns(mockFluentEmail.Object);
            mockFluentEmail.Setup(m => m.Body(It.IsAny<string>(), false)).Returns(mockFluentEmail.Object);

            var fluentEmailService = new SendWelcomeEmail(mockFluentEmail.Object);

            await fluentEmailService.Handle(new("Lucas Silverio", "silverio.des.vargas@gmail.com"), default(CancellationToken));

            mockFluentEmail.Verify(f => f.To("silverio.des.vargas@gmail.com"), Times.Once());
            mockFluentEmail.Verify(f => f.Subject("Bem vindo!"), Times.Once);
            mockFluentEmail.Verify(f => f.Body("Bem vindo Lucas Silverio", false), Times.Once);

            mockFluentEmail.Verify(f => f.SendAsync(null), Times.Once);

        }
    }
}