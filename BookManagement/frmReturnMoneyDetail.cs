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
    }
}
