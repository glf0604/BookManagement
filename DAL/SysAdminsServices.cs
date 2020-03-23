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
        //Disable a login account 
        public int DisableLoginId(int loginId)
        {
            //Preparing SQL statements
            string sql = "Update SysAdmins Set IsDisable=1 Where LoginId=@LoginId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
            };

            //Execute and return 
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Change the last time you logged in
        public int UpdateLastLoginTime(int loginId)
        {
            //Preparing SQL statements
            string sql = "Update SysAdmins Set LastLoginTime=@LastLoginTime Where LoginId=@LoginId ";
            //Preparing variables 
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LastLoginTime",SQLHelper.GetServerTime()),
                new SqlParameter("@LoginId",loginId),
            };
            //Start Exectution
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Write a log
        public int WirteLoginLog(LoginLogs objLoginLogs)
        {
            //Preparing SQL statements
            string sql = "Insert into LoginLogs (LoginId, UserName, LoginComputer, LoginTime) ";
            sql += "Values (@LoginId, @UserName, @LoginComputer, @LoginTime); Select @@Identity";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",objLoginLogs.LogInId),
                new SqlParameter("@UserName",objLoginLogs.UserName),
                new SqlParameter("@LoginComputer",objLoginLogs.LoginComputer),
                new SqlParameter("@LoginTime",objLoginLogs.LoginTime),
            };

            //Execute and return
            try
            {
                return Convert.ToInt32(SQLHelper.GetOneResult(sql, para));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Write Exit Time
        public int WriteExitTime(int logId)
        {
            //Preparing SQL statements
            string sql = "Update LoginLogs Set ExitTime=@ExitTime Where LogId=@LogId";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ExitTime",SQLHelper.GetServerTime()),
                new SqlParameter("@LogId",logId),
            };

            //Execute and return
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get a name by Id
        public string GetUserName(int loginId)
        {
            //Preparing SQL
            string sql = "Select UserName from SysAdmins where LoginId=@LoginId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
            };
            //Execute and return
            try
            {
                return SQLHelper.GetOneResult(sql, para).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Modify Password
        public int ChangePassword(int loginId, string newPassword)
        {
            //Preparing SQL statements
            string sql = "Update SysAdmins Set LoginPwd=@LoginPwd Where LoginId=@LoginId";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginPwd",newPassword),
                new SqlParameter("@LoginId",loginId),
            };

            //Submit
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
