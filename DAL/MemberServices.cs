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
    }
}
