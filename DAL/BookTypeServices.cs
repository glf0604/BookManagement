using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    /// <summary>
    /// Methods of operation for book types
    /// </summary>
    public class BookTypeServices
    {
        public DataTable GetBookType()
        {
            string sql = "Select TypeId,TypeName,ParentTypeId,TypeDESC from BookType";
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                DataTable dt = new DataTable();
                dt.Load(objReader);
                return dt;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string GetTypeDESC(int typeId)
        {
            string sql = "Select TypeDESC from BookType Where TypeId=@TypeId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            try
            {
                return SQLHelper.GetOneResult(sql, para).ToString();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public BookType GetParentType(int typeId)
        {
            string sql = "Select T1.TypeDESC,T2.TypeId ,T2.TypeName from BookType AS T1 Inner Join BookType AS T2 On T1.ParentTypeId = T2.TypeId Where T1.TypeId = @TypeId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                BookType objBookType = new BookType();
                if(objReader.Read())
                {
                    objBookType = new BookType
                    {
                        DESC = objReader["TypeDESC"].ToString(),
                        TypeId = Convert.ToInt32(objReader["TypeId"]),
                        TypeName = objReader["TypeName"].ToString(),
                    };
                }
                objReader.Close();
                return objBookType;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public string BuildNewTypeId(int typeId)
        {
            string sql = "Select top 1  TypeId, TypeName, ParentTypeId, TypeDESC from BookType Where ParentTypeId = @TypeId order by TypeId DESC";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };
            try
            {
                object obj = SQLHelper.GetOneResult(sql, para);
                if (obj == null) return typeId.ToString() + "01";
                else
                {
                    return (Convert.ToInt32(obj) + 1).ToString();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        //Determine if the current Id number has a subclass
        public bool IsExistSub(int typeId)
        {
            //Preparing SQL 
            string sql = "Select typeId from BookType Where ParentTypeId=@ParentTypeId";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@ParentTypeId",typeId),
            };

            //Perform
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Determine if the category name exists
        public bool IsExistTypeName(string typeName)
        {
            //Preparing SQL
            string sql = "select TypeId from BookType where TypeName=@TypeName";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeName",typeName),
            };

            //Perform
            try
            {
                if (SQLHelper.GetOneResult(sql, para) == null) return false;
                else return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        //Gets the name of the category
        public string[] GetTypeNameById(int typeId)
        {

            //Preparing SQL statements
            string sql = "Select T1.TypeName AS ParentTypeName, T2.TypeName As TypeName from BookType AS T1 Inner Join BookType AS T2 ";
            sql += "on T1.TypeId = T2.ParentTypeId  where T2.TypeId = @TypeId ";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Submit
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //Determine if it is empty
                if (!objReader.HasRows) return null;
                //Read
                string[] TypeName = new string[2];
                if (objReader.Read())
                {
                    TypeName[0] = objReader["ParentTypeName"].ToString();
                    TypeName[1] = objReader["TypeName"].ToString();
                }
                //Close
                objReader.Close();
                //Return
                return TypeName;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
