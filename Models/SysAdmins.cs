using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    /// <summary>
    /// The entity class used to represent the logged-on user
    /// </summary>
    public class SysAdmins
    {
        public int LoginId { get; set; }   //LoginId
        public string LoginPwd { get; set; }   //LoginPwd
        public string UserName { get; set; }   //UserName 
        public bool IsDisable { get; set; }   //IsDisable
        public bool IsSuperUser { get; set; }   //IsSuperUser 
        public DateTime LastLoginTime { get; set; }   //LastLoginTime
    }
}
