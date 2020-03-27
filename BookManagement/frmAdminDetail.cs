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
    public partial class frmAdminDetail : Form
    {
        //Define the local action flag
        private int actionFlag = 0; //1---View 2---add 3--modifications
        //Instantiation of the Operation method
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();

        public frmAdminDetail()
        {
            InitializeComponent();
        }

        public frmAdminDetail(int flag, SysAdmins objSysAdmins) : this()
        {
            //Initialize the local Flag 
            actionFlag = flag;
            //Initialize the form by loading different methods according to the different Flag,j provided
            switch (flag)
            {
                case 1: //View 
                    LoadViewForm(objSysAdmins);
                    break;
                case 2:
                    LoadAddForm();
                    break;
                case 3:
                    LoadUpdateForm(objSysAdmins);
                    break;
                default:
                    break;
            }

        }

        //====================================Control events==================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAdminDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdminMgmt.objFrmAdminDetail = null;
        }
        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            if (actionFlag == 2) lblLoginId.Text = objSysAdminsServices.BuildLoginId();
        }

        private void rbSuperUser_CheckedChanged(object sender, EventArgs e)
        {
            if (actionFlag == 2) lblLoginId.Text = objSysAdminsServices.BuildLoginId();
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //Verify

            if (!CheckAdminInput()) return;

            //encapsulation
            SysAdmins objSysAdmin = new SysAdmins()
            {
                LoginId = Convert.ToInt32(lblLoginId.Text),
                UserName = txtUserName.Text.Trim(),
                IsDisable = rbDisable.Checked == true ? true : false,
                IsSuperUser = rbSuperUser.Checked == true ? true : false,
                LoginPwd = txtPasswordOneTime.Text,
                LastLoginTime = DateTime.Now,
            };
            //Submit
            switch (actionFlag)
            {
                case 2: //Add
                    try
                    {
                        if (objSysAdminsServices.AddSysAdmin(objSysAdmin) == 1)
                        {
                            //Add successful
                            MessageBox.Show("Administrator Added Successfully!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close
                            Close();
                            //Return Value
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Administrator additions have been abnormal! __________ Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3: //Modify
                    try
                    {
                        if (objSysAdminsServices.UpdateSysAdmin(objSysAdmin) == 1)
                        {
                            //Add Successful
                            MessageBox.Show("Modification Administrator Successful！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close
                            Close();
                            //Return Value
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Administrator additions have been abnormal! __________ Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }
        //====================================User-defined methods==================================

        //View
        private void LoadViewForm(SysAdmins objSysAdmins)
        {
            //Modify Title name Display
            lblTitle.Text = "View Administrator";
            //Assign a value
            if (objSysAdmins.IsSuperUser) rbSuperUser.Checked = true;
            else rbUser.Checked = true;
            lblLoginId.Text = objSysAdmins.LoginId.ToString();
            txtUserName.Text = objSysAdmins.UserName;
            if (objSysAdmins.IsDisable) rbDisable.Checked = true;
            else rbEnable.Checked = true;
            //Disable controls
            rbUser.Enabled = false;
            rbSuperUser.Enabled = false;
            rbEnable.Enabled = false;
            rbDisable.Enabled = false;
            txtUserName.Enabled = false;
            txtPasswordOneTime.Enabled = false;
            txtPasswordTwoTime.Enabled = false;
            //Submit Control Hide
            btnCommit.Visible = false;

        }

        //Add
        private void LoadAddForm()
        {
            //Modify Title name Display
            lblTitle.Text = "Add Administrator";

            //Clear
            txtUserName.Text = string.Empty;
            txtPasswordOneTime.Text = string.Empty;
            txtPasswordTwoTime.Text = string.Empty;


            //Admin Radio Box gets focus
            rbUser.Checked = true;

        }


    }
}
