﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Models;
using Common;
using DBUtility;

namespace DAL
{
    /// <summary>
    /// About the operation method class of borrowing books
    /// </summary>
    public class BorrowBookServices
    {
        //Determine if a member has borrowed a book
        public bool IsBorrowedBook(string memberId)
        {
            //Preparing SQL statements
            string sql = "Select BorrowId from BorrowBook Where MemberId=@MemberId";

            //Preparing parameters in SQL statements
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@MemberId",memberId),
            };

            //Start execution and return value
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
    }
}
