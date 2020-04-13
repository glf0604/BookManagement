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

        //Gets the time of the database server
        public DateTime GetServerTime()
        {
            return SQLHelper.GetServerTime();
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

        //Get the log for login
        public DataTable GetLoginLogs(string loginId, string userName, DateTime start, DateTime end)
        {
            //Preparing SQL
            string sql = "Select LogId,LoginId,UserName,LoginComputer,LoginTime,ExitTime from LoginLogs ";
            sql += " Where LoginId Like  @LoginId And UserName Like @UserName And LoginTime > @Start And LoginTime< @End ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",'%'+loginId+'%'),
                new SqlParameter("@UserName",'%'+userName+'%'),
                new SqlParameter("@Start",start),
                new SqlParameter("@End",end),
            };

            //Get results
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                else
                {
                    DataTable dt = new DataTable();
                    dt.Load(objReader);
                    objReader.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get all the Administrators
        public DataTable GetSysAdmins(string loginId, string username)
        {
            //Preparing SQL
            string sql = "Select LoginId,UserName,IsDisable,IsSuperUser,LastLoginTime from SysAdmins ";
            sql += " Where LoginId Like @LoginId And UserName Like @UserName ";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",'%'+loginId+'%'),
                new SqlParameter("@UserName",'%'+username+'%'),
            };

            //Execute and return
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                else
                {
                    DataTable dt = new DataTable();
                    dt.Load(objReader);
                    objReader.Close();
                    return dt;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Generate Administrator number
        public string BuildLoginId()
        {
            //Preparing SQL statements
            string sql = "Select Top 1 LoginId from SysAdmins Order by LoginId DESC ";

            //Execute and return
            try
            {
                object obj = SQLHelper.GetOneResult(sql);
                if (obj == null) return "1001";
                else
                {
                    return (Convert.ToInt32(obj) + 1).ToString();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Add an Administrator
        public int AddSysAdmin(SysAdmins objSysAdmins)
        {
            //Preparing SQL statements
            string sql = "Insert into SysAdmins(LoginId,LoginPwd,UserName,IsDisable,IsSuperUser,LastLoginTime) Values ";
            sql += "(@LoginId,@LoginPwd,@UserName,@IsDisable,@IsSuperUser,@LastLoginTime) ";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",objSysAdmins.LoginId),
                new SqlParameter("@LoginPwd",objSysAdmins.LoginPwd),
                new SqlParameter("@UserName",objSysAdmins.UserName),
                new SqlParameter("@IsDisable",objSysAdmins.IsDisable),
                new SqlParameter("@IsSuperUser",objSysAdmins.IsSuperUser),
                new SqlParameter("@LastLoginTime",objSysAdmins.LastLoginTime),
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

        //Modify Admin
        public int UpdateSysAdmin(SysAdmins objSysAdmins)
        {
            //Preparing SQL statements
            string sql = "Update SysAdmins Set UserName=@UserName,IsDisable=@IsDisable,IsSuperUser=@IsSuperUser Where LoginId=@LoginId";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",objSysAdmins.LoginId),
                new SqlParameter("@LoginPwd",objSysAdmins.LoginPwd),
                new SqlParameter("@UserName",objSysAdmins.UserName),
                new SqlParameter("@IsDisable",objSysAdmins.IsDisable),
                new SqlParameter("@IsSuperUser",objSysAdmins.IsSuperUser),
                new SqlParameter("@LastLoginTime",objSysAdmins.LastLoginTime),
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

        //Enable Account
        public int EnableAdmin(int loginId)
        {

            //Preparing SQL statements
            string sql = "Update SysAdmins Set IsDisable=0 Where LoginId=@LoginId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LoginId",loginId),
            };

            //Excuction 
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
