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
using Common;

namespace BookManagement
{
    public partial class frmBookPress : Form
    {
        //Instantiation Publishing House Operation class
        private BookPressServices objBookPressServices = new BookPressServices();

        //Instantiate the value returned by a DataTable--receive database
        private DataTable dt = new DataTable();

        //Instantiate the form of the publishing house detail
        public static frmBookPressDetail objFrmBookPressDetail = null;

        //Define what action a variable identity performs 
        private int actionFlag = 0;  //1---View 2---add 3---Modify

        public frmBookPress()
        {
            InitializeComponent();
        }
    }
}
