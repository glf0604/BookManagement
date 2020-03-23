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
        //Determine if the password is correct
        public bool Login(int loginId, string loginPwd)
        {
            //Preparing SQL statements
            string sql = "Select UserName from SysAdmins where LoginId=@LoginId And LoginPwd=@LoginPwd";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
                new SqlParameter("@LoginPwd",loginPwd),
            };
            //Execute and return
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        //Determine if the login account exists
        public bool IsExistLoginId(int loginId)
        {
            //Preparing SQL statements
            string sql = "Select LoginPwd from SysAdmins Where LoginId=@Loginid ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
            };

            //Execute and return
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
