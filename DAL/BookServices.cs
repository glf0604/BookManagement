﻿using System;
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
    /// Book operation method class
    /// </summary>
   public class BookServices
    {
        //Get information about a book 
        public DataTable GetBook(string isbn = "", string bookId = "", string bookName = "", string bookAuthor = "")
        {
            //Preparing SQL statements
            string sql = "Select BookId, BookName, BookType, ISBN, BookAuthor, BookPress, BookImage, BookPublishDate, StorageInNum, StorageInDate, InventoryNum, BorrowedNum ";
            sql += " from Book Where ISBN Like @ISBN And BookId Like @BookId And BookName Like @BookName And BookAuthor Like @BookAuthor ";

            //Prepare the parameters to which the SQL query is
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ISBN",'%'+isbn+'%'),
                new SqlParameter("@BookId",'%'+bookId+'%'),
                new SqlParameter("@BookName",'%'+bookName+'%'),
                new SqlParameter("@BookAuthor",'%'+bookAuthor+'%'),
            };

            //Execute and get the return value
            try
            {
                //Receive results through SQLDataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Define a DataTable 
                DataTable dt = new DataTable();
                //Load the results into the DataTable
                dt.Load(objReader);
                //Closed
                objReader.Close();
                //Return
                return dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //Get more information about a book by book number
        public Book GetBookById(string bookId)
        {
            //Preparing SQL statements
            string sql = "Select BookId, BookName, BookType, ISBN, BookAuthor, BookPress,BookPrice, BookImage, BookPublishDate, StorageInNum, StorageInDate, InventoryNum, BorrowedNum ";
            sql += " from Book Where  BookId=@BookId ";

            //Prepare the parameters to which the SQL query is
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@BookId",bookId),
            };

            //Execute and receive return results
            try
            {
                //Receive results using SqlDataReader
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Read 
                Book objBook = new Book();
                if (objReader.Read())
                {
                    objBook = new Book()
                    {
                        BookId = objReader["BookId"].ToString(),
                        BookName = objReader["BookName"].ToString(),
                        BookType = Convert.ToInt32(objReader["BookType"]),
                        ISBN = objReader["ISBN"].ToString(),
                        BookAuthor = objReader["BookAuthor"].ToString(),
                        BookPress = Convert.ToInt32(objReader["BookPress"]),
                        BookPrice = Convert.ToDouble(objReader["BookPrice"]),
                        BookImage = objReader["BookImage"].ToString(),
                        BookPublishDate = Convert.ToDateTime(objReader["BookPublishDate"]),
                        StorageInNum = Convert.ToInt32(objReader["StorageInNum"]),
                        StorageInDate = Convert.ToDateTime(objReader["StorageInDate"]),
                        InventoryNum = Convert.ToInt32(objReader["InventoryNum"]),
                        BorrowedNum = Convert.ToInt32(objReader["BorrowedNum"]),
                    };
                }
                //Close
                objReader.Close();
                //Return
                return objBook;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
