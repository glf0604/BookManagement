﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Models;

namespace BookManagement
{
    public partial class frmBorrowReturnQuery : Form
    {
        //Define a DataTable 
        private DataTable dt = null;
        //Instantiate an action class
        private BorrowBookDetailServices objBorrowBookDetailServices = new BorrowBookDetailServices();

        public frmBorrowReturnQuery()
        {
            InitializeComponent();
            //Initialization of DataGridView
            dgvBook.AutoGenerateColumns = false;
            //Loading data
            LoadBookInfo();
        }
        //=========================================Control events=============================================

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //
            rbQueryNoBorrowed.Checked = false;
            rbQueryWelcomeTop100.Checked = false;
            rbQueryLostTop100.Checked = false;
            rbQueryOverdueTop100.Checked = false;

            //Preparation Date
            DateTime[] dtArray = GetStartOrEndDate();

            LoadBookInfo(dtArray);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            rbQueryNoBorrowed.Checked = false;
            rbQueryWelcomeTop100.Checked = false;
            rbQueryLostTop100.Checked = false;
            rbQueryOverdueTop100.Checked = false;

            //Clear
            txtQueryCardId.Text = string.Empty;
            txtQueryMemberId.Text = string.Empty;
            txtQueryMemberName.Text = string.Empty;

            //Choice Date
            rbQueryAll.Checked = true;

            //Executing queries
            LoadBookInfo();
        }
    }
}
