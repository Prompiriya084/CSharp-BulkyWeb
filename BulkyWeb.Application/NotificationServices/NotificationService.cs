using BulkyWeb.Application.NotificationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices
{
    public class NotificationService : INotificationService
    {
        private readonly IEnumerable<INotification> _notification;
        public NotificationService(IEnumerable<INotification> nofitication) 
        {
            _notification = nofitication;
        }
        public async Task Notify(INotificationMessage message)
        {
            foreach (var notification in _notification)
            {
                await notification.SendAsync(message);
            }
        }
    }
}
