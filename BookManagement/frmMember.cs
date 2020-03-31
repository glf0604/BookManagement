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

        //Add Member Information
        private void btnAdd_Click(object sender, EventArgs e)
        {

            //【2】 Initialization of ActionFlag 
            actionFlag = 2;

            //【3】 Loading a form
            if (objFrmMemberDetail == null)
            {
                objFrmMemberDetail = new frmMemberDetail(actionFlag, null);
                DialogResult result = objFrmMemberDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Refresh table Data
                    LoadMemberInfo();
                }
            }
            else
            {
                objFrmMemberDetail.Activate();
                objFrmMemberDetail.WindowState = FormWindowState.Maximized;
            }
        }

        //Modify member Information
        private void btnUpdate_Click(object sender, EventArgs e)
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
            actionFlag = 3;

            //【3】 Loading a form
            if (objFrmMemberDetail == null)
            {
                objFrmMemberDetail = new frmMemberDetail(actionFlag, objMember);
                DialogResult result = objFrmMemberDetail.ShowDialog();
                if (result == DialogResult.OK)
                {
                    //Refresh
                    LoadMemberInfo();
                }
            }
            else
            {
                objFrmMemberDetail.Activate();
                objFrmMemberDetail.WindowState = FormWindowState.Maximized;
            }

        }

        //Delete Member information
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Judgment
            if (dgvMember.Rows.Count == 0)
            {
                MessageBox.Show("No member information can be deleted!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (dgvMember.CurrentCell.Selected == false)
            {

                MessageBox.Show("You must select a member's information before deleting it! ", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string memberId = dgvMember.CurrentRow.Cells[0].Value.ToString();
                string memberName = dgvMember.CurrentRow.Cells[2].Value.ToString();
                string info = "You are sure you want to delete membership information【Member Id：" + memberId + " Members Name：" + memberName + "】？";
                DialogResult result = MessageBox.Show(info, "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        if (objMemberServices.DeleteMember(memberId) == 1)
                        {
                            //Notice Successful！
                            MessageBox.Show("Delete Member information successful！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh
                            LoadMemberInfo();

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Abnormal deletion of membership information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else return;
            }
        }

        //============================================Custom Methods================================================

        private void LoadMemberInfo()
        {
            //Initialization of DataTable 
            try
            {
                dt = objMemberServices.GetMember(txtQueryMemberCardId.Text.Trim(), txtQueryMemberId.Text.Trim(), txtQueryMemberName.Text.Trim(), txtQueryTelNo.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Abnormal deletion of membership information! Specific reasons:" + ex.Message, "System Note", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Load to DataGridView
            dgvMember.DataSource = null;
            dgvMember.DataSource = dt;
        }
    }
}
