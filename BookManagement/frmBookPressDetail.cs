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
                            MessageBox.Show("Success in Adding Publishing House Information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            MessageBox.Show("Success in Adding Publishing House Information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
