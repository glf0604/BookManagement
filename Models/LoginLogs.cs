using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// The class that records the login log
    /// </summary>

    public class LoginLogs
    {
        public int LogId { get; set; }   //LogId
        public int LogInId { get; set; }   //LogInId
        public string UserName { get; set; }   //UserName
        public string LoginComputer { get; set; }   //LoginComputer
        public DateTime LoginTime { get; set; }   //LoginTime
        public DateTime ExitTime { get; set; }   //ExitTime
    }
}
