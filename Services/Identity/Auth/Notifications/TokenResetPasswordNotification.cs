using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentEmail.Core;
using MediatR;

namespace Identity.Auth.Notifications
{
    public class TokenResetPasswordNotification : INotification
    {
        public string CodeToResetPassword { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
    }

    public class TokenResetPassword : INotificationHandler<TokenResetPasswordNotification>
    {
        private IFluentEmail _fluentEmail;

        public TokenResetPassword(IFluentEmail fluentEmail)
        {
            _fluentEmail = fluentEmail;
        }

        public async Task Handle(TokenResetPasswordNotification notification, CancellationToken cancellationToken)
        {
            var template = new StringBuilder();
            template.Append(File.ReadAllText("Templates/ResetPassword.html"))
                .Replace("{{url}}", "www.google.com")
                .Replace("{{image}}", "https://couplefinance.blob.core.windows.net/images/Earn_Rewards.png");
            await _fluentEmail
                .To(notification.To)
                .Subject(notification.Subject)
                .Body(template.ToString(), true)
                .SendAsync();
        }
    }
}