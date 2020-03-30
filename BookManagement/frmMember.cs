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
    public partial class frmMember : Form
    {
        //Instantiate Member Operation class 
        private MemberServices objMemberServices = new MemberServices();
        //Instantiate a DataTable to store all member information
        private DataTable dt = new DataTable();
        //Define local action identifiers
        private int actionFlag = 0; //1---View  2---Add   3---Modify
        //Instantiate a form
        public static frmMemberDetail objFrmMemberDetail = null;

        public frmMember()
        {
            InitializeComponent();
            //Initialization of DataGridView
            dgvMember.AutoGenerateColumns = false;
            //Load member Information
            LoadMemberInfo();
        }
    }
}
