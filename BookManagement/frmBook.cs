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
    public partial class frmBook : Form
    {
        //Instantiation of a book Operation method class 
        private BookServices objBookServices = new BookServices();
        //Instantiate a DataTable to store all the book information
        private DataTable dt = new DataTable();
        //Define an action performed by a Flag identity
        private int actionFlag = 0;  //1---View 2---add 3---Modify

        public frmBook()
        {
            InitializeComponent();

            //Setting DataGridView 
            dgvBook.AutoGenerateColumns = false;
            //Loading book information
            LoadBookInfo();
        }

        //=======================================Control events=======================================================

        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadBookInfo();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //Set the text box value to null
            txtQueryISBN.Text = string.Empty;
            txtQueryBookId.Text = string.Empty;
            txtQueryBookName.Text = string.Empty;
            txtQueryAuthor.Text = string.Empty;
            //Loading data
            LoadBookInfo();

        }

        //View book details: View only
        private void dgvBook_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //【1】Get current Click Book information 
            Book objBook = null;
            try
            {
                objBook = objBookServices.GetBookById(dgvBook.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abnormal access to book details! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //【2】 Assign a value to flag
            actionFlag = 1;

            //【3】Loading a form
            frmBookDetail objFrmBookDetail = new frmBookDetail(actionFlag, objBook);
            objFrmBookDetail.Show();
        }

        //Add a book：
        private void btnAdd_Click(object sender, EventArgs e)
        {

            //【2】 Assign a value to flag
            actionFlag = 2;
            //【3】Loading a form
            frmBookDetail objFrmBookDetail = new frmBookDetail(actionFlag, null);
            DialogResult result = objFrmBookDetail.ShowDialog();
            if (result == DialogResult.OK)
            {
                //Update list information
                LoadBookInfo();
            }

        }

        //Modify Book
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //【1】Get current Click Book information 
            Book objBook = null;
            try
            {
                objBook = objBookServices.GetBookById(dgvBook.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abnormal access to book details! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //【2】 Assign a value to flag
            actionFlag = 3;

            //【3】Loading a form
            frmBookDetail objFrmBookDetail = new frmBookDetail(actionFlag, objBook);
            DialogResult result = objFrmBookDetail.ShowDialog();
            if (result == DialogResult.OK)
            {
                LoadBookInfo();
            }
        }

        //Delete Book
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string bookId = dgvBook.CurrentRow.Cells[0].Value.ToString();
            string bookName = dgvBook.CurrentRow.Cells[2].Value.ToString();

            //Determine if there is data
            if (dgvBook.Rows.Count == 0) return;

            //Perform deletion
            string info = "You are sure to delete the book information [Book number:" + bookId + " Book Name:" + bookName + "]Information?";
            DialogResult result = MessageBox.Show(info, "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (objBookServices.DeleteBook(bookId) == 1)
                    {
                        //Display Successful！
                        MessageBox.Show("Successful deletion of book information！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh
                        LoadBookInfo();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Abnormal deletion of book information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else return;


        }

        //ISBN Code Quick Query
        private void txtQueryISBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadBookInfo();
            }
        }

        //=======================================Custom events=======================================================
        //How to load book information
        private void LoadBookInfo()
        {
            //Initialization of DataTable 
            try
            {
                dt = objBookServices.GetBook(txtQueryISBN.Text.Trim(), txtQueryBookId.Text.Trim(), txtQueryBookName.Text.Trim(), txtQueryAuthor.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abnormal access to book information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Load to DataGridView 
            dgvBook.DataSource = null;
            dgvBook.DataSource = dt;
        }
    }
}
