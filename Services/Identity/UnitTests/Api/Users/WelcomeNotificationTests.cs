using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace UnitTests.Api.Users
{
    public class WelcomeNotificationTests
    {

        IConfigurationRoot _configuration;
        public WelcomeNotificationTests()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
        }

        [Fact]
        public async Task Welcome_test_notification()
        {

            var configuration = new Mock<IConfiguration>();

            var fluentEmail = new Mock<IFluentEmail>();
            fluentEmail.Setup(m => m.To(It.IsAny<string>())).Returns(fluentEmail.Object);
            fluentEmail.Setup(m => m.Subject(It.IsAny<string>())).Returns(fluentEmail.Object);
            fluentEmail.Setup(m => m.Body(It.IsAny<string>(), false)).Returns(fluentEmail.Object);
            WelcomeNotification notification = new("Lucas Silverio", "silverio.des.vargas@gmail.com");

            var handler = new SendWelcomeEmail(fluentEmail.Object, _configuration);
            await handler.Handle(notification, default(CancellationToken));
            var body = $"Bem vindo Lucas Silverio, acesse o link: http://localhost:4200/identity/change-password/{handler.Token}";

            fluentEmail.Verify(f => f.To("silverio.des.vargas@gmail.com"), Times.Once());
            fluentEmail.Verify(f => f.Subject("Couple Finance"), Times.Once);
            fluentEmail.Verify(f => f.Body(body, false), Times.Once);
            fluentEmail.Verify(f => f.SendAsync(null), Times.Once);

        }
    }
}