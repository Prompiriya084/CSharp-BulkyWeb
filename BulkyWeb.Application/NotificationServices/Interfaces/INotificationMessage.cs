using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices.Interfaces
{
    public interface INotificationMessage
    {
        public string From { get; }
        public string To { get; }
        public string Body { get; }

        
    }
}
