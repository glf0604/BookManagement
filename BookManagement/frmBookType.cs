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
    }
}
