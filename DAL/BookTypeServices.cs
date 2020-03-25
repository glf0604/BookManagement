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
    }
}
