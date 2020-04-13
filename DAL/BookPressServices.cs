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
    /// Operation Class of press information
    /// </summary>
 
    public class BookPressServices
    {
        //Get information about the publisher
        public DataTable GetBookPress(string pressId = "", string pressName = "")
        {
            //Preparing SQL statements
            string sql = "Select PressId, PressName, PressTel, PressContact, PressAddress from BookPress ";
            sql += " Where PressId Like @PressId And PressName Like @PressName";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",'%'+pressId+'%'),
                new SqlParameter("@PressName",'%'+pressName+'%'),
            };

            //Execute and return results
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                //Define a DataTable 
                DataTable dt = new DataTable();
                //Load the SqlDataReader data into the DataTable
                dt.Load(objReader);
                //Return information
                return dt;
            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Generate a press number and return
        public string BuildNewPressId()
        {
            //Prepare SQL: Get the largest one PressId 
            string sql = "Select TOP 1 PressId From BookPress Order by PressId DESC";

            //Execute and return results
            try
            {
                object obj = SQLHelper.GetOneResult(sql);
                //Judgment
                if (obj == null) return "1000";
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

        //Determine if the Publisher name exists
        public bool IsExistPressName(string pressName)
        {
            //Preparing SQL statements
            string sql = "Select PressId from BookPress Where PressName=@PressName";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressName",pressName),
            };
            //Execute and return results
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        //Get Publisher name
        public string GetPressNameById(int pressId)
        {
            // Preparing SQL statements
            string sql = "Select PressName from BookPress Where PressId=@PressId ";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",pressId),
            };

            //Execute and return results
            try
            {
                return SQLHelper.GetOneResult(sql, para).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get List of publishing houses (Id,Name)
        public List<BookPress> GetPressList()
        {
            //Preparing SQL statements
            string sql = "Select PressId,PressName from BookPress";

            //Execute and return results
            try
            {
                //Receive SqlDataReader return value
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //If it is empty
                if (!objReader.HasRows) return null;
                //read
                List<BookPress> objList = new List<BookPress>();
                while (objReader.Read())
                {
                    objList.Add(
                        new BookPress()
                        {

                            PressId = Convert.ToInt32(objReader["PressId"]),
                            PressName = objReader["PressName"].ToString(),
                        }
                        );
                }
                //Close Read
                objReader.Close();
                //Return
                return objList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Add publisher information
        public int AddBookPress(BookPress objBookPress)
        {
            //Preparing SQL statements
            string sql = "Insert into BookPress (PressId, PressName, PressTel, PressContact, PressAddress ) ";
            sql += " values (@PressId, @PressName,@PressTel, @PressContact, @PressAddress) ";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",objBookPress.PressId),
                new SqlParameter("@PressName",objBookPress.PressName),
                new SqlParameter("@PressTel",objBookPress.PressTel),
                new SqlParameter("@PressContact",objBookPress.PressContact),
                new SqlParameter("@PressAddress",objBookPress.PressAddress),
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

        //Add publisher information
        public int UpdateBookPress(BookPress objBookPress)
        {
            //Preparing SQL statements
            string sql = "Update BookPress Set PressName= @PressName,PressTel=@PressTel,PressContact=@PressContact, PressAddress=@PressAddress ";
            sql += "  Where PressId=@PressId ";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",objBookPress.PressId),
                new SqlParameter("@PressName",objBookPress.PressName),
                new SqlParameter("@PressTel",objBookPress.PressTel),
                new SqlParameter("@PressContact",objBookPress.PressContact),
                new SqlParameter("@PressAddress",objBookPress.PressAddress),
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

        //Delete Publisher information
        public int DeleteBookPress(int pressId)
        {
            //Preparing SQL statements
            string sql = "Delete From BookPress  Where PressId=@PressId ";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",pressId),
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
    }
}