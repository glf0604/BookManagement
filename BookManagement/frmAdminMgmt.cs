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

        //Double-click to view data
        private void dgvSysAdmins_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //【1】Determine if there is data
            if (dgvSysAdmins.Rows.Count < 0)
            {
                MessageBox.Show("There is no data in the table！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            //【2】Packaging
            SysAdmins objSysAdmin = new SysAdmins()
            {
                LoginId = Convert.ToInt32(dgvSysAdmins.CurrentRow.Cells[0].Value),
                UserName = dgvSysAdmins.CurrentRow.Cells[1].Value.ToString(),
            };
            if (dgvSysAdmins.CurrentRow.Cells[2].Value.ToString().Contains("Enable")) objSysAdmin.IsDisable = false;
            else objSysAdmin.IsDisable = true;
            if (dgvSysAdmins.CurrentRow.Cells[3].Value.ToString().Contains("Super")) objSysAdmin.IsSuperUser = true;
            else objSysAdmin.IsSuperUser = false;

            //【3】Initialization of Actionflag
            actionFlag = 1;
            //【4】Loading a form
            if (objFrmAdminDetail == null)
            {
                objFrmAdminDetail = new frmAdminDetail(actionFlag, objSysAdmin);
                objFrmAdminDetail.Show();
            }
            else
            {
                objFrmAdminDetail.Activate();
                objFrmAdminDetail.WindowState = FormWindowState.Normal;
            }

        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Assign Value actionFlag 
            actionFlag = 2;
            //Loading a form
            if (objFrmAdminDetail == null)
            {
                objFrmAdminDetail = new frmAdminDetail(actionFlag, null);
                DialogResult result = objFrmAdminDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadSysAdmins();
                }
            }
            else
            {
                objFrmAdminDetail.Activate();
                objFrmAdminDetail.WindowState = FormWindowState.Normal;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //【1】Determine if there is data
            if (dgvSysAdmins.Rows.Count < 0)
            {
                MessageBox.Show("There is no data in the table！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            //【2】encapsulation
            SysAdmins objSysAdmin = new SysAdmins()
            {
                LoginId = Convert.ToInt32(dgvSysAdmins.CurrentRow.Cells[0].Value),
                UserName = dgvSysAdmins.CurrentRow.Cells[1].Value.ToString(),
            };
            if (dgvSysAdmins.CurrentRow.Cells[2].Value.ToString().Contains("Enable")) objSysAdmin.IsDisable = false;
            else objSysAdmin.IsDisable = true;
            if (dgvSysAdmins.CurrentRow.Cells[3].Value.ToString().Contains("Super")) objSysAdmin.IsSuperUser = true;
            else objSysAdmin.IsSuperUser = false;

            //【3】Initialization of Actionflag
            actionFlag = 3;
            //【4】Loading a form
            if (objFrmAdminDetail == null)
            {
                objFrmAdminDetail = new frmAdminDetail(actionFlag, objSysAdmin);
                DialogResult result = objFrmAdminDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadSysAdmins();
                }
            }
            else
            {
                objFrmAdminDetail.Activate();
                objFrmAdminDetail.WindowState = FormWindowState.Normal;
            }

        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            //【1】Determine if there is data
            if (dgvSysAdmins.Rows.Count < 0)
            {
                MessageBox.Show("There is no data in the table！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[0].Value == null)
            {
                return;
            }
            //【2】encapsulation
            SysAdmins objSysAdmin = new SysAdmins()
            {
                LoginId = Convert.ToInt32(dgvSysAdmins.CurrentRow.Cells[0].Value),
                UserName = dgvSysAdmins.CurrentRow.Cells[1].Value.ToString(),
            };
            if (dgvSysAdmins.CurrentRow.Cells[2].Value.ToString().Contains("Enable")) objSysAdmin.IsDisable = false;
            else objSysAdmin.IsDisable = true;
            if (dgvSysAdmins.CurrentRow.Cells[3].Value.ToString().Contains("Super")) objSysAdmin.IsSuperUser = true;
            else objSysAdmin.IsSuperUser = false;


            //[3]Loading a form
            if (objFrmChangePassword == null)
            {
                objFrmChangePassword = new frmChangePassword(objSysAdmin);
                objFrmChangePassword.Show();
            }
            else
            {
                objFrmChangePassword.Activate();
                objFrmChangePassword.WindowState = FormWindowState.Normal;
            }
        }

        private void btnEnable_Click(object sender, EventArgs e)
        {
            //Determine if there is data
            if (dgvSysAdmins.Rows.Count < 0)
            {
                MessageBox.Show("There is no data in the table！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[2].Value == null)
            {
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[2].Value.ToString().Contains("Enable"))
            {
                MessageBox.Show("The account has been activated！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (objSysAdminsServices.EnableAdmin(Convert.ToInt32(dgvSysAdmins.CurrentRow.Cells[0].Value)) == 1)
                {
                    //Prompt for Success
                    MessageBox.Show("Successful account activation!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh
                    LoadSysAdmins();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an exception to enabling accounts! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDisable_Click(object sender, EventArgs e)
        {
            //Determine if there is data
            if (dgvSysAdmins.Rows.Count < 0)
            {
                MessageBox.Show("There is no data in the table!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[2].Value == null)
            {
                return;
            }
            if (dgvSysAdmins.CurrentRow.Cells[2].Value.ToString().Contains("Prohibit"))
            {
                MessageBox.Show("This account has been disabled!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                if (objSysAdminsServices.DisableLoginId(Convert.ToInt32(dgvSysAdmins.CurrentRow.Cells[0].Value)) == 1)
                {
                    //Prompt for Success
                    MessageBox.Show("Disable account successfully!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh
                    LoadSysAdmins();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disabled account abnormal! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadSysAdmins();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtQueryLoginId.Text = string.Empty;
            txtQueryUserName.Text = string.Empty;
            LoadSysAdmins();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
