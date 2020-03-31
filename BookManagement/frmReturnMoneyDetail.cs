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
    public partial class frmReturnMoneyDetail : Form
    {
        //Instantiation Publishing House Operation class
        private BookPressServices objBookPressServices = new BookPressServices();

        public frmReturnMoneyDetail()
        {
            InitializeComponent();
        }
        public frmReturnMoneyDetail(Book objBook, BorrowBookDetail objDetail) : this()
        {
            //Load book information
            LoadBookInfo(objBook);

            //Load fee information
            LoadMoneyDetail(objDetail);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void frmReturnMoneyDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmReturnBook.objFrmReturnMoneyDetail = null;
        }
        //Load Book Information
        private void LoadBookInfo(Book objBook)
        {
            //Picture
            //Text change to picture
            if (string.IsNullOrWhiteSpace(objBook.BookImage)) pbCurrentBook.BackgroundImage = null;
            else pbCurrentBook.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objBook.BookImage);

            //ISBN
            lblBookISBN.Text = objBook.ISBN;
            //name
            lblBookName.Text = objBook.BookName;
            //author
            lblBookAuthor.Text = objBook.BookAuthor;
            //Press
            lblBookPress.Text = objBookPressServices.GetPressNameById(objBook.BookPress);

            //Price
            lblBookPrice.Text = objBook.BookPrice.ToString("0.00");
        }
        //Load fee detail
        private void LoadMoneyDetail(BorrowBookDetail objDetail)
        {
            lblLastReturnDate.Text = objDetail.LastReturnDate.ToShortDateString();
            lblCurrentDate.Text = DateTime.Now.ToShortDateString();
            if (objDetail.IsOverdue == false)
            {
                lblOverdueDays.Text = "0";
            }
            else
            {
                DateTime today = DateTime.Now;
                DateTime lastReturnDate = objDetail.LastReturnDate;
                TimeSpan days = today.Subtract(lastReturnDate);
                lblOverdueDays.Text = days.Days.ToString();
                lblTotalAmount.Text = (Convert.ToDouble(lblOverdueDays.Text) * Convert.ToDouble(lblAmountPerDay.Text)).ToString("0.00");
            }

            //Handling fee
            if (objDetail.IsOverdue || objDetail.IsLost)
            {
                lblPoundage.Text = "5.00";
            }
            //Loss of compensation
            if (objDetail.IsLost) lblLostBookCompensation.Text = lblBookPrice.Text;

            //Total Price:
            lblTotalMoney.Text = (Convert.ToDouble(lblTotalAmount.Text) + Convert.ToDouble(lblPoundage.Text) + Convert.ToDouble(lblLostBookCompensation.Text)).ToString("0.00");


        }
    }
}
