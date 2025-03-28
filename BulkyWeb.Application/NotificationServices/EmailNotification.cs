﻿using BulkyWeb.Application.NotificationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.NotificationServices
{
    public class EmailNotification : INotification
    {
        private readonly string _smtpClientString;
        public EmailNotification(string smtpClientString) 
        {
            _smtpClientString = smtpClientString;
        }
        public async Task SendAsync(INotificationMessage message)
        {
            try
            {
                if (message is not MailNotificationMessage emailMessage)
                {
                    throw new Exception("Invalid message type for EmailNotification.");
                }
                var smtpClient = new SmtpClient(_smtpClientString); // Ip of mail services

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(emailMessage.From),
                    Subject = $"{emailMessage.Subject}",
                    Body = emailMessage.Body + emailMessage.Footer,
                    //"<p class='fs-2'>Best regard.</p><h3>Auto process by test system.</h4>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(emailMessage.To);

                foreach (var ccEmail in emailMessage.cc)
                {
                    mailMessage.CC.Add(ccEmail);
                }
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
