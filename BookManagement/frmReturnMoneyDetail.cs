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

    }
}
