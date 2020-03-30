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
    public partial class frmLoginQuery : Form
    {
        //Instantiation of an action method
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Define a DataTAble 
        private DataTable dt = null;

        public frmLoginQuery()
        {
            InitializeComponent();
            //Initialization of DataGridView
            dgvLoginLogs.AutoGenerateColumns = false;
            //Load login Log
            LoadLoginLogs();
        }
    }
}
