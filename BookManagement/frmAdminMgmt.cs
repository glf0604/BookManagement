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
    public partial class frmAdminMgmt : Form
    {
        //Instantiation Operation Method Class
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Define a DataTable 
        private DataTable dt = null;
        //Define the local ActionFlag
        private int actionFlag = 0;
        //Define a detail form
        public static frmAdminDetail objFrmAdminDetail = null;
        //Define a form that modifies a password
        public static frmChangePassword objFrmChangePassword = null;

        public frmAdminMgmt()
        {
            InitializeComponent();
            //Initialization of DataGridView 
            dgvSysAdmins.AutoGenerateColumns = false;
            //Load all Administrators
            LoadSysAdmins();
        }
    }
}
