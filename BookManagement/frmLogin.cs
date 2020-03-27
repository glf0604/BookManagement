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

            }
    }
}
