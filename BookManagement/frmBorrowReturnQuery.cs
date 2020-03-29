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
    }
}
