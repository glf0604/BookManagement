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
            //Verify the data


            //Encapsulating users
            SysAdmins currentAdmins = new SysAdmins()
            {
                LoginId = Convert.ToInt32(txtLoginId.Text.Trim()),
                LoginPwd = txtLoginPwd.Text,
            };

            //Complete authentication
            try
            {
                currentAdmins = objSysAdminsServices.Login(currentAdmins);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when user completes identity! Specific error:" + ex.Message, "System message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //More returned results to determine login
            if (currentAdmins == null)
            {
                //Count plus 1
                errorTimes++;
                //Determine if it reaches three times 
                if (errorTimes == 3)
                {
                    try
                    {
                        if (objSysAdminsServices.DisableLoginId(Convert.ToInt32(txtLoginId.Text.Trim())) == 1)
                        {
                            lblLoginInfo.Text = "The password has been mistyped three times and the account has been disabled!";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
                }
                else
                {
                    lblLoginInfo.Text = "Error in password input!";
                    return;
                }

            }
            else if (currentAdmins.IsDisable)
            {
                lblLoginInfo.Text = "Account has been disabled! Please contact the administrator";
                return;
            }
            else
            {
                //Pay the value to the global variable 
                Program.currentUser = currentAdmins;

                //Change the current login time 
                try
                {
                    if (objSysAdminsServices.UpdateLastLoginTime(Convert.ToInt32(txtLoginId.Text.Trim())) == 1)
                    {

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
                //Login Log
                //1.Write a record 
                //2.Assign a value to program.currentLogid


                //Preparing log Classes 
                LoginLogs objLoginLogs = new LoginLogs()
                {
                    LogInId = currentAdmins.LoginId,
                    UserName = currentAdmins.UserName,
                    LoginComputer = Dns.GetHostName(),
                    LoginTime = objSysAdminsServices.GetServerTime(),
                };
                //Write to log
                try
                {
                    Program.currentLogId = objSysAdminsServices.WirteLoginLog(objLoginLogs);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error writing log! Specific errors:" + ex.Message, "Landing message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Return DialogOk 
                this.DialogResult = DialogResult.OK;
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtLoginId_TextChanged(object sender, EventArgs e)
        {
            lblLoginInfo.Text = string.Empty;
        }
        private void txtLoginPwd_TextChanged(object sender, EventArgs e)
        {
            lblLoginInfo.Text = string.Empty;
        }
        private void txtLoginId_Leave(object sender, EventArgs e)
        {
            try
            {
                bool b = objSysAdminsServices.IsExistLoginId(Convert.ToInt32(txtLoginId.Text.Trim()));
                if (!b)
                {
                    lblLoginInfo.Text = "Logon name does not exist";
                    txtLoginId.BackColor = Color.OrangeRed;
                }
                else
                {
                    txtLoginId.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in judging login account! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtLoginPwd_Leave(object sender, EventArgs e)
        {
            if (txtLoginPwd.Text.Length < 6)
            {

                lblLoginInfo.Text = "Password must not be less than 6 bits";
                txtLoginPwd.BackColor = Color.OrangeRed;

            }
            else
            {
                txtLoginPwd.BackColor = Color.LightGreen;
            }

        }
        //=============================User-defined methods===============================

        /// <summary>
        /// Determine the user's input
        /// </summary>
        /// <returns></returns>
        private bool CheckUserInput()
        {
            //Whether the login account is empty, 4 digits 
            if (string.IsNullOrWhiteSpace(txtLoginId.Text))
            {
                lblLoginInfo.Text = "The login account cannot be empty！";
                txtLoginId.Focus();
                return false;
            }

            //Number Four
            if (!ValidateInput.IsInteger(txtLoginId.Text.Trim()) || txtLoginId.Text.Trim().Length != 4)
            {
                lblLoginInfo.Text = "Login account must be 4 digits！";
                txtLoginId.Focus();
                return false;
            }


            //Not allowed to be empty, must be 6-bit
            if (txtLoginPwd.Text.Length < 6)
            {
                lblLoginInfo.Text = "Password must be greater than or equal to 6 bits！";
                txtLoginPwd.Focus();
                return false;
            }

            return true;
        }
    }
}
