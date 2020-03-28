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
    public partial class frmBookPressDetail : Form
    {
        //The Operation method Class of instantiated publishing house 
        private BookPressServices objBookPressServices = new BookPressServices();

        //Defines a actionFlag that is used to distinguish whether to add or modify at the time of submission
        private int actionFlag = 0;  //2--Add    3---Modify

        public frmBookPressDetail()
        {
            InitializeComponent();
        }

        //Construction method of carrying parameters
        public frmBookPressDetail(int flag, BookPress objBookPress) : this()
        {

            //flag:  1---view   2---add   3---modify 
            //Initialization of local ActionFlag
            actionFlag = flag;

            //Perform different actions according to Flag
            switch (flag)
            {
                case 1:
                    LoadViewForm(objBookPress);
                    break;
                case 2:
                    LoadAddForm();
                    break;
                case 3:
                    LoadUpdateForm(objBookPress);
                    break;
            }

        }

        //-=================================Control methods================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBookPressDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBookPress.objFrmBookPressDetail = null;
        }
    }
}
