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
    public partial class frmBorrowReturnQuery : Form
    {
        //Define a DataTable 
        private DataTable dt = null;
        //Instantiate an action class
        private BorrowBookDetailServices objBorrowBookDetailServices = new BorrowBookDetailServices();

        public frmBorrowReturnQuery()
        {
            InitializeComponent();
            //Initialization of DataGridView
            dgvBook.AutoGenerateColumns = false;
            //Loading data
            LoadBookInfo();
        }
        //=========================================Control events=============================================

        private void btnQuery_Click(object sender, EventArgs e)
        {
            //
            rbQueryNoBorrowed.Checked = false;
            rbQueryWelcomeTop100.Checked = false;
            rbQueryLostTop100.Checked = false;
            rbQueryOverdueTop100.Checked = false;

            //Preparation Date
            DateTime[] dtArray = GetStartOrEndDate();

            LoadBookInfo(dtArray);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            rbQueryNoBorrowed.Checked = false;
            rbQueryWelcomeTop100.Checked = false;
            rbQueryLostTop100.Checked = false;
            rbQueryOverdueTop100.Checked = false;

            //Clear
            txtQueryCardId.Text = string.Empty;
            txtQueryMemberId.Text = string.Empty;
            txtQueryMemberName.Text = string.Empty;

            //Choice Date
            rbQueryAll.Checked = true;

            //Executing queries
            LoadBookInfo();
        }
        //A book I've never borrowed before.
        private void rbQueryNoBorrowed_CheckedChanged(object sender, EventArgs e)
        {
            //Clear
            dt.Clear();
            //Re-assign a value
            //Get query Results
            try
            {
                dt = objBorrowBookDetailServices.GetBookNotBorrowed();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading the information of borrowed books and reporting errors! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Bind to DataGridview 
            dgvBook.DataSource = null;
            dgvBook.DataSource = dt;
        }

        //Most popular book Top 100
        private void rbQueryWelcomeTop100_CheckedChanged(object sender, EventArgs e)
        {
            //Clear Dt
            dt.Clear();
            //Get query Results
            try
            {
                dt = objBorrowBookDetailServices.GetBookWelComeTop100();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading the information of borrowed books and reporting errors! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Bind to DataGridview 
            dgvBook.DataSource = null;
            dgvBook.DataSource = dt;
        }
        //Lost number Top 100
        private void rbQueryLostTop100_CheckedChanged(object sender, EventArgs e)
        {
            //Clear Dt
            dt.Clear();
            //Get query Results
            try
            {
                dt = objBorrowBookDetailServices.GetBookLostTop100();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading the information of borrowed books and reporting errors! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Bind to DataGridview 
            dgvBook.DataSource = null;
            dgvBook.DataSource = dt;
        }
        //Overdue Top100
        private void rbQueryOverdueTop100_CheckedChanged(object sender, EventArgs e)
        {
            //clear Dt
            dt.Clear();
            //get check result
            try
            {
                dt = objBorrowBookDetailServices.GetBookOverdueTop100();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Loading the information of borrowed books and reporting errors! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //bind  to DataGridview 
            dgvBook.DataSource = null;
            dgvBook.DataSource = dt;
        }
    }
}
