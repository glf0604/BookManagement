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
    public partial class frmBookPressDetail : Form
    {
        //The Operation method Class of instantiated publishing house 
        private BookPressServices objBookPressServices = new BookPressServices();

        //Defines a actionFlag that is used to distinguish whether to add or modify at the time of submission
        private int actionFlag = 0;  //2--Add    3---Modify

        public frmBookPressDetail()
        {
            InitializeComponent();
        }

        //Construction method of carrying parameters
        public frmBookPressDetail(int flag, BookPress objBookPress) : this()
        {

            //flag:  1---view   2---add   3---modify 
            //Initialization of local ActionFlag
            actionFlag = flag;

            //Perform different actions according to Flag
            switch (flag)
            {
                case 1:
                    LoadViewForm(objBookPress);
                    break;
                case 2:
                    LoadAddForm();
                    break;
                case 3:
                    LoadUpdateForm(objBookPress);
                    break;
            }

        }

        //-=================================Control methods================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBookPressDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBookPress.objFrmBookPressDetail = null;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

            //Determine if the input complies with the specification 
            if (!CheckPressInput()) return;

            //Encapsulation objects
            BookPress objBookPress = new BookPress()
            {
                PressId = Convert.ToInt32(lblPressId.Text),
                PressName = txtPressName.Text.Trim(),
                PressTel = txtPressTel.Text.Trim(),
                PressContact = txtPressContact.Text.Trim(),
                PressAddress = txtPressAddress.Text.Trim(),
            };

            //Submit
            switch (actionFlag)
            {
                case 2://Added execution
                    try
                    {
                        if (objBookPressServices.AddBookPress(objBookPress) == 1)
                        {
                            //Notice Successful！
                            MessageBox.Show("Success in Adding press Information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close current from
                            Close();
                            //Return OK 
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding publisher information! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3: //The execution of the modification
                    try
                    {
                        if (objBookPressServices.UpdateBookPress(objBookPress) == 1)
                        {
                            //Notice Successful！
                            MessageBox.Show("Success in Adding press Information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close current form
                            Close();
                            //Return OK 
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding publisher information! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        //-=================================Custom Methods================================

        //Form initialization when used for viewing
        private void LoadViewForm(BookPress objBookPress)
        {
            //【1】 Change the Title name to "view publisher"
            lblTitle.Text = "【View Press】";

            //【2】 Disable controls 
            txtPressName.Enabled = false;
            txtPressTel.Enabled = false;
            txtPressContact.Enabled = false;
            txtPressAddress.Enabled = false;

            //【3】 Initialize content
            lblPressId.Text = objBookPress.PressId.ToString();
            txtPressName.Text = objBookPress.PressName;
            txtPressTel.Text = objBookPress.PressTel;
            txtPressContact.Text = objBookPress.PressContact;
            txtPressAddress.Text = objBookPress.PressAddress;

            //【4】Hide Submit button 
            btnCommit.Visible = false;

        }

        //Form initialization when used for addition
        private void LoadAddForm()
        {
            //【1】 Change the Title name to "add publisher"
            lblTitle.Text = "【Add Press】";

            //【2】 Modify the Close button name
            btnClose.Text = "Cancel and Close";

            //【3】 Automatically generate a publishing house number
            try
            {
                lblPressId.Text = objBookPressServices.BuildNewPressId();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating publishing house number! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Form initialization when used for modification
        private void LoadUpdateForm(BookPress objBookPress)
        {
            //【1】 Title changed to "Modify Publishing house"
            lblTitle.Text = "【Modify Press】";

            //【2】 Initialize content
            lblPressId.Text = objBookPress.PressId.ToString();
            txtPressName.Text = objBookPress.PressName;
            txtPressTel.Text = objBookPress.PressTel;
            txtPressContact.Text = objBookPress.PressContact;
            txtPressAddress.Text = objBookPress.PressAddress;

            //【3】 Modify the Close button name
            btnClose.Text = "Cancel and Close";
        }

        //Verify the input of publishing house information
        private bool CheckPressInput()
        {
            //Whether the publishing house information is empty！
            if (string.IsNullOrWhiteSpace(txtPressName.Text))
            {
                MessageBox.Show("Publishing House Name Can't Be Empty!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPressName.Focus();
                return false;
            }
            //Whether the publishing house information exists (only in Add mode)！
            if (objBookPressServices.IsExistPressName(txtPressName.Text.Trim()) && actionFlag == 2)
            {
                MessageBox.Show("The name of the publishing house already exists!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPressName.Focus();
                return false;
            }

            return true;
        }
    }
}
