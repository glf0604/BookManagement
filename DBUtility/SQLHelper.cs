﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DBUtility
{
    /// <summary>
    /// Common access classes that operate on SQL server databases
    /// </summary>
    class SQLHelper
    {
        //Connection string 
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();

        #region Standard SQL Statements 

        //Implementation of the deletion of the database and other changes
        public static int Update(string sql)
        {
            //Instantiate a connection
            SqlConnection conn = new SqlConnection(connString);
            //Instantiate Commnad
            SqlCommand cmd = new SqlCommand(sql, conn);
            //Execute and return results 
            try
            {
                //Open the Database
                conn.Open();
                //Returns the result, the return value is the number of rows affected, the int type
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //Close a database connection 
                conn.Close();
            }
        }
    }
}
