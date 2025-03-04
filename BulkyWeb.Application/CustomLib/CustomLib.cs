using BulkyWeb.Application.CustomLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib
{
    public class CustomLib : ICustomLib
    {
        public IMailLib Mail { get; set; }
        public IDateTimeLib Datetime { get; set; }
        public IFileLib File { get; set; }
        public IValidatorLib Validator { get; set; }
        public CustomLib() 
        {
            Mail = new MailLib();
            Datetime = new DateTimeLib();
            File = new FileLib();
            Validator = new ValidatorLib();
        }
    }
}
