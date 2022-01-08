using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Api.Auth;
using FluentEmail.Core;
using FluentEmail.Smtp;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Api.Users
{
    public class WelcomeNotification : INotification
    {
        public WelcomeNotification(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class SendWelcomeEmail : INotificationHandler<WelcomeNotification>
    {
        IFluentEmail _email;
        IConfiguration _configuration;
        public string Token { get; private set; }
        public SendWelcomeEmail(IFluentEmail email, IConfiguration configuration)
        {
            _email = email;
            _configuration = configuration;
        }
        public async Task Handle(WelcomeNotification notification, CancellationToken cancellationToken)
        {
            var link = _configuration["Auth:ActivationLink"];
            Token = _configuration.GenerateToken(notification.Email, notification.Name);
            await _email
                .To(notification.Email)
                .Subject("Couple Finance")
                .Body($"Bem vindo {notification.Name}, acesse o link: {link}{Token}")
                .SendAsync();
        }
    }
}