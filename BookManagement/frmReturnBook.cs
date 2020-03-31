﻿using System;
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
using Common;

namespace BookManagement
{
    public partial class frmReturnBook : Form
    {
        //Instantiate Expense detail form 
        public static frmReturnMoneyDetail objFrmReturnMoneyDetail = null;
        //Define a form for a member detail
        public static frmMemberDetail objFrmMemberDetail = null;
        //Define the class for the current user 
        private Member objMember = null;
        //Define a BorrowId
        private string borrowId = string.Empty;
        //Instantiate member Action Class
        private MemberServices objMemberServices = new MemberServices();
        //Instantiate an action class at a member level
        private MemberLevelServices objMemberLevelServices = new MemberLevelServices();
        //Instantiation of a BorrowBookServices operation class
        private BorrowBookServices objBorrowBookServices = new BorrowBookServices();
        //Instantiation of a Detail operation class
        private BorrowBookDetailServices objBorrowBookDetailServices = new BorrowBookDetailServices();
        //Define a DataTable current member book library details
        private DataTable dt = null;
        //Instantiation of a book operation class
        private BookServices objBookServices = new BookServices();
        //Define a page for book detail viewing
        public static frmBookDetail objFrmBookDetail = null;

        public frmReturnBook()
        {
            InitializeComponent();
            //Initialization of DataGridview 
            dgvReturn.AutoGenerateColumns = false;
        }
        //Open detail form
        private void btnMoneyDetail_Click(object sender, EventArgs e)
        {
            if (dgvReturn.Rows.Count == 0)
            {
                MessageBox.Show("No book information returned", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Get current book information
            Book objBook = objBookServices.GetBookById(dgvReturn.CurrentRow.Cells[1].Value.ToString());

            //Encapsulated BookDetail Information
            BorrowBookDetail objDetai = new BorrowBookDetail
            {
                LastReturnDate = Convert.ToDateTime(dgvReturn.CurrentRow.Cells[3].Value),
                IsOverdue = Convert.ToBoolean(dgvReturn.CurrentRow.Cells[4].Value),
                IsLost = Convert.ToBoolean(dgvReturn.CurrentRow.Cells[5].Value),
            };


            if (objFrmReturnMoneyDetail == null)
            {
                objFrmReturnMoneyDetail = new frmReturnMoneyDetail(objBook, objDetai);
                objFrmReturnMoneyDetail.Show();
            }
            else
            {
                objFrmReturnMoneyDetail.Activate();
                objFrmReturnMoneyDetail.WindowState = FormWindowState.Normal;
            }
        }
        //Scan member Information
        private void txtMemberCardId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //Load user information
                LoadMemberInfo();
                //Determine the situation of changing users
                LoadNumInfo();
                //Display details in DataGridview
                LoadBookToDataGridView();
                //Fill the amount of each line of records, if not overdue and lost is 0.00 yuan, if there is overdue, two cents a day + 5 yuan handling fee, if both overdue also lost, overdue fee + book price + 5 Yuan
                LoadBookMoney();
                //Let Isbnh get the focus
                txtISBN.Focus();
            }

        }
        //Load all member Information
        private void btnViewAll_Click(object sender, EventArgs e)
        {
            if (objMember == null)
            {
                MessageBox.Show("No information on membership change was found.！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (objFrmMemberDetail == null)
            {
                objFrmMemberDetail = new frmMemberDetail(1, objMember);
                objFrmMemberDetail.Show();
            }
            else
            {
                objFrmMemberDetail.Activate();
                objFrmMemberDetail.WindowState = FormWindowState.Normal;
            }


        }
        //Setting Lose
        private void btnLost_Click(object sender, EventArgs e)
        {
            if (dgvReturn.Rows.Count == 0)
            {
                MessageBox.Show("No book information returned", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dgvReturn.SelectedRows.Count == 0) return;
            else
            {
                //Whether to lose the hook on the
                dgvReturn.CurrentRow.Cells[5].Value = true;
                //Reset Computer Amount
                if (Convert.ToBoolean(dgvReturn.CurrentRow.Cells[4].Value) == true)
                    dgvReturn.CurrentRow.Cells[6].Value = Convert.ToDouble(dgvReturn.CurrentRow.Cells[6].Value) + objBookServices.GetPriceById(dgvReturn.CurrentRow.Cells[1].Value.ToString());
                else
                    dgvReturn.CurrentRow.Cells[6].Value = objBookServices.GetPriceById(dgvReturn.CurrentRow.Cells[1].Value.ToString()) + 5.00;
                //Set up this submission hook
                dgvReturn.CurrentRow.Cells[7].Value = true;
                //Set up book compensation amount, late fee, handling fee
                lblBookCompensation.Text = (Convert.ToDouble(lblBookCompensation.Text) + objBookServices.GetPriceById(dgvReturn.CurrentRow.Cells[1].Value.ToString())).ToString("0.00");
                lblPoundage.Text = (Convert.ToDouble(lblPoundage.Text) + 5.00).ToString("0.00");
                if (Convert.ToBoolean(dgvReturn.CurrentRow.Cells[4].Value) == true)
                {
                    //Calculate the late fee first
                    double OverdueAmount = Convert.ToDouble(dgvReturn.CurrentRow.Cells[6].Value) - objBookServices.GetPriceById(dgvReturn.CurrentRow.Cells[1].Value.ToString()) - 5.00;
                    //Fill in again
                    lblOverdueAmount.Text = (Convert.ToDouble(lblOverdueAmount.Text) + OverdueAmount).ToString("0.00");

                }
                //Calculate Total Amount
                lblTotalMoney.Text = (Convert.ToDouble(lblBookCompensation.Text) + Convert.ToDouble(lblPoundage.Text) + Convert.ToDouble(lblOverdueAmount.Text)).ToString();
                //Total Return of the book
                lblCurrentReturnBookNumber.Text = (Convert.ToInt32(lblCurrentReturnBookNumber.Text) + 1).ToString();
            }
        }
    }
}
