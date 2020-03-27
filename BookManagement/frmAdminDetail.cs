using System;
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
    public partial class frmAdminDetail : Form
    {
        //Define the local action flag
        private int actionFlag = 0; //1---View 2---add 3--modifications
        //Instantiation of the Operation method
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();

        public frmAdminDetail()
        {
            InitializeComponent();
        }

        public frmAdminDetail(int flag, SysAdmins objSysAdmins) : this()
        {
            //Initialize the local Flag 
            actionFlag = flag;
            //Initialize the form by loading different methods according to the different Flag,j provided
            switch (flag)
            {
                case 1: //View 
                    LoadViewForm(objSysAdmins);
                    break;
                case 2:
                    LoadAddForm();
                    break;
                case 3:
                    LoadUpdateForm(objSysAdmins);
                    break;
                default:
                    break;
            }

        }

        //====================================Control events==================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAdminDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdminMgmt.objFrmAdminDetail = null;
        }
        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (actionFlag == 2) lblLoginId.Text = objSysAdminsServices.BuildLoginId();
        }

        private void rbSuperUser_CheckedChanged(object sender, EventArgs e)
        {
            if (actionFlag == 2) lblLoginId.Text = objSysAdminsServices.BuildLoginId();
        }
    }
}
