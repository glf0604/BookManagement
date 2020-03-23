using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// Method classes for logged-on user actions
    /// </summary>
    public class SysAdminsServices
    {
        /// <summary>
        /// Authenticate User Logins
        /// </summary>
        /// <param name="objSysAdmins">User's Class</param>
        /// <returns>Return value SysAdmins</returns>
        public SysAdmins Login(SysAdmins objSysAdmins)
        {

            //Preparing SQL statements
            string sql = "Select LoginId, LoginPwd, UserName, IsDisable, IsSuperUser, LastLoginTime from SysAdmins ";
            sql += "where LoginId=@LoginId And LoginPwd=@LoginPwd ";
            //Preparing parameters for SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",objSysAdmins.LoginId),
                new SqlParameter("@LoginPwd",objSysAdmins.LoginPwd),
            };

            //Execute and return
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //If it is empty, returns null
                if (!objReader.HasRows) return null;

                //Not empty, processing data
                if (objReader.Read())
                {
                    objSysAdmins.UserName = objReader["UserName"].ToString();
                    objSysAdmins.IsDisable = Convert.ToBoolean(objReader["IsDisable"]);
                    objSysAdmins.IsSuperUser = Convert.ToBoolean(objReader["IsSuperUser"]);
                    objSysAdmins.LastLoginTime = Convert.ToDateTime(objReader["LastLoginTime"]);
                }
                //Close Read 
                objReader.Close();
                //Return Value
                return objSysAdmins;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
