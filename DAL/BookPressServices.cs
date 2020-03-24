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
    /// Operation Class of publishing house information
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

        public string BuildNewPressId()
        {
            string sql = "Select Top 1 PressId From BookPress Order by PressId DESC";

            try
            {
                object obj = SQLHelper.GetOneResult(sql);
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
            string sql = "Select PressId from BookPress Where PressName=@PressName";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressName",pressName),
            };
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        
        //Get publisher name
        public string GetPressNameById(int pressId)
        {
            string sql = "Select PressName from BookPress Where PressId=@PressId";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter ("@PressId",pressId),
            };
            try
            {
                return SQLHelper.GetOneResult(sql, para).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Get list of publishing houses (Id,Name)
        public List<BookPress> GetPressList()
        {
            string sql = "Select PressId,PressName from BookPress";
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                if (!objReader.HasRows) return null;
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
                objReader.Close();
                return objList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //Add publisher information
        public int AddBookPress(BookPress objBookPress)
        {
            string sql = "Insert into BookPress(PressId,PressName,PressTel,PressContact,PressAddress";
            sql += "values (@pPressId,@PressName,@PressTel,@PressContact,@PressAddress)";

            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@pPressId",objBookPress.PressId),
                new SqlParameter("@PressName",objBookPress.PressName),
                new SqlParameter("@PressTel",objBookPress.PressTel),
                new SqlParameter ("@PressContact",objBookPress.PressContact),
                new SqlParameter ("@PressAddress",objBookPress.PressAddress)
            };
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        
    }
        //Delete publisher information
        public int DeleteBookPress(int pressId)
        {
            string sql = "Delete From BookPress Where PressId=@PressId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@PressId",pressId),
            };
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
