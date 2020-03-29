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

namespace BookManagement
{
    public partial class frmBorrowBook : Form
    {
        //Instantiate a member Action class
        private MemberServices objMemberServices = new MemberServices();
        //Define a global Member
        private Member objMember = null;
        //Define a member detail form 
        public static frmMemberDetail objFrmMemberDetail = null;
        //Classes that instantiate library operations
        private BorrowBookServices objBorrowBookServices = new BorrowBookServices();
        //Instantiate the action class for the membership level
        private MemberLevelServices objMemberLevelServices = new MemberLevelServices();
        //Instantiate Detail Operation class
        private BorrowBookDetailServices objBorrowBookDetailServices = new BorrowBookDetailServices();
        // Define the BorrowId of the current user 
        private string borrowId = string.Empty;
        //Define a List that has borrowed books
        private DataTable dtBorrowed = null;
        //Instantiate List <Book>Stores books borrowed this time</Book>
        private List<Book> objListCurrentBorrow = new List<Book>();

        //Define a form for a book detail
        public static frmBookDetail objFrmBookDetail = null;
        //Instantiation of a book operation class
        private BookServices objBookServices = new BookServices();

        public frmBorrowBook()
        {
            InitializeComponent();
            //Initialization of DataGridView 
            dgvBorrowedList.AutoGenerateColumns = false;
            dgvCurrentBorrowList.AutoGenerateColumns = false;
        }
        //=========================================Control events==============================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //View all information about a member
        private void btnViewAllInfo_Click(object sender, EventArgs e)
        {
            if (objFrmMemberDetail == null)
            {
                //Form for meeting Membership details
                objFrmMemberDetail = new frmMemberDetail(1, objMember);
                //Display
                objFrmMemberDetail.Show();
            }
            else
            {
                objFrmMemberDetail.Activate();
                objFrmMemberDetail.WindowState = FormWindowState.Normal;
            }

        }

        private void txtMemberCardId_KeyDown(object sender, KeyEventArgs e)
        {
            //Press ENTER to trigger event
            if (e.KeyValue == 13)
            {
                //Load member Information
                LoadMemberInfo();

                //Determine if you have borrowed a book
                if (objBorrowBookServices.IsBorrowedBook(lblMemberId.Text))
                {
                    //I've already borrowed the book.
                    borrowId = objBorrowBookServices.GetBorrowIdByMemberId(lblMemberId.Text);
                    //Updating the database: Has the previously borrowed book expired
                    if (objBorrowBookServices.GetBorrowedNumByMemberId(lblMemberId.Text) > 0)
                    {
                        UpdateBorrowInfo();
                    }

                    //Initialization of the total number of borrowed, remaining totals, total overdue
                    BorrowBook objBorrowBook = objBorrowBookServices.GetBorrowBookByBorrowId(borrowId);
                    if (objBorrowBook != null)
                    {
                        lblBorrowedNum.Text = objBorrowBook.BorrowedNum.ToString();
                        lblCanBorrowNum.Text = (Convert.ToInt32(lblBorrowTotal.Text) - objBorrowBook.BorrowedNum).ToString();
                        lblOverdueNum.Text = objBorrowBook.OverdueNum.ToString();
                    }

                    //Load Books to DataGridView 
                    try
                    {
                        dtBorrowed = objBorrowBookDetailServices.GetBookByBorrowId(borrowId);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in obtaining the details of the books borrowed by members! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //Binding
                    dgvBorrowedList.DataSource = null;
                    dgvBorrowedList.DataSource = dtBorrowed;

                }
                else
                {
                    //I've never borrowed a book to initialize borrowId.
                    borrowId = CreateAndGetBorrowId();
                    //Initialization of the total number of borrowed, remaining totals, total overdue
                    lblBorrowedNum.Text = "0";
                    lblCanBorrowNum.Text = lblBorrowTotal.Text;
                    lblOverdueNum.Text = "0";


                }

                //Let book ISBN text get Focus 
                txtBookISBN.Focus();
            }
        }
        private void dgvBorrowedList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get a breakdown of the current book
            Book objBook = objBookServices.GetBookById(dgvBorrowedList.CurrentRow.Cells[1].Value.ToString());
            //Open Form 
            if (objFrmBookDetail == null)
            {
                objFrmBookDetail = new frmBookDetail(1, objBook);
                objFrmBookDetail.Show();
            }
            else
            {
                objFrmBookDetail.Activate();
                objFrmBookDetail.WindowState = FormWindowState.Normal;
            }

        }
    }
}
