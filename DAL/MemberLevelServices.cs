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
    /// Operation Class of Membership level
    /// </summary>
    public class MemberLevelServices
    {
        //Get all Membership level information
        public List<MemberLevel> GetMemberLevel()
        {
            //SQL Statement to prepare query
            string sql = "Select LevelId,LevelName,LevelMonths,MaxBorrowNum,MaxBorrowDays,Deposit from MemberLevel ";
            //Execution and return values
            try
            {
                //Receive SqlDataReader type
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //If it is not empty, it is stored <MemberLeveL>in</MemberLeveL> the list
                List<MemberLevel> objList = new List<MemberLevel>();
                //read
                while (objReader.Read())
                {
                    objList.Add(
                        new MemberLevel()
                        {
                            LevelId = Convert.ToInt32(objReader["LevelId"]),
                            LevelName = objReader["LevelName"].ToString(),
                            LevelMonths = Convert.ToInt32(objReader["LevelMonths"]),
                            MaxBorrowNum = Convert.ToInt32(objReader["MaxBorrowNum"]),
                            MaxBorrowDays = Convert.ToInt32(objReader["MaxBorrowDays"]),
                            Deposit = Convert.ToDouble(objReader["Deposit"]),
                        }
                        );
                }
                //Close read
                objReader.Close();
                //Return value
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
