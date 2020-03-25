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
    }
}
