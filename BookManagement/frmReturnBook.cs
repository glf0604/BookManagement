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

        //Scan Books
        private void txtISBN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                //Load to the following categories
                AddReturnBook();
            }
        }


        //========================================Custom Methods==============================================
        //Load member Information
        private void LoadMemberInfo()
        {

            //Determine if the membership card number you entered is valid
            if (!CheckMemberCardInput()) return;

            //Instantiation of Member 
            try
            {
                objMember = objMemberServices.GetMemberByCardId(txtMemberCardId.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abnormal access to membership information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Assign value to control display
            lblMemberId.Text = objMember.MemberId;
            lblMemberName.Text = objMember.MemberName;
            lblMemberStatus.Text = objMember.CardStatus;
            if (string.IsNullOrWhiteSpace(objMember.MemberPhoto)) pbCurrentImage.BackgroundImage = null;
            else pbCurrentImage.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objMember.MemberPhoto);

            //Fill in the total number of debits available
            lblBorrowTotal.Text = objMemberLevelServices.GetMaxBorrowNumById(objMember.MemberLevel).ToString();


        }

        //Determine if membership card input is valid
        private bool CheckMemberCardInput()
        {
            if (string.IsNullOrWhiteSpace(txtMemberCardId.Text))
            {
                MessageBox.Show("Membership card number cannot be empty！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (!Common.ValidateInput.IsInteger(txtMemberCardId.Text.Trim()) || txtMemberCardId.Text.Trim().Length != 10)
            {
                MessageBox.Show("Membership card must be 10 digits", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMemberCardId.SelectAll();
                return false;
            }
            return true;
        }

        private void LoadNumInfo()
        {
            //Gets the user's BorrowId
            try
            {
                borrowId = objBorrowBookServices.GetBorrowIdByMemberId(lblMemberId.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("This membership card has never been used! There is no information about borrowing books!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Fill Quantity
                lblBorrowedNum.Text = "0";
                lblCanBorrowNum.Text = lblBorrowTotal.Text;
                lblOverdueNum.Text = "0";
                //Clear
                dgvReturn.DataSource = null;
                //Ending
                return;
            }

            //Update Basedate
            if (objBorrowBookServices.GetBorrowedNumByMemberId(lblMemberId.Text) > 0)
            {
                UpdateBorrowInfo();
            }

            //Full in number
            BorrowBook objBorrowBook = objBorrowBookServices.GetBorrowBookByBorrowId(borrowId);
            //Fill in quantity
            lblBorrowedNum.Text = objBorrowBook.BorrowedNum.ToString();
            lblCanBorrowNum.Text = (Convert.ToInt32(lblBorrowTotal.Text) - objBorrowBook.BorrowedNum).ToString();
            lblOverdueNum.Text = objBorrowBook.OverdueNum.ToString();
        }


        //Update expired information
        private void UpdateBorrowInfo()
        {

            try
            {
                objBorrowBookDetailServices.UpdateOverdue(borrowId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("01 Update database abnormal! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Count the amount of books borrowed and the amount of expired books
            int borrowedNum = objBorrowBookDetailServices.GetBorrowBookNum(borrowId);
            int overdueNum = objBorrowBookDetailServices.GetBorrowBookOverdue(borrowId);
            try
            {
                if (objBorrowBookServices.UpdateBorrowedNumAndOverdue(borrowId, borrowedNum, overdueNum) == 1)
                {
                    MessageBox.Show("Update database successfully!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("02 Update database abnormal! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //Load the book details of the current user
        private void LoadBookToDataGridView()
        {
            if (lblBorrowedNum.Text.Trim() != "0")
            {
                try
                {
                    dt = objBorrowBookDetailServices.GetBookByBorrowId(borrowId);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Abnormal access to the details of the member's book borrowing! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                //Bind to datagGridview 
                dgvReturn.DataSource = null;
                dgvReturn.DataSource = dt;
            }
            else
            {
                //Clear
                dgvReturn.DataSource = null;
            }

        }

        //Fill the amount of each book
        private void LoadBookMoney()
        {
            if (dgvReturn.Rows.Count == 0) return;
            //Traversing a table
            for (int i = 0; i < dgvReturn.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvReturn.Rows[i].Cells[4].Value) == false)
                {
                    dgvReturn.Rows[i].Cells[6].Value = "0.00";
                }
                else
                {
                    DateTime today = DateTime.Now;
                    DateTime lastReturnDate = Convert.ToDateTime(dgvReturn.Rows[i].Cells[3].Value);
                    TimeSpan days = today.Subtract(lastReturnDate);
                    dgvReturn.Rows[i].Cells[6].Value = days.Days * 0.2 + 5.00;
                }
            }
        }

        //Add ReturnBook
        private void AddReturnBook()
        {
            //Is it in the following list
            for (int i = 0; i < dgvReturn.Rows.Count; i++)
            {
                if (dgvReturn.Rows[i].Cells[0].Value.ToString() == txtISBN.Text.Trim() && Convert.ToBoolean(dgvReturn.Rows[i].Cells[7].Value) == true)
                {
                    MessageBox.Show("This book has been processed.！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                }
                else if (dgvReturn.Rows[i].Cells[0].Value.ToString() == txtISBN.Text.Trim())
                {
                    //Change the background color
                    dgvReturn.Rows[0].Selected = false;
                    dgvReturn.Rows[i].DefaultCellStyle.BackColor = Color.DarkRed;
                    dgvReturn.Rows[i].DefaultCellStyle.ForeColor = Color.Yellow;
                    //Hook up this submission book
                    dgvReturn.Rows[i].Cells[7].Value = true;
                    //If overdue, calculate late fees and handling fees
                    if (Convert.ToBoolean(dgvReturn.Rows[i].Cells[4].Value) == true)
                    {
                        //Handling fee
                        lblPoundage.Text = (Convert.ToDouble(lblPoundage.Text) + 5.00).ToString("0.00");
                        //Late fees
                        lblOverdueAmount.Text = (Convert.ToDouble(lblOverdueAmount.Text) + Convert.ToDouble(dgvReturn.Rows[i].Cells[6].Value) - 5.00).ToString("0.00");
                        //Total Price
                        lblTotalMoney.Text = (Convert.ToDouble(lblBookCompensation.Text) + Convert.ToDouble(lblPoundage.Text) + Convert.ToDouble(lblOverdueAmount.Text)).ToString();
                    }
                    //Return of books this time+1
                    lblCurrentReturnBookNumber.Text = (Convert.ToInt32(lblCurrentReturnBookNumber.Text) + 1).ToString();
                    //Jumping out of the loop
                    break;
                }
                if (i == dgvReturn.Rows.Count - 1)
                {
                    MessageBox.Show("You have not borrowed this book.！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            //Empty The scanned ISBN
            txtISBN.Text = string.Empty;

        }

        private void dgvReturn_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get information about a book
            Book objBook = objBookServices.GetBookById(dgvReturn.CurrentRow.Cells[1].Value.ToString());

            //Load form
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

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //Preparing data
            List<BorrowBookDetail> objListDetail = new List<BorrowBookDetail>();

            //Traversing DataGridView 
            for (int i = 0; i < dgvReturn.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgvReturn.Rows[i].Cells[7].Value) == true)
                {
                    //Instantiate an Object
                    BorrowBookDetail objDetail = new BorrowBookDetail();
                    objDetail.DetailId = objBorrowBookDetailServices.GetDetailId(borrowId, dgvReturn.Rows[i].Cells[1].Value.ToString());
                    objDetail.BorrowId = borrowId;
                    objDetail.BookId = dgvReturn.Rows[i].Cells[1].Value.ToString();
                    objDetail.LastReturnDate = Convert.ToDateTime(dgvReturn.Rows[i].Cells[3].Value);
                    objDetail.IsOverdue = Convert.ToBoolean(dgvReturn.Rows[i].Cells[4].Value);
                    objDetail.IsLost = Convert.ToBoolean(dgvReturn.Rows[i].Cells[5].Value);
                    //Add to List
                    objListDetail.Add(objDetail);
                }
            }

            if (objListDetail == null)
            {
                MessageBox.Show("There are no books to submit！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Submit 
            try
            {
                if (objBorrowBookDetailServices.CommitReturnBook(objListDetail, Program.currentUser.LoginId, objMember))
                {
                    //Updating user information
                    LoadNumInfo();
                    //This return of the book=0
                    lblCurrentReturnBookNumber.Text = "0";
                    //In turn, delete the submitted
                    for (int i = 0; i < dgvReturn.Rows.Count; i++)
                    {
                        if (Convert.ToBoolean(dgvReturn.Rows[i].Cells[7].Value) == true)
                        {
                            dgvReturn.Rows.RemoveAt(i);
                        }
                    }
                    //Replacement fee
                    lblBookCompensation.Text = "0.00";
                    lblPoundage.Text = "0.00";
                    lblOverdueAmount.Text = "0.00";
                    lblTotalMoney.Text = "0.00";
                    //Notice Successful！
                    MessageBox.Show("Successful submission of return information！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Abnormal submission of books! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
