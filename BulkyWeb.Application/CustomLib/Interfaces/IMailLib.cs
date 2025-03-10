using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Interfaces
{
    public interface IMailLib
    {
        Task SendEmailAsync(string fromEmail, string toEmail, string subject, string message);
    }
}
