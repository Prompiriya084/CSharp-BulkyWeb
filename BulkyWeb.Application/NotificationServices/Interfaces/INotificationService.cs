using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices.Interfaces
{
    public interface INotificationService
    {
        Task Notify(INotificationMessage message);
    }
}
