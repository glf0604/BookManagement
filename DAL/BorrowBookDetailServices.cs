using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;
using DBUtility;
using Common;

namespace DAL
{
    /// <summary>
    /// The Operation class of book detail
    /// </summary>
    public class BorrowBookDetailServices
    {
        //Get a library detail by borrowId
        public List<BorrowBookDetail> GetDetailByBorrowId(string borrowId)
        {
            //Preparing SQL statements
            string sql = "Select DetailId, BorrowId, BookId, BorrowDate, LastReturnDate, IsReturn, IsOverdue, IsHandleOverdueorLost, ReturnDate ";
            sql += " from BorrowBookDetail Where BorrowId=@BorrowId And  IsReturn=0 And  IsHandleOverdueorLost = 0 ";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BorrowId",borrowId),
            };

            //Execute and return results
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Instantiation of a List
                List<BorrowBookDetail> objList = new List<BorrowBookDetail>();
                //Read to List
                while (objReader.Read())
                {
                    objList.Add(
                        new BorrowBookDetail()
                        {
                            DetailId = Convert.ToInt32(objReader["DetailId"]),
                            BorrowId = objReader["BorrowId"].ToString(),
                            BookId = objReader["BookId"].ToString(),
                            BorrowDate = Convert.ToDateTime(objReader["BorrowDate"]),
                            LastReturnDate = Convert.ToDateTime(objReader["LastReturnDate"]),
                            IsReturn = Convert.ToBoolean(objReader["IsReturn"]),
                            IsOverdue = Convert.ToBoolean(objReader["IsOverdue"]),
                            IsHandleOverdueorLost = Convert.ToBoolean(objReader["IsHandleOverdueorLost"]),
                            ReturnDate = Convert.ToDateTime(objReader["ReturnDate"]),
                        }
                        );
                }
                //Manage reads
                objReader.Close();
                //Return
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Update the database-determine if the book has expired
        public void UpdateOverdue(string borrowId)
        {
            //Define List 
            List<BorrowBookDetail> objList = GetDetailByBorrowId(borrowId);
            //Gets the current date
            DateTime today = Convert.ToDateTime(SQLHelper.GetServerTime().ToShortDateString());
            //Traversing List
            for (int i = 0; i < objList.Count; i++)
            {
                if (Convert.ToDateTime(objList[i].LastReturnDate.ToShortDateString()) < today)
                {
                    //Change this record to expire.
                    try
                    {
                        if (OverdueById(objList[i].DetailId) == 1)
                        {
                            //Successful！
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }
        }
        //Change the corresponding DetailId record to expired
        public int OverdueById(int detailId)
        {
            //Preparing SQL statements
            string sql = "Update BorrowBookDetail Set IsOverdue=1 Where DetailId=@DetailId ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
            new SqlParameter("@DetailId",detailId),
            };
            //Update
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
