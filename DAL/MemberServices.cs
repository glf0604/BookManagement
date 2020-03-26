using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Models;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// Method classes for member operations
    /// </summary>
    public class MemberServices
    {
        //Get member Information
        public DataTable GetMember(string memberCardId = "", string memberId = "", string memberName = "", string telNo = "")
        {
            //Preparing SQL statements
            string sql = "Select MemberId, MemberName, MemberCardId, MemberLevel, IdType, IdNumber, Gender, TelNo, Birthday, HomeAddress, MemberPhoto, CardStatus,";
            sql += " CardClosingDate, IsReturnDeposit, PayMethod, LoginId, OperatingTime, ReMarks from Member  ";
            sql += " Where MemberCardId Like @MemberCardId And MemberId Like @MemberId And MemberName Like @MemberName And TelNo Like @TelNo ";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberCardId",'%'+memberCardId+'%'),
                new SqlParameter("@MemberId",'%'+memberId+'%'),
                new SqlParameter("@MemberName",'%'+memberName+'%'),
                new SqlParameter("@TelNo",'%'+telNo+'%'),
            };

            //Execute and return results
            try
            {
                //Receive with SqlDataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Instantiation of a DataTable
                DataTable dt = new DataTable();
                //Load the SqlDataReader into the DataTable
                dt.Load(objReader);
                //Close SQLDataReader
                objReader.Close();
                //return 
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get the details of a member through a member Id
        public Member GetMemberById(string memberId)
        {
            //Preparing SQL statements
            string sql = "Select MemberId, MemberName, MemberCardId, MemberLevel, IdType, IdNumber, Gender, TelNo, Birthday, HomeAddress, MemberPhoto, CardStatus,";
            sql += " CardClosingDate, IsReturnDeposit, PayMethod, LoginId, OperatingTime, ReMarks from Member  Where MemberId=@MemberId ";


            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberId",memberId),
            };

            //Execute and return results
            try
            {
                //Receive return values using SQLDataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Instantiate Member Object
                Member objMember = new Member();
                //Read
                if (objReader.Read())
                {
                    objMember = new Member()
                    {
                        MemberId = objReader["MemberId"].ToString(),
                        MemberName = objReader["MemberName"].ToString(),
                        MemberCardId = objReader["MemberCardId"].ToString(),
                        MemberLevel = Convert.ToInt32(objReader["MemberLevel"]),
                        IdType = objReader["IdType"].ToString(),
                        IdNumber = objReader["IdNumber"].ToString(),
                        Gender = objReader["Gender"].ToString(),
                        TelNo = objReader["TelNo"].ToString(),
                        Birthday = Convert.ToDateTime(objReader["Birthday"]),
                        HomeAddress = objReader["HomeAddress"].ToString(),
                        MemberPhoto = objReader["MemberPhoto"].ToString(),
                        CardStatus = objReader["CardStatus"].ToString(),
                        CardClosingDate = Convert.ToDateTime(objReader["CardClosingDate"]),
                        IsReturnDeposit = Convert.ToBoolean(objReader["IsReturnDeposit"]),
                        PayMethod = objReader["PayMethod"].ToString(),
                        LoginId = Convert.ToInt32(objReader["LoginId"]),
                        OperatingTime = Convert.ToDateTime(objReader["OperatingTime"]),
                        ReMarks = objReader["ReMarks"].ToString(),
                    };
                }
                //Close Read
                objReader.Close();
                //Return
                return objMember;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Get the details of a member with a membership card
        public Member GetMemberByCardId(string memberCardId)
        {
            //Preparing SQL statements
            string sql = "Select MemberId, MemberName, MemberCardId, MemberLevel, IdType, IdNumber, Gender, TelNo, Birthday, HomeAddress, MemberPhoto, CardStatus,";
            sql += " CardClosingDate, IsReturnDeposit, PayMethod, LoginId, OperatingTime, ReMarks from Member  Where MemberCardId=@MemberCardId ";


            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberCardId",memberCardId),
            };

            //Execute and return results
            try
            {
                //Receive return values using SQLDataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Instantiate Member Object
                Member objMember = new Member();
                //Read
                if (objReader.Read())
                {
                    objMember = new Member()
                    {
                        MemberId = objReader["MemberId"].ToString(),
                        MemberName = objReader["MemberName"].ToString(),
                        MemberCardId = objReader["MemberCardId"].ToString(),
                        MemberLevel = Convert.ToInt32(objReader["MemberLevel"]),
                        IdType = objReader["IdType"].ToString(),
                        IdNumber = objReader["IdNumber"].ToString(),
                        Gender = objReader["Gender"].ToString(),
                        TelNo = objReader["TelNo"].ToString(),
                        Birthday = Convert.ToDateTime(objReader["Birthday"]),
                        HomeAddress = objReader["HomeAddress"].ToString(),
                        MemberPhoto = objReader["MemberPhoto"].ToString(),
                        CardStatus = objReader["CardStatus"].ToString(),
                        CardClosingDate = Convert.ToDateTime(objReader["CardClosingDate"]),
                        IsReturnDeposit = Convert.ToBoolean(objReader["IsReturnDeposit"]),
                        PayMethod = objReader["PayMethod"].ToString(),
                        LoginId = Convert.ToInt32(objReader["LoginId"]),
                        OperatingTime = Convert.ToDateTime(objReader["OperatingTime"]),
                        ReMarks = objReader["ReMarks"].ToString(),
                    };
                }
                //Close read
                objReader.Close();
                //return
                return objMember;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
