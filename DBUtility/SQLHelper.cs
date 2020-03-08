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
        //Get the result set--SqlDataReader type
        public static SqlDataReader GetReader(string sql)
        {
            //Instantiation sqlConnection 
            SqlConnection conn = new SqlConnection(connString);
            //Instantiation SqCommand
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                //Open connection 
                conn.Open();
                //Returns the result, the return value SqlDataReader type
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region SQL Statement with parameters 
        //Implementation of the deletion of the database and other changes
        public static int Update(string sql, SqlParameter[] para)
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
                //Determine if the parameter is empty
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
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
        //Get a single result (first row first column)
        public static object GetOneResult(string sql, SqlParameter[] para)
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
                //Determine if the parameter is empty
                if (para != null)
                {
                    cmd.Parameters.AddRange(para);
                }
                //Returns the result, the return value is the first column of the first row, the Object type
                return cmd.ExecuteScalar();
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
