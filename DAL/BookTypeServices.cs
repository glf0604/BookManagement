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
    /// Methods of operation for book categories
    /// </summary>

    public class BookTypeServices
    {
        //Get all category information
        public DataTable GetBookType()
        {

            //Preparing SQL statements 
            string sql = "Select TypeId, TypeName, ParentTypeId, TypeDESC from BookType";

            //Execute and return results
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //Define a DataTable 
                DataTable dt = new DataTable();
                //Load the DataReader into the DataTable
                dt.Load(objReader);
                //Return
                return dt;

            }

            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get a breakdown of the appropriate category 
        public string GetTypeDESC(int typeId)
        {
            //Preparing SQL queries 
            string sql = "Select TypeDESC from BookType Where TypeId=@TypeId";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Perform 
            try
            {
                return SQLHelper.GetOneResult(sql, para).ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Get parent Information
        public BookType GetParentType(int typeId)
        {
            //Preparing SQL 
            string sql = "Select T1.TypeDESC,T2.TypeId ,T2.TypeName from BookType AS T1 Inner Join BookType AS T2 On T1.ParentTypeId = T2.TypeId Where T1.TypeId = @TypeId";
            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Perform 
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                if (!objReader.HasRows) return null;
                //Read
                BookType objBookType = new BookType();
                if (objReader.Read())
                {
                    objBookType = new BookType
                    {
                        DESC = objReader["TypeDESC"].ToString(),
                        TypeId = Convert.ToInt32(objReader["TypeId"]),
                        TypeName = objReader["TypeName"].ToString(),
                    };
                }
                //Close Read
                objReader.Close();
                //Return
                return objBookType;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Generate a node number 
        public string BuildNewTypeId(int typeId)
        {
            //Preparing SQL statements
            string sql = "Select top 1  TypeId, TypeName, ParentTypeId, TypeDESC from BookType Where ParentTypeId = @TypeId order by TypeId DESC";
            //Prepare parameters for SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };
            //Execute and return
            try
            {
                object obj = SQLHelper.GetOneResult(sql, para);
                if (obj == null) return typeId.ToString() + "01";
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

        //Get List of book categories (TypeId,TypeName)
        public List<BookType> GetBookTypeList()
        {
            //Preparing SQL statements
            string sql = "Select TypeId, TypeName from BookType where ParentTypeId= 1";

            //Execute and return results
            try
            {
                //Receive SqlDataReader return value
                SqlDataReader objReader = SQLHelper.GetReader(sql);
                //If it's empty
                if (!objReader.HasRows) return null;
                //Read
                List<BookType> objList = new List<BookType>();
                while (objReader.Read())
                {
                    objList.Add(
                        new BookType()
                        {

                            TypeId = Convert.ToInt32(objReader["TypeId"]),
                            TypeName = objReader["TypeName"].ToString(),
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

        //Determine if a category number has a subclass 
        public bool IsExistSubType(int typeId)
        {
            //Preparing SQL statements
            string sql = "select TypeName from BookType Where ParentTypeId=@TypeId ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Submit
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

        //Gets the List of subclasses
        public List<BookType> GetSubBookTypeList(int typeId)
        {
            //Preparing SQL statements
            string sql = "Select TypeId, TypeName from BookType where ParentTypeId= @TypeId";

            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Execute and return results
            try
            {
                //Receive SqlDataReader return value
                SqlDataReader objReader = SQLHelper.GetReader(sql, para);
                //If it's empty
                if (!objReader.HasRows) return null;
                //Read
                List<BookType> objList = new List<BookType>();
                while (objReader.Read())
                {
                    objList.Add(
                        new BookType()
                        {

                            TypeId = Convert.ToInt32(objReader["TypeId"]),
                            TypeName = objReader["TypeName"].ToString(),
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

        //Add a book Category
        public int AddBookType(BookType objBookType)
        {
            //Preparing SQL statements
            string sql = "Insert into BookType(TypeId,TypeName,ParentTypeId,TypeDESC) Values(@TypeId,@TypeName,@ParentTypeId,@TypeDESC)";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",objBookType.TypeId),
                new SqlParameter("@TypeName",objBookType.TypeName),
                new SqlParameter("@ParentTypeId",objBookType.ParentTypeId),
                new SqlParameter("@TypeDESC",objBookType.DESC),
            };

            //Submit
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Modify a book category
        public int UpdateBookType(BookType objBookType)
        {
            //Preparing SQL statements
            string sql = "Update BookType Set TypeName= @TypeName , TypeDESC=@TypeDESC Where TypeId=@TypeId ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",objBookType.TypeId),
                new SqlParameter("@TypeName",objBookType.TypeName),
                new SqlParameter("@TypeDESC",objBookType.DESC),
            };

            //Summion 
            try
            {
                return SQLHelper.Update(sql, para);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //Delete a book category
        public int DeleteBookType(int typeId)
        {
            //Preparing SQL statements
            string sql = "Delete From BookType Where TypeId=@TypeId ";
            //Prepare parameters
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@TypeId",typeId),
            };

            //Submit
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
