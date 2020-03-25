﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Check the judgment of the input
    /// </summary>
    public static class ValidateInput
    {
        //Whether it's a number?
        public static bool IsInteger(string txt)
        {
            Regex objRegex = new Regex(@"^[0-9]*$");
            return objRegex.IsMatch(txt);
        }
        
    }
}
