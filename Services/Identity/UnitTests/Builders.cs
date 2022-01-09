using Domain.Users;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using Moq;

namespace UnitTests
{
    public static class Builders
    {
        private static User _user;
        public static User UserBuild()
        {
            _user = new User("Lucas Silvério", "silverio.des.vargas@gmail.com");
            return _user;
        }

        public static IConfigurationRoot _configuration;
        public static IConfiguration ConfigurationBuilder()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");
            _configuration = builder.Build();
            return _configuration;
        }

        public static Mock<IFluentEmail> _emailService;
        public static Mock<IFluentEmail> EmailServiceBuilder()
        {
            _emailService = new();
            _emailService.Setup(m => m.To(It.IsAny<string>())).Returns(_emailService.Object);
            _emailService.Setup(m => m.Subject(It.IsAny<string>())).Returns(_emailService.Object);
            _emailService.Setup(m => m.Body(It.IsAny<string>(), false)).Returns(_emailService.Object);
            return _emailService;
        }

    }
}