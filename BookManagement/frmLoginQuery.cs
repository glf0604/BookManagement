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
        private void LoadLoginLogs()
        {
            //Preparation time
            DateTime[] dtArray = GetStartOrEndDate();
            //Loading data
            try
            {
                dt = objSysAdminsServices.GetLoginLogs(txtLoginId.Text.Trim(), txtUserName.Text.Trim(), dtArray[0], dtArray[1]);
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an exception loading logs! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Bindding date
            dgvLoginLogs.DataSource = null;
            dgvLoginLogs.DataSource = dt;
        }
    }
}
