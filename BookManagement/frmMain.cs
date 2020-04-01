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
    public partial class frmMain : Form
    {
        //Instantiated Login Operation method 
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Instantiate a book category form 
        public static frmBookType objFrmBookType = null;
        //Instantiated book publishing house form
        public static frmBookPress objFrmBookPress = null;
        //A form that instantiates a book
        public static frmBook objFrmBook = null;
        //Forms that instantiate membership levels
        public static frmMemberLevel objFrmMemberLevel = null;
        //Instantiate a form managed by a member
        public static frmMember objFrmMember = null;
        //Instantiate a form for borrowing a book
        public static frmBorrowBook objFrmBorrowBook = null;
        //Instantiate a form for returning a book
        public static frmReturnBook objFrmReturnBook = null;
        //Instantiate a form that borrows a return query
        public static frmBorrowReturnQuery objFrmBorrowReturnQuery = null;
        //Instantiate modify Password Form
        public static frmChangePassword objFrmChangePassword = null;
        //Instantiate logon log Query
        public static frmLoginQuery objFrmLoginQuery = null;
        //Instantiate administrator Manage account forms
        public static frmAdminMgmt objFrmAdminMgmt = null;

        public frmMain()
        {
            InitializeComponent();
            //Initializes the current user and the user's last logon time 
            lblLoginUseName.Text += Program.currentUser.UserName;
            lblLastLoginTime.Text += Program.currentUser.LastLoginTime;

            //Determine if the user is operating
            if (!Program.currentUser.IsSuperUser)
            {
                btnLoginAdmin.Visible = false;
                btnLoginQuery.Visible = false;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
        private void btnFormMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Write Exit Time

            try
            {
                if (objSysAdminsServices.WriteExitTime(Program.currentLogId) == 1)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Write exit time failed! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
