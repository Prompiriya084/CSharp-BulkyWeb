﻿using BulkyWeb.Application.CustomLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BulkyWeb.Application.CustomLib
{
    public class ValidatorLib : IValidatorLib
    {
        public string Passowrd(string password)
        {
            string errMessage = null;
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$";
            if (!Regex.IsMatch(password, pattern))
            {
                errMessage = "Password must be 8-16 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character (@$!%*?&).";
            }

            return errMessage;
        }
        public string Email(string email)
        {
            string errMessage = null;
            string pattern = @"/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/";
            if (!Regex.IsMatch(email, pattern))
            {
                errMessage = "Email format is invalid.";
            }

            return errMessage;
        }
    }
}
