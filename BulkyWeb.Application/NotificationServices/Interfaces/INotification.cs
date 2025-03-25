using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices.Interfaces
{
    public interface INotification
    {
        Task SendAsync(NotificationMessage message);
    }
}
