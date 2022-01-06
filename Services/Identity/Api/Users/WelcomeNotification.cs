using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using FluentEmail.Core;
using FluentEmail.Smtp;
using MediatR;

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
        public SendWelcomeEmail(IFluentEmail email)
        {
            _email = email;
        }
        public async Task Handle(WelcomeNotification notification, CancellationToken cancellationToken)
        {
            await _email
                .To(notification.Email)
                .Subject("Bem vindo!")
                .Body($"Bem vindo {notification.Name}")
                .SendAsync();
        }
    }
}