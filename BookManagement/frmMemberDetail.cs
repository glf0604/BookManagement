﻿using System;
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
using MyVideo;

namespace BookManagement
{
    public partial class frmMemberDetail : Form
    {
        //Instantiate member Action Class 
        private MemberServices objMemberServices = new MemberServices();
        //Instantiate the action class for the membership level 
        private MemberLevelServices objMemberLevelServices = new MemberLevelServices();
        //Ways to instantiate user logon
        private SysAdminsServices objSysAdminsServices = new SysAdminsServices();
        //Define local action identifiers
        private int actionFlag = 0;
        //Define Camera manipulation classes
        private Video objVideo = null;

        public frmMemberDetail()
        {
            InitializeComponent();
        }
        public frmMemberDetail(int flag, Member objMember) : this()
        {
            //Initialize Local action identifier 
            actionFlag = flag;
            //More operators to choose different loading methods
            switch (flag)
            {
                case 1://View
                    LoadViewForm(objMember);
                    break;
                case 2://Add
                    LoadAddForm();
                    break;
                case 3://Modify
                    LoadUpdateForm(objMember);
                    break;
            }
        }
        //=====================================Control events =======================================

        //Close the Detail form
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        //Empty the form when you close the form
        private void frmMemberDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMember.objFrmMemberDetail = null;
            frmBorrowBook.objFrmMemberDetail = null;
            frmReturnBook.objFrmMemberDetail = null;
        }
        //Automatically generate membership numbers when selecting a membership level
        private void cboMemberLevel_SelectedValueChanged(object sender, EventArgs e)
        {
            //Determine if it is empty
            if (cboMemberLevel.SelectedItem == null) return;
            else if (!Common.ValidateInput.IsInteger(cboMemberLevel.SelectedValue.ToString())) return;
            else
            {
                //Automatically generate membership numbers
                lblMemberId.Text = objMemberServices.BuildMemberId(Convert.ToInt32(cboMemberLevel.SelectedValue));
                //Fill Deposit Amount
                lblDeposit.Text = objMemberLevelServices.GetDepositById(Convert.ToInt32(cboMemberLevel.SelectedValue)).ToString("0.00");
                //Expiration date of automatic fill card
                if (!string.IsNullOrWhiteSpace(lblOperatingTime.Text))
                {
                    int months = objMemberLevelServices.GetMonthsById(Convert.ToInt32(cboMemberLevel.SelectedValue));
                    dtpCardClosingDate.Text = (Convert.ToDateTime(lblOperatingTime.Text).AddMonths(months)).ToString();
                }

            }

        }
        #region Member Photo processing
        //Choice Picture
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            //Instantiate select File class
            OpenFileDialog objOpenFile = new OpenFileDialog();
            //Display the type of file
            objOpenFile.Filter = "picture file|*.jpg;*.png;*.bmp";
            //Whether to select a file
            if (objOpenFile.ShowDialog() == DialogResult.OK)
            {
                pbCurrentImage.BackgroundImage = Image.FromFile(objOpenFile.FileName);
            }
        }
        //Clear Photos
        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
            pbCurrentImage.BackgroundImage = null;
        }

        //Start the camera.
        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            try
            {
                objVideo = new Video(pbImage.Handle, pbImage.Left, pbImage.Top, pbImage.Width, (short)pbImage.Height);
                objVideo.OpenVideo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Camera enabled failed！Specific reasons：" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //Turn off the camera
        private void btnCloseCamera_Click(object sender, EventArgs e)
        {
            objVideo.CloseVideo();
        }
    }
}
