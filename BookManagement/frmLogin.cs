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
using Common;
using System.Net;

namespace BookManagement
{
    public partial class frmLogin : Form
    {
        //Instantiate a method of user action
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Define a count variable for password input errors
        private int errorTimes = 0;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
