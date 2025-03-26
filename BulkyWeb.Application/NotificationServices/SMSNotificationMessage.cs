using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyWeb.Application.NotificationServices.Interfaces;

namespace BulkyWeb.Application.NotificationServices
{
    public class SMSNotificationMessage : INotificationMessage
    {
        public string From { get; }
        public string To { get; }
        public string Body { get; }
        private const string defaultFrom = "Test-NoReply";
        // Constructor(รองรับแบบกำหนด `From`)
        public SMSNotificationMessage(string from, string to, string body)
        {
            From = string.IsNullOrWhiteSpace(from) ? defaultFrom : from;
            To = string.IsNullOrWhiteSpace(to) ? throw new ArgumentException("ToEmail is required.") : to;            
            Body = string.IsNullOrWhiteSpace(body) ? throw new ArgumentException("Body is required.") : body;
        }

        // Constructor Overload (รองรับแบบไม่กำหนด `From`)
        public SMSNotificationMessage(string to, string body)
        : this(defaultFrom, to, body) // เรียกใช้ Constructor ด้านบน
        {

        }
    }
}
