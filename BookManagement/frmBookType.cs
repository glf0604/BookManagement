using System;
using System.Collections;
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
    public partial class frmBookType : Form
    {
        //Instantiate a DataTable object to store all category information
        private DataTable dt = new DataTable();
        //Instantiate an object for an Booktype operation
        private BookTypeServices objBookTypeServices = new BookTypeServices();
        //Defines a global operation Flag 
        private int actionFlag = 0;  //1--add   2--modify

        public frmBookType()
        {
            InitializeComponent();

            //Disable Detail box 
            gboxNodeDetial.Enabled = false;
            //Used to initialize the DT
            try
            {
                dt = objBookTypeServices.GetBookType();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting information about book categories! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Judging by the results.
            if (dt.Rows.Count == 0)
            {
                //Disable button
                btnAddRootNode.Enabled = true;
                btnAddSubNode.Enabled = false;
                btnUpdateNode.Enabled = false;
                btnDeleteNode.Enabled = false;
            }
            else
            {
                //Disable button
                btnAddRootNode.Enabled = false;
                btnAddSubNode.Enabled = true;
                btnUpdateNode.Enabled = true;
                btnDeleteNode.Enabled = true;

                //Initialization of TreeView 
                LoadBookType();
            }
        }

        //==================================The event of the control======================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Select an event triggered by a node in TreeView
        private void tvBookType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Gets the information for the selection node
            TreeNode objTreeNode = tvBookType.SelectedNode;

            //Assign a value 
            txtTypeId.Text = objTreeNode.Tag.ToString();
            txtTypeName.Text = objTreeNode.Text;

            //Classification for judgment
            if (txtTypeId.Text == "1")  //Node
            {
                txtParentTypeId.Text = "NULL";
                txtParentTypeName.Text = "NULL";
                rtbDESC.Text = objBookTypeServices.GetTypeDESC(Convert.ToInt32(txtTypeId.Text));
            }
            else
            {
                //Get parent Information
                BookType objBookType = objBookTypeServices.GetParentType(Convert.ToInt32(txtTypeId.Text));
                //Assign a value
                rtbDESC.Text = objBookType.DESC;
                txtParentTypeId.Text = objBookType.TypeId.ToString();
                txtParentTypeName.Text = objBookType.TypeName;
            }
        }
        //Add root node
        private void btnAddRootNode_Click(object sender, EventArgs e)
        {

            //Enable Detail Forms
            gboxNodeDetial.Enabled = true;
            //Disable three PCs 
            txtParentTypeId.Enabled = false;
            txtParentTypeName.Enabled = false;
            txtTypeId.Enabled = false;
            //Populate data
            txtParentTypeId.Text = "0";
            txtParentTypeName.Text = "NULL";
            txtParentTypeId.Text = "1";
            //Set the name and detail input box to empty
            txtTypeName.Text = string.Empty;
            rtbDESC.Text = string.Empty;

            //Change ActionFlag to 1
            actionFlag = 1;
        }
        //Adding child nodes
        private void btnAddSubNode_Click(object sender, EventArgs e)
        {
            //Only two levels can be added
            if (tvBookType.SelectedNode.Tag.ToString().Length == 5)
            {
                MessageBox.Show("Adding categories can only add two levels!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //Enable Detail Forms
            gboxNodeDetial.Enabled = true;
            //Disable three PCs 
            txtParentTypeId.Enabled = false;
            txtParentTypeName.Enabled = false;
            txtTypeId.Enabled = false;
            //Populate data

            txtParentTypeId.Text = tvBookType.SelectedNode.Tag.ToString();
            txtParentTypeName.Text = tvBookType.SelectedNode.Text;
            txtTypeId.Text = objBookTypeServices.BuildNewTypeId(Convert.ToInt32(txtParentTypeId.Text));
            //Set the name and detail input box to empty
            txtTypeName.Text = string.Empty;
            rtbDESC.Text = string.Empty;

            //Change ActionFlag to 1
            actionFlag = 1;
        }
        //Modify selected nodes
        private void btnUpdateNode_Click(object sender, EventArgs e)
        {
            //Enable Detail Forms
            gboxNodeDetial.Enabled = true;
            //Disable three PCs 
            txtParentTypeId.Enabled = false;
            txtParentTypeName.Enabled = false;
            txtTypeId.Enabled = false;

            //Let TypeName get the focus 
            txtTypeName.Focus();

            //Change ActionFlag to 1
            actionFlag = 2;
        }
    }
}
