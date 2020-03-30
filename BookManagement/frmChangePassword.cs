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

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //Does not meet the requirements, does not comply with the stop operation！
            if (!CheckPasswordInput()) return;

            //Execution
            try
            {
                if (objSysAdminsServices.ChangePassword(Convert.ToInt32(lblLoginId.Text), txtNewPasswordOneTime.Text) == 1)
                {
                    //notice successful！
                    MessageBox.Show("Password modify successful！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Password modification abnormal! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private bool CheckPasswordInput()
        {
            //Verify that the original password is correct
            if (!objSysAdminsServices.Login(Convert.ToInt32(lblLoginId.Text), txtOldPassword.Text))
            {
                MessageBox.Show("The original password was entered incorrectly! Please re-enter!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOldPassword.SelectAll();
                return false;
            }


            //Is the new password the same as the original password?
            if (txtNewPasswordOneTime.Text.Length < 6)
            {
                MessageBox.Show("The new password should not be less than 6 bits!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPasswordOneTime.SelectAll();
                return false;
            }
            //Is the new password the same as the original password?
            if (txtOldPassword.Text == txtNewPasswordOneTime.Text)
            {
                MessageBox.Show("The new password can't be the same as the old one!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPasswordOneTime.SelectAll();
                return false;
            }

            //Two times is the same new password?
            if (txtNewPasswordOneTime.Text != txtNewPasswordTwoTime.Text)
            {
                MessageBox.Show("Two new password entries must be consistent!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNewPasswordTwoTime.SelectAll();
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmChangePassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmAdminMgmt.objFrmChangePassword = null;
        }
    }
}
