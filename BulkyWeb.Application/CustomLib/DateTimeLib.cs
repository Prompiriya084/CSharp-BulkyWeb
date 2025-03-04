using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulkyWeb.Application.CustomLib.Interfaces;

namespace BulkyWeb.Application.CustomLib
{
    public class DateTimeLib : IDateTimeLib
    {
        public DateTimeLib()
        {
        }
        public string GetTextMonth(int month)
        {
            if (month < 1 || month > 12)
                throw new ArgumentOutOfRangeException(nameof(month), "Month must be between 1 and 12.");

            return new DateTime(1, month, 1).ToString("MMMM");
        }
    }
}
