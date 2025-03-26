using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyWeb.Application.NotificationServices.Interfaces;

namespace BulkyWeb.Application.NotificationServices
{
    public class MailNotificationMessage : INotificationMessage
    {
        public string From { get; }
        public string To { get; }
        public string[] cc { get; }
        public string Body { get; }
        public string Subject { get; }
        public string Footer { get; }

        private const string defaultFrom = "no-reply@company.com";
        private const string defaultSubject = "Notification Alert";
        private const string defaultFooter = "Best regards, Company Team";
        // Constructor(รองรับแบบกำหนด `From`)
        public MailNotificationMessage(string from, string to, string[]? cc, string body, string subject, string footer)
        {
            From = string.IsNullOrWhiteSpace(from) ? defaultFrom : from;
            To = string.IsNullOrWhiteSpace(to) ? throw new ArgumentException("ToEmail is required.") : to;
            Subject = string.IsNullOrWhiteSpace(subject) ? defaultSubject : subject;
            Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.") : body;
            Footer = string.IsNullOrWhiteSpace(footer) ? defaultFooter : footer;
        }

        // Constructor Overload (รองรับแบบไม่กำหนด `From`)
        public MailNotificationMessage(string to, string body)
        : this(defaultFrom, to,null, defaultSubject, body, defaultFooter) // เรียกใช้ Constructor ด้านบน
        {
        }
    }
}
