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
        //Count the total number of books borrowed
        public int GetBorrowBookNum(string borrowId)
        {
            //Preparing SQL statements: Total
            string sql = "Select count(*) from BorrowBookDetail where BorrowId=@BorrowId And IsReturn=0 And IsHandleOverdueorLost=0";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
            new SqlParameter("@BorrowId",borrowId),
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
        //Count the amount of expired books
        public int GetBorrowBookOverdue(string borrowId)
        {
            //Preparing SQL statements: Total
            string sql = "Select count(*) from BorrowBookDetail where BorrowId=@BorrowId And IsReturn=0 And IsHandleOverdueorLost=0 And IsOverdue=1";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
            new SqlParameter("@BorrowId",borrowId),
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
        //Get a breakdown of a member's library book
        public DataTable GetBookByBorrowId(string borrowId)
        {
            //Preparing query statements
            string sql = "Select Book.BookId,BookName,BookType,ISBN,BookAuthor,BookPress,BookPrice,BookImage,BookPublishDate,StorageInNum,StorageInDate,InventoryNum,BorrowedNum,BorrowBookDetail.BorrowDate,BorrowBookDetail.LastReturnDate,IsOverdue";
            sql += " from Book Inner join BorrowBookDetail on Book.BookId=BorrowBookDetail.BookId Where BorrowBookDetail.BorrowId=@BorrowId And IsReturn=0 And IsHandleOverdueorLost= 0 ";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BorrowId",borrowId),
            };

            //Perform
            try
            {
                //Receive return values using DataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Instantiation of a DataTable
                DataTable dt = new DataTable();
                //Load SqlDataReader into DataTable
                dt.Load(objReader);
                //Close
                objReader.Close();
                //Return
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Get DetailId
        public int GetDetailId(string borrowId, string bookId)
        {
            //Preparing SQL statements
            string sql = "select DetailId from BorrowBookDetail Where BorrowId=@BorrowId And BookId=@BookId  Order by DetailId DESC";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BookId",bookId),
                new SqlParameter("@BorrowId",borrowId),
            };

            //Execute and return results
            try
            {
                return Convert.ToInt32(SQLHelper.GetOneResult(sql, para));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Submit a return return information
        public bool CommitReturnBook(List<BorrowBookDetail> objListDetail, int loginId, Member objMember)
        {
            //Prepare a storage SQLList
            List<string> sqlList = new List<string>();



            //Traversing BorrowDetail 
            for (int i = 0; i < objListDetail.Count; i++)
            {
                string sql = string.Empty;
                //Sort by situation
                //Scenario 1: No overdue and no loss
                if (objListDetail[i].IsLost == false && objListDetail[i].IsOverdue == false)
                {
                    //Change BorrowBookDetial
                    sql = "Update BorrowBookDetail Set IsReturn=1,ReturnDate='{0}' Where DetailId={1}";
                    sql = string.Format(sql, DateTime.Now, objListDetail[i].DetailId);
                    sqlList.Add(sql);
                    //Change the BorrowBook and put the BorrowNum-1
                    sql = string.Empty;
                    sql = "Update BorrowBook Set BorrowedNum=BorrowedNum-1 where BorrowId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BorrowId);
                    sqlList.Add(sql);
                    //Change Book Inventory
                    sql = string.Empty;
                    sql = "Update Book Set InventoryNum=InventoryNum+1 where BookId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BookId);
                    sqlList.Add(sql);
                }
                else if (objListDetail[i].IsOverdue == true && objListDetail[i].IsLost == false)  //逾期
                {
                    //Change BorrowBookDetial
                    sql = "Update BorrowBookDetail Set IsReturn=1,ReturnDate='{0}' Where DetailId={1}";
                    sql = string.Format(sql, DateTime.Now, objListDetail[i].DetailId);
                    sqlList.Add(sql);
                    //Change BorrowBook，把BorrowNum-1
                    sql = string.Empty;
                    sql = "Update BorrowBook Set BorrowedNum=BorrowedNum-1 where BorrowId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BorrowId);
                    sqlList.Add(sql);
                    //Change Book Inventory
                    sql = string.Empty;
                    sql = "Update Book Set InventoryNum=InventoryNum+1 where BookId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BookId);
                    sqlList.Add(sql);
                    //Write ReturnBookRevenue
                    sql = string.Empty;
                    TimeSpan ts = DateTime.Now.Subtract(objListDetail[i].LastReturnDate);
                    sql = "Insert into [ReturnBookRevenue] ( DetailId, OverdueDays, OverdueAmount, BookCompensation, Poundage, TotalMoney, LoginId, OperatingTime) values(";
                    sql += "{0}, {1},{2},{3},{4},{5},{6},'{7}')";
                    sql = string.Format(sql, objListDetail[i].DetailId, ts.Days, ts.Days * 0.2, 0, 5.00, ts.Days * 0.2 + 5.00, loginId, DateTime.Now);
                    sqlList.Add(sql);
                }
                else   //Lost, or lost + overdue
                {

                    //Change BorrowBookDetial
                    sql = "Update BorrowBookDetail Set IsLost=1,IsHandleOverdueorLost=1,ReturnDate='{0}' Where DetailId={1}";
                    sql = string.Format(sql, DateTime.Now, objListDetail[i].DetailId);
                    sqlList.Add(sql);
                    //Change the BorrowBook and put the BorrowNum-1
                    sql = string.Empty;
                    sql = "Update BorrowBook Set BorrowedNum=BorrowedNum-1 where BorrowId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BorrowId);
                    sqlList.Add(sql);
                    //Change Book Inventory
                    sql = string.Empty;
                    sql = "Update Book Set StorageInNum=StorageInNum-1 where BookId='{0}'";
                    sql = string.Format(sql, objListDetail[i].BookId);
                    sqlList.Add(sql);
                    //Write ReturnBookRevenue
                    sql = string.Empty;
                    BookServices objBookServices = new BookServices();
                    double price = objBookServices.GetPriceById(objListDetail[i].BookId);
                    TimeSpan ts = DateTime.Now.Subtract(objListDetail[i].LastReturnDate);
                    sql = "Insert into [ReturnBookRevenue] ( DetailId, OverdueDays, OverdueAmount, BookCompensation, Poundage, TotalMoney, LoginId, OperatingTime) values(";
                    sql += "{0}, {1},{2},{3},{4},{5},{6},'{7}')";
                    sql = string.Format(sql, objListDetail[i].DetailId, ts.Days, ts.Days * 0.2, price, 5.00, ts.Days * 0.2 + 5.00 + price, loginId, DateTime.Now);
                    sqlList.Add(sql);
                }

            }

            //Submit
            try
            {
                return SQLHelper.UpdateByTransaction(sqlList);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //The book is checked by people.
        public DataTable QueryBook(DateTime start, DateTime end, string memberCardId = "", string memberId = "", string memberName = "")
        {
            //Preparing SQL 
            string sql = "Select ISBN,T1.BookId,BookName,BookAuthor,PressName from BorrowBookDetail AS T1 ";
            sql += "Inner Join Book As T2 On T1.BookId = T2.BookId Inner Join BookPress As T3 On T2.BookPress = T3.PressId ";
            sql += "Inner Join BorrowBook As T4 on T1.BorrowId=T4.BorrowId  Inner Join Member As T5 on T4.MemberId = T5.MemberId ";
            sql += " Where T5.MemberCardId Like @MemberCardId And T5.MemberId Like @MemberId And T5.MemberName Like @MemberName ";
            sql += " And BorrowDate >= @Start And BorrowDate <=@End ";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberCardId",'%'+memberCardId+'%'),
                new SqlParameter("@MemberId",'%'+memberId+'%'),
                new SqlParameter("@MemberName",'%'+memberName+'%'),
                new SqlParameter("@Start",start),
                new SqlParameter("@End",end),
            };

            //Submit a Query
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                DataTable dt = new DataTable();
                dt.Load(objReader);
                objReader.Close();
                return dt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
