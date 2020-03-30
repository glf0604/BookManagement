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
    public partial class frmMember : Form
    {
        //Instantiate Member Operation class 
        private MemberServices objMemberServices = new MemberServices();
        //Instantiate a DataTable to store all member information
        private DataTable dt = new DataTable();
        //Define local action identifiers
        private int actionFlag = 0; //1---View  2---Add   3---Modify
        //Instantiate a form
        public static frmMemberDetail objFrmMemberDetail = null;

        public frmMember()
        {
            InitializeComponent();
            //Initialization of DataGridView
            dgvMember.AutoGenerateColumns = false;
            //Load member Information
            LoadMemberInfo();
        }

        //============================================Control events================================================

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            LoadMemberInfo();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            //Set all query input boxes to null
            txtQueryMemberCardId.Text = string.Empty;
            txtQueryMemberId.Text = string.Empty;
            txtQueryMemberName.Text = string.Empty;
            txtQueryTelNo.Text = string.Empty;

            LoadMemberInfo();
        }
        private void txtQueryMemberCardId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                LoadMemberInfo();
            }
        }
        //View member Information
        private void dgvMember_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //【1】Gets the member details for the selected row 
            Member objMember = null;
            try
            {
                objMember = objMemberServices.GetMemberById(dgvMember.CurrentRow.Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {

                MessageBox.Show("Abnormal access to selected member information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //【2】 Initialization of ActionFlag 
            actionFlag = 1;

            //【3】 Loading a form
            if (objFrmMemberDetail == null)
            {
                objFrmMemberDetail = new frmMemberDetail(actionFlag, objMember);
                objFrmMemberDetail.Show();
            }
            else
            {
                objFrmMemberDetail.Activate();
                objFrmMemberDetail.WindowState = FormWindowState.Maximized;
            }

        }
    }
}
