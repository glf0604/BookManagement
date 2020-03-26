﻿using System;
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
    }
}
