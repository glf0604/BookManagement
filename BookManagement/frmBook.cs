﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;
using DAL;

namespace BookManagement
{
    public partial class frmBook : Form
    {
        //Instantiation of a book Operation method class 
        private BookServices objBookServices = new BookServices();
        //Instantiate a DataTable to store all the book information
        private DataTable dt = new DataTable();
        //Define an action performed by a Flag identity
        private int actionFlag = 0;  //1---View 2---add 3---Modify

        public frmBook()
        {
            InitializeComponent();

            //Setting DataGridView 
            dgvBook.AutoGenerateColumns = false;
            //Loading book information
            LoadBookInfo();
        }

        //=======================================Control events=======================================================

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadBookInfo();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //Set the text box value to null
            txtQueryISBN.Text = string.Empty;
            txtQueryBookId.Text = string.Empty;
            txtQueryBookName.Text = string.Empty;
            txtQueryAuthor.Text = string.Empty;
            //Loading data
            LoadBookInfo();

        }
    }
}
