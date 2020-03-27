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

        private void LoadSysAdmins()
        {
            //Assign a value to the Dt
            try
            {

                dt = objSysAdminsServices.GetSysAdmins(txtQueryLoginId.Text.Trim(), txtQueryUserName.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Access administrator failed! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //Load into a table 
            dgvSysAdmins.DataSource = null;
            dgvSysAdmins.Rows.Clear();

            //Traversing a table 
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int index = dgvSysAdmins.Rows.Add();
                    dgvSysAdmins.Rows[index].Cells[0].Value = dt.Rows[i]["LoginId"].ToString();
                    dgvSysAdmins.Rows[index].Cells[1].Value = dt.Rows[i]["UserName"].ToString();
                    if (Convert.ToBoolean(dt.Rows[i]["IsDisable"])) dgvSysAdmins.Rows[i].Cells[2].Value = "Prohibit";
                    else dgvSysAdmins.Rows[index].Cells["IsDisable"].Value = "Enable";
                    if (Convert.ToBoolean(dt.Rows[i]["IsSuperUser"])) dgvSysAdmins.Rows[i].Cells[3].Value = "Super Administrator";
                    else dgvSysAdmins.Rows[index].Cells[3].Value = "Administrator";
                    dgvSysAdmins.Rows[index].Cells[4].Value = dt.Rows[i]["LastLoginTime"].ToString();
                }
            }

        }
    }
}
