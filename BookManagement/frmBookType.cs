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

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //Verify

            //encapsulation
            BookType objBookType = new BookType()
            {
                TypeId = Convert.ToInt32(txtTypeId.Text.Trim()),
                TypeName = txtTypeName.Text,
                ParentTypeId = Convert.ToInt32(txtParentTypeId.Text.Trim()),
                DESC = rtbDESC.Text.Trim(),
            };

            switch (actionFlag)
            {
                case 1:
                    try
                    {
                        if (objBookTypeServices.AddBookType(objBookType) == 1)
                        {

                            //Refresh Treeview 
                            LoadBookType();
                            //display
                            tvBookType.ExpandAll();
                            //Disable a form
                            gboxNodeDetial.Enabled = false;
                            //Tip Add Success!
                            MessageBox.Show("Successful addition of categories!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error writing to database when book category is added! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2:
                    try
                    {
                        if (objBookTypeServices.UpdateBookType(objBookType) == 1)
                        {

                            //Refersh Treeview 
                            LoadBookType();
                            //Display
                            tvBookType.ExpandAll();
                            //Disable From
                            gboxNodeDetial.Enabled = false;
                            //Successful!
                            MessageBox.Show("Successful Category Modification!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There was an error writing to the database when the book category was revised! __________ Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void txtTypeName_Leave(object sender, EventArgs e)
        {
            if (objBookTypeServices.IsExistTypeName(txtTypeName.Text.Trim()) && actionFlag == 1)
            {
                MessageBox.Show("Category name already exists", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            gboxNodeDetial.Enabled = false;
        }


        //=================================Custom Methods=====================================
        private void LoadBookType()
        {
            //Clear TreeView 
            tvBookType.Nodes.Clear();

            //Get the latest data 
            dt = objBookTypeServices.GetBookType();

            //Define a SortedList storage node information
            SortedList objSL = new SortedList();

            //Traverse the table to load all node information into a tree
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["TypeId"].ToString() == "1")
                {
                    TreeNode tn = new TreeNode();
                    tn.Text = dt.Rows[i]["TypeName"].ToString();
                    tn.Tag = dt.Rows[i]["TypeId"].ToString();
                    //The root node is in an expanded state
                    tn.Expand();
                    //Load into SortedList
                    objSL.Add(tn.Tag, tn);
                    //Load into TreeView
                    tvBookType.Nodes.Add(tn);

                }
                else
                {
                    //Load into TreeView ...:
                    TreeNode parentNode = (TreeNode)objSL.GetByIndex(objSL.IndexOfKey(dt.Rows[i][2].ToString()));
                    //Instantiation of child nodes
                    TreeNode tnChild = new TreeNode();
                    tnChild.Text = dt.Rows[i]["TypeName"].ToString();
                    tnChild.Tag = dt.Rows[i]["TypeId"].ToString();
                    //Pick up 
                    tnChild.Collapse();
                    //Load into Sortedlist
                    objSL.Add(tnChild.Tag, tnChild);
                    //Hang on parent node
                    parentNode.Nodes.Add(tnChild);

                }
            }
        }

        private void btnDeleteNode_Click(object sender, EventArgs e)
        {

            string nodeId = tvBookType.SelectedNode.Tag.ToString();
            string nodeName = tvBookType.SelectedNode.Text;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No category information category succeeded!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (objBookTypeServices.IsExistSub(Convert.ToInt32(nodeId)))
            {
                MessageBox.Show("All subclasses must be deleted before the current class can be deleted!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string info = "You are sure to delete the category information [category number:" + nodeId + " Name：" + nodeName + "]？";
                DialogResult result = MessageBox.Show(info, "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (objBookTypeServices.DeleteBookType(Convert.ToInt32(nodeId)) == 1)
                        {
                            //Refersh Treeview 
                            LoadBookType();
                            //Display
                            tvBookType.ExpandAll();
                            //Delete successful!
                            MessageBox.Show("Successful deletion of categories!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }

            }

        }
    }
}
