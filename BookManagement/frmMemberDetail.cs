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
using Common;
using MyVideo;

namespace BookManagement
{
    public partial class frmMemberDetail : Form
    {
        //Instantiate member Action Class 
        private MemberServices objMemberServices = new MemberServices();
        //Instantiate the action class for the membership level 
        private MemberLevelServices objMemberLevelServices = new MemberLevelServices();
        //Ways to instantiate user logon
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Define local action identifiers
        private int actionFlag = 0;
        //Define Camera manipulation classes
        private Video objVideo = null;

        public frmMemberDetail()
        {
            InitializeComponent();
        }
        public frmMemberDetail(int flag, Member objMember) : this()
        {
            //Initialize Local action identifier 
            actionFlag = flag;
            //More operators to choose different loading methods
            switch (flag)
            {
                case 1://View
                    LoadViewForm(objMember);
                    break;
                case 2://Add
                    LoadAddForm();
                    break;
                case 3://Modify
                    LoadUpdateForm(objMember);
                    break;
            }
        }
        //=====================================Control events =======================================

        //Close the Detail form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Empty the form when you close the form
        private void frmMemberDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMember.objFrmMemberDetail = null;
            frmBorrowBook.objFrmMemberDetail = null;
            frmReturnBook.objFrmMemberDetail = null;
        }
    }
}
