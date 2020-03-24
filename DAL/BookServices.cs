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
    }
}
