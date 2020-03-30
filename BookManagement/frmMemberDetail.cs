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
        //Start taking pictures.
        private void btnStartPhoto_Click(object sender, EventArgs e)
        {
            pbCurrentImage.BackgroundImage = objVideo.CatchVideo();
        }
        #endregion
        //=====================================Custom events =======================================
        //Load a form as viewed
        private void LoadViewForm(Member objMember)
        {

            //Change Title Display
            lblTitle.Text = "【Query Member Information】";

            //Hide Space
            pbImage.Visible = false;
            btnClearPhoto.Visible = false;
            btnStartPhoto.Visible = false;
            btnStartCamera.Visible = false;
            btnCloseCamera.Visible = false;
            btnSelectPhoto.Visible = false;
            btnCommit.Visible = false;
            btnCancel.Text = "Close";

            //Disable all controls
            cboMemberLevel.Enabled = false;
            txtMemberCardId.Enabled = false;
            txtMemberName.Enabled = false;
            cboIdType.Enabled = false;
            txtIdCardNumber.Enabled = false;
            rbFemale.Enabled = false;
            rbMale.Enabled = false;
            txtTelNo.Enabled = false;
            dtpBirthday.Enabled = false;
            txtHomeAddress.Enabled = false;
            cboCardStatus.Enabled = false;
            dtpCardClosingDate.Enabled = false;
            cboPayMethod.Enabled = false;
            txtRemarks.Enabled = false;

            //Initialize data
            cboMemberLevel.Text = objMemberLevelServices.GetNameById(objMember.MemberLevel);
            txtMemberCardId.Text = objMember.MemberCardId;
            lblMemberId.Text = objMember.MemberId;
            txtMemberName.Text = objMember.MemberName;
            cboIdType.Text = objMember.IdType;
            txtIdCardNumber.Text = objMember.IdNumber;
            if (objMember.Gender == "Male") rbMale.Checked = true;
            else rbFemale.Checked = true;
            txtTelNo.Text = objMember.TelNo;
            dtpBirthday.Text = objMember.Birthday.ToString();
            txtHomeAddress.Text = objMember.HomeAddress;
            cboCardStatus.Text = objMember.CardStatus;
            dtpCardClosingDate.Text = objMember.CardClosingDate.ToString();
            cboPayMethod.Text = objMember.PayMethod;
            lblDeposit.Text = objMemberLevelServices.GetDepositById(objMember.MemberLevel).ToString("0.00");
            lblUserName.Text = objSysAdminsServices.GetUserName(objMember.LoginId);
            lblOperatingTime.Text = objMember.OperatingTime.ToString();
            txtRemarks.Text = objMember.ReMarks;
            //Turn the text into a diagram
            if (string.IsNullOrWhiteSpace(objMember.MemberPhoto)) pbCurrentImage.BackgroundImage = null;
            else pbCurrentImage.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objMember.MemberPhoto);

        }
        //Load a form in a way that you add
        private void LoadAddForm()
        {
            //Modify Titel 
            lblTitle.Text = "【Add Member Information】";
            //Fill the drop-down box data
            List<MemberLevel> objListLevel = objMemberLevelServices.GetLevelList();
            cboMemberLevel.DataSource = objListLevel;
            cboMemberLevel.DisplayMember = "LevelName";
            cboMemberLevel.ValueMember = "LevelId";
            cboMemberLevel.SelectedIndex = -1;
            cboMemberLevel.Text = "Please select membership level";

            //Clear MemberId
            lblMemberId.Text = string.Empty;

            //Initialization of the agent and time
            lblUserName.Text = Program.currentUser.UserName;
            lblOperatingTime.Text = objSysAdminsServices.GetServerTime().ToString("yyy-MM-dd HH:mm:ss");

            //Modify the Operation Flag 
            actionFlag = 2;

        }
        //Load a form in a modified manner
        private void LoadUpdateForm(Member objMember)
        {
            //Change Title Display
            lblTitle.Text = "【Modify Member Information】";

            //Initialize data
            cboMemberLevel.Text = objMemberLevelServices.GetNameById(objMember.MemberLevel);
            txtMemberCardId.Text = objMember.MemberCardId;
            lblMemberId.Text = objMember.MemberId;
            txtMemberName.Text = objMember.MemberName;
            cboIdType.Text = objMember.IdType;
            txtIdCardNumber.Text = objMember.IdNumber;
            if (objMember.Gender == "Male") rbMale.Checked = true;
            else rbFemale.Checked = true;
            txtTelNo.Text = objMember.TelNo;
            dtpBirthday.Text = objMember.Birthday.ToString();
            txtHomeAddress.Text = objMember.HomeAddress;
            cboCardStatus.Text = objMember.CardStatus;
            dtpCardClosingDate.Text = objMember.CardClosingDate.ToString();
            cboPayMethod.Text = objMember.PayMethod;
            lblDeposit.Text = objMemberLevelServices.GetDepositById(objMember.MemberLevel).ToString("0.00");
            lblUserName.Text = objSysAdminsServices.GetUserName(objMember.LoginId);
            lblOperatingTime.Text = objMember.OperatingTime.ToString();
            txtRemarks.Text = objMember.ReMarks;
            //Turn the text into a diagram
            if (string.IsNullOrWhiteSpace(objMember.MemberPhoto)) pbCurrentImage.BackgroundImage = null;
            else pbCurrentImage.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objMember.MemberPhoto);

            //Disable two controls
            cboMemberLevel.Enabled = false;
            cboPayMethod.Enabled = false;

        }
    }
}
