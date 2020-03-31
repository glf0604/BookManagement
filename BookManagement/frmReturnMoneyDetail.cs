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
    }
}
