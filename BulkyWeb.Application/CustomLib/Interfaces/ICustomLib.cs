using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Interfaces
{
    public interface ICustomLib
    {
        IMailLib Mail { get; }
        IDateTimeLib Datetime { get; }
        IFileLib File { get; }
        IValidatorLib Validator { get; }
    }
}
