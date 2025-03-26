using BulkyWeb.Application.NotificationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices
{
    public class SMSNotification : INotification
    {
        public SMSNotification() { }
        public async Task SendAsync(INotificationMessage message)
        {
            try
            {
                if (message is not SMSNotificationMessage smsMessage)
                {
                    throw new Exception("Invalid message type for EmailNotification.");
                }
                Console.WriteLine($"Sending SMS from {smsMessage.From} to {message.To} : {smsMessage.Body} ");
                
                await Task.CompletedTask; // Simulating async behavior
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
