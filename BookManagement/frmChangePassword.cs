using System;
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
    public partial class frmChangePassword : Form
    {
        //Instantiation Management class Operation method
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();

        public frmChangePassword()
        {
            InitializeComponent();
            //Display the current login account and name
            lblLoginId.Text = Program.currentUser.LoginId.ToString();
            lblUserName.Text = Program.currentUser.UserName;
        }
        public frmChangePassword(SysAdmins objSysAdmin) : this()
        {
            lblLoginId.Text = objSysAdmin.LoginId.ToString();
            lblUserName.Text = objSysAdmin.UserName;
        }
    }
}
