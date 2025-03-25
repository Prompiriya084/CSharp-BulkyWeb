using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices
{
    public class NotificationMessage
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Footer { get; set; }

        private const string defaultFrom = "no-reply@company.com";
        private const string defaultSubject = "Notification Alert";
        private const string defaultFooter = "Best regards, Company Team";

        // Constructor(รองรับแบบกำหนด `From`)
        public NotificationMessage(string from, string to, string subject, string body, string footer)
        {
            From = string.IsNullOrWhiteSpace(from) ? defaultFrom : from;
            To = string.IsNullOrWhiteSpace(to) ? throw new ArgumentException("ToEmail is required.") : to;
            Subject = string.IsNullOrWhiteSpace(subject) ? defaultSubject : subject;
            Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.") : body;
            Footer = defaultFooter;
        }

        // Constructor Overload (รองรับแบบไม่กำหนด `From`)
        public NotificationMessage(string to, string body)
        : this(defaultFrom, to, defaultSubject, body, defaultFooter) // เรียกใช้ Constructor ด้านบน
        {
        }
    }
}
