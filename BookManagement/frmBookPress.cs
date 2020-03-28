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
    public partial class frmBookPress : Form
    {
        //Instantiation Publishing House Operation class
        private BookPressServices objBookPressServices = new BookPressServices();

        //Instantiate the value returned by a DataTable--receive database
        private DataTable dt = new DataTable();

        //Instantiate the form of the publishing house detail
        public static frmBookPressDetail objFrmBookPressDetail = null;

        //Define what action a variable identity performs 
        private int actionFlag = 0;  //1---View 2---add 3---Modify

        public frmBookPress()
        {
            InitializeComponent();

            //Initialize the DataGridView control 
            dgvPress.AutoGenerateColumns = false;
            //Loading data
            LoadPressInfo();
        }

        //=============================Loading data====================================
        private void btnQuery_Click(object sender, EventArgs e)
        {
            //Invoking the Load data method
            LoadPressInfo();
        }
        private void btnAllPress_Click(object sender, EventArgs e)
        {
            txtQueryPressId.Text = string.Empty;
            txtQueryPressName.Text = string.Empty;

            //Invoking the Load data method
            LoadPressInfo();
        }
        private void dgvPress_DoubleClick(object sender, EventArgs e)
        {

            //===============View publisher Information====

            //Get click on this line of data
            BookPress objBookPress = new BookPress()
            {
                PressId = Convert.ToInt32(dgvPress.CurrentRow.Cells[0].Value),
                PressName = dgvPress.CurrentRow.Cells[1].Value.ToString(),
                PressTel = dgvPress.CurrentRow.Cells[2].Value.ToString(),
                PressContact = dgvPress.CurrentRow.Cells[3].Value.ToString(),
                PressAddress = dgvPress.CurrentRow.Cells[4].Value.ToString(),
            };

            //Modify Actionflag---See
            actionFlag = 1;


            //Open the Detail form 
            if (objFrmBookPressDetail == null)
            {
                objFrmBookPressDetail = new frmBookPressDetail(actionFlag, objBookPress);
                objFrmBookPressDetail.Show();
            }
            else
            {
                objFrmBookPressDetail.Activate();
                objFrmBookPressDetail.WindowState = FormWindowState.Normal;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Add publisher


            //Modify Actionflag---Add
            actionFlag = 2;
            //Open the Detail form 
            if (objFrmBookPressDetail == null)
            {
                objFrmBookPressDetail = new frmBookPressDetail(actionFlag, null);
                DialogResult result = objFrmBookPressDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadPressInfo();
                }
            }
            else
            {
                objFrmBookPressDetail.Activate();
                objFrmBookPressDetail.WindowState = FormWindowState.Normal;
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Modify Publishing house information


            //Get click on this line of data
            BookPress objBookPress = new BookPress()
            {
                PressId = Convert.ToInt32(dgvPress.CurrentRow.Cells[0].Value),
                PressName = dgvPress.CurrentRow.Cells[1].Value.ToString(),
                PressTel = dgvPress.CurrentRow.Cells[2].Value.ToString(),
                PressContact = dgvPress.CurrentRow.Cells[3].Value.ToString(),
                PressAddress = dgvPress.CurrentRow.Cells[4].Value.ToString(),
            };

            //Modify Actionflag---Modifications
            actionFlag = 3;
            //Open the Detail form 
            if (objFrmBookPressDetail == null)
            {
                objFrmBookPressDetail = new frmBookPressDetail(actionFlag, objBookPress);
                DialogResult result = objFrmBookPressDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Refresh Data in DataGridView
                    LoadPressInfo();
                }
            }
            else
            {
                objFrmBookPressDetail.Activate();
                objFrmBookPressDetail.WindowState = FormWindowState.Normal;
            }
        }
    }
}
