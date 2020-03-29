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
    }
}
