using System.Threading;
using System.Threading.Tasks;
using Api.Users;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace UnitTests.Api.Users
{
    public class WelcomeNotificationTests
    {

        IConfiguration _configuration;
        Mock<IFluentEmail> _email;
        public WelcomeNotificationTests()
        {

            _configuration = Builders.ConfigurationBuilder();
            _email = Builders.EmailServiceBuilder();
        }

        [Fact]
        public async Task Welcome_test_notification()
        {

            var configuration = new Mock<IConfiguration>();

            WelcomeNotification notification = new("Lucas Silverio", "silverio.des.vargas@gmail.com");

            var handler = new SendWelcomeEmail(_email.Object, _configuration);
            await handler.Handle(notification, default(CancellationToken));
            var body = $"Bem vindo Lucas Silverio, acesse o link: http://localhost:4200/identity/change-password/{handler.Token}";

            _email.Verify(f => f.To("silverio.des.vargas@gmail.com"), Times.Once());
            _email.Verify(f => f.Subject("Couple Finance"), Times.Once);
            _email.Verify(f => f.Body(body, false), Times.Once);
            _email.Verify(f => f.SendAsync(null), Times.Once);

        }
    }
}