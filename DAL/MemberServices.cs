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

        //Generate a membership number
        public string BuildMemberId(int levelId)
        {
            //Preparing SQL queries
            string sql = "Select  top 1 MemberId from member where MemberLevel = @LevelId  order by MemberId desc ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@LevelId",levelId),
            };
            //execution
            try
            {
                //Receive execution results 
                object obj = SQLHelper.GetOneResult(sql, para);
                //judgment
                if (obj == null) return levelId.ToString("00") + "00000001";
                else
                {
                    return (levelId.ToString("00") + (Convert.ToInt32(obj.ToString().Substring(2)) + 1).ToString("00000000"));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        //Add a Member
        public int AddMember(Member objMember)
        {
            //Preparing SQL statements
            string sql = "Insert into Member(MemberId, MemberName, MemberCardId, MemberLevel, IdType, IdNumber, Gender, TelNo, Birthday, HomeAddress, MemberPhoto, CardStatus,";
            sql += " CardClosingDate, IsReturnDeposit, PayMethod, LoginId, OperatingTime, ReMarks) Values ";
            sql += "(@MemberId, @MemberName, @MemberCardId, @MemberLevel, @IdType, @IdNumber, @Gender, @TelNo, @Birthday, @HomeAddress, @MemberPhoto, @CardStatus,";
            sql += " @CardClosingDate, @IsReturnDeposit, @PayMethod, @LoginId, @OperatingTime, @ReMarks) ";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberId",objMember.MemberId),
                new SqlParameter("@MemberName",objMember.MemberName),
                new SqlParameter("@MemberCardId",objMember.MemberCardId),
                new SqlParameter("@MemberLevel",objMember.MemberLevel),
                new SqlParameter("@IdType",objMember.IdType),
                new SqlParameter("@IdNumber",objMember.IdNumber),
                new SqlParameter("@Gender",objMember.Gender),
                new SqlParameter("@TelNo",objMember.TelNo),
                new SqlParameter("@Birthday",objMember.Birthday),
                new SqlParameter("@HomeAddress",objMember.HomeAddress),
                new SqlParameter("@MemberPhoto",objMember.MemberPhoto),
                new SqlParameter("@CardStatus",objMember.CardStatus),
                new SqlParameter("@CardClosingDate",objMember.CardClosingDate),
                new SqlParameter("@IsReturnDeposit",objMember.IsReturnDeposit),
                new SqlParameter("@PayMethod",objMember.PayMethod),
                new SqlParameter("@LoginId",objMember.LoginId),
                new SqlParameter("@OperatingTime",objMember.OperatingTime),
                new SqlParameter("@ReMarks",objMember.ReMarks),
            };

            //Execute and return results
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Modify member
        public int UpdateMember(Member objMember)
        {
            //Preparing SQL statements
            string sql = "Update Member Set MemberCardId=@MemberCardId,MemberName=@MemberName,IdType=@IdType,IdNumber=@IdNumber,Gender=@Gender,TelNo=@TelNo,";
            sql += "Birthday=@Birthday,HomeAddress=@HomeAddress,MemberPhoto=@MemberPhoto,CardStatus=@CardStatus,CardClosingDate=@CardClosingDate,";
            sql += "ReMarks=@ReMarks Where MemberId=@MemberId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberId",objMember.MemberId),
                new SqlParameter("@MemberName",objMember.MemberName),
                new SqlParameter("@MemberCardId",objMember.MemberCardId),
                new SqlParameter("@MemberLevel",objMember.MemberLevel),
                new SqlParameter("@IdType",objMember.IdType),
                new SqlParameter("@IdNumber",objMember.IdNumber),
                new SqlParameter("@Gender",objMember.Gender),
                new SqlParameter("@TelNo",objMember.TelNo),
                new SqlParameter("@Birthday",objMember.Birthday),
                new SqlParameter("@HomeAddress",objMember.HomeAddress),
                new SqlParameter("@MemberPhoto",objMember.MemberPhoto),
                new SqlParameter("@CardStatus",objMember.CardStatus),
                new SqlParameter("@CardClosingDate",objMember.CardClosingDate),
                new SqlParameter("@IsReturnDeposit",objMember.IsReturnDeposit),
                new SqlParameter("@PayMethod",objMember.PayMethod),
                new SqlParameter("@LoginId",objMember.LoginId),
                new SqlParameter("@OperatingTime",objMember.OperatingTime),
                new SqlParameter("@ReMarks",objMember.ReMarks),
            };

            //Execute and return results
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Delete member
        public int DeleteMember(string memberId)
        {
            //Preparing SQL statements
            string sql = "Delete from Member Where MemberId=@MemberId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberId",memberId),
            };

            //execute
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

