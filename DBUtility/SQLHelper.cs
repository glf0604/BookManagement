using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DBUtility
{
    /// <summary>
    /// Common access classes that operate on SQL server databases
    /// </summary>
    class SQLHelper
    {
        //Connection string 
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

    }
}
