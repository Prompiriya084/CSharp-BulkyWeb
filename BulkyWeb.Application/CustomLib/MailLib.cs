using BulkyWeb.Application.CustomLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib
{
    public class MailLib : IMailLib
    {
        public MailLib() 
        {
        }
        public async Task SendEmailAsync(string fromEmail, string toEmail, string subject, string message)
        {
            try
            {
                //var CcEmails = new List<string> { "Prompiriya_P@hinothailand.com" };
                var smtpClient = new SmtpClient("xxx.xx.x.x"); // Ip of mail services

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = $"{subject}",
                    Body = message +
                    "<p class='fs-2'>Best regard.</p><h3>Auto process by test system.</h4>",
                    IsBodyHtml = true,
                };

                mailMessage.To.Add(toEmail);

                //foreach (var ccEmail in CcEmails)
                //{
                //    mailMessage.CC.Add(ccEmail);
                //}
                await smtpClient.SendMailAsync(mailMessage);
                //return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
