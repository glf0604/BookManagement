using System;
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
        //Whether it's a email?
        public static bool IsEmail(string txt)
        {
            Regex objRegex = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            return objRegex.IsMatch(txt);
        }
        //Whether it's a telephone? 
        public static bool IsMobile(string txt)
        {
            Regex objRegex = new Regex(@"^[1][3578]\d{9}$");
            return objRegex.IsMatch(txt);
        }
        //Whether it is Chinese characters?
        public static bool IsChinese(string txt)
        {
            Regex objRegex = new Regex(@"^[\u4e00-\u9fa5]{0,}$");
            return objRegex.IsMatch(txt);
        }
    }
}
