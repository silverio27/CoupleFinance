using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentEmail.Core;
using MediatR;

namespace Identity.Users.Notifications
{
    public class NewUserNotification : INotification
    {
        public string To { get; set; }
        public string Subject { get;  set; }
    }
    public class ActiveAccount : INotificationHandler<NewUserNotification>
    {
        private readonly IFluentEmail _fluentEmail;
        

        public ActiveAccount(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Handle(NewUserNotification notification, CancellationToken cancellationToken)
        {
            var template = new StringBuilder();
            template.Append(File.ReadAllText("Templates/Welcome.html"))
                .Replace("{{url}}", "www.google.com")
                .Replace("{{image}}","https://couplefinance.blob.core.windows.net/images/Earn_Rewards.png");
            await _fluentEmail
                .To(notification.To)
                .Subject(notification.Subject)
                .Body(template.ToString(), true)
                .SendAsync();
        }
    }
}