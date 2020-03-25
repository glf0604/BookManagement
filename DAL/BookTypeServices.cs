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
    }
}
