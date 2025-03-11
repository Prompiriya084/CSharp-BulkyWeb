using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib.Interfaces
{
    public interface IValidatorLib
    {
        string Passowrd(string password);
        string Email(string email);
    }
}
