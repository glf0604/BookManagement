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
        private DateTime[] GetStartOrEndDate()
        {
            //Define a time 
            DateTime[] dtArray = new DateTime[2];

            if (rbAll.Checked == true)
            {
                dtArray[0] = Convert.ToDateTime("1900-01-01 00:00:00");
                dtArray[1] = DateTime.Now;
            }
            if (rbToday.Checked == true)
            {
                dtArray[0] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                dtArray[1] = DateTime.Now;
            }
            if (rbWeek.Checked == true)  //First day of Monday
            {
                int num01 = Convert.ToInt16(DateTime.Now.DayOfWeek);
                dtArray[0] = Convert.ToDateTime(DateTime.Now.AddDays(0 - num01 + 1).ToString("yyyy-MM-dd 00:00:00"));
                dtArray[1] = DateTime.Now;
            }
            if (rbMonth.Checked)
            {
                dtArray[0] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01 00:00:00"));
                dtArray[1] = DateTime.Now;
            }
            if (rbYear.Checked)
            {
                dtArray[0] = Convert.ToDateTime(DateTime.Now.ToString("yyyy-01-01 00:00:00"));
                dtArray[1] = DateTime.Now;
            }
            if (rbStartEnd.Checked)
            {
                dtArray[0] = Convert.ToDateTime(dtpStart.Text);
                dtArray[1] = Convert.ToDateTime(dtpEnd.Text);
            }

            return dtArray;
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadLoginLogs();
        }
    }
}
