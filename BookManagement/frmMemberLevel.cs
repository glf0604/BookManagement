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
    public partial class frmMemberLevel : Form
    {
        //Instantiate a List<MemberLevel>and store all The memberlevel information</MemberLevel>
        private List<MemberLevel> objListLevel = new List<MemberLevel>();
        //An operational method class that instantiates a member level
        private MemberLevelServices objMemberLevelServices = new MemberLevelServices();
        //Define a representation of an action
        private int actionFlag = 0; //1--Add  2--Modify 

        public frmMemberLevel()
        {
            InitializeComponent();
            //Disable Detail area
            gboxMemberLevel.Enabled = false;
            //Load member level data to Listview display
            LoadMemberLevelInfo();
        }

        //====================================Control events==========================================


        private void lvMemeberLevel_Click(object sender, EventArgs e)
        {
            //Instantiate an object of a membership level
            MemberLevel objMemberLevel = new MemberLevel();
            //Get name
            objMemberLevel.LevelName = lvMemeberLevel.SelectedItems[0].Text;
            //"Method 1": Find by name to database
            //try
            //{
            //    objMemberLevel = objMemberLevelServices.GetMemberLevelByName(objMemberLevel.LevelName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Get membership level information through the rank name exception occurs! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

            //"Method 2": Find in the local List
            for (int i = 0; i < objListLevel.Count; i++)
            {
                if (objListLevel[i].LevelName == objMemberLevel.LevelName)
                {
                    objMemberLevel.LevelId = objListLevel[i].LevelId;
                    objMemberLevel.LevelMonths = objListLevel[i].LevelMonths;
                    objMemberLevel.MaxBorrowNum = objListLevel[i].MaxBorrowNum;
                    objMemberLevel.MaxBorrowDays = objListLevel[i].MaxBorrowDays;
                    objMemberLevel.Deposit = objListLevel[i].Deposit;
                    break;
                }
            }

            //Display Date
            lblLevelId.Text = objMemberLevel.LevelId.ToString();
            txtLevelName.Text = objMemberLevel.LevelName;
            txtLevelMonths.Text = objMemberLevel.LevelMonths.ToString();
            txtMaxBorrowNum.Text = objMemberLevel.MaxBorrowNum.ToString();
            txtMaxBorrowDays.Text = objMemberLevel.MaxBorrowDays.ToString();
            txtDeposit.Text = objMemberLevel.Deposit.ToString("0.00");
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            //【1】Enable Detail Area
            gboxMemberLevel.Enabled = true;

            //【2】Automatically generates a level number and displays it in the numbered area
            lblLevelId.Text = objMemberLevelServices.BuildNewLevelId();

            //【3】Make all text boxes empty
            txtLevelMonths.Text = string.Empty;
            txtLevelName.Text = string.Empty;
            txtMaxBorrowDays.Text = string.Empty;
            txtMaxBorrowNum.Text = string.Empty;
            txtDeposit.Text = string.Empty;

            //【4】 Let the level name get focus
            txtLevelName.Focus();

            //【5】 Modify ActionFlag
            actionFlag = 1;
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            //【1】 Checksum input
            if (!CheckMemberLevelInput()) return;

            //【2】 Encapsulating data to Objects
            MemberLevel objMemberLevel = new MemberLevel()
            {
                LevelId = Convert.ToInt32(lblLevelId.Text),
                LevelName = txtLevelName.Text.Trim(),
                LevelMonths = Convert.ToInt32(txtLevelMonths.Text.Trim()),
                MaxBorrowNum = Convert.ToInt32(txtMaxBorrowNum.Text.Trim()),
                MaxBorrowDays = Convert.ToInt32(txtMaxBorrowDays.Text.Trim()),
                Deposit = Convert.ToDouble(txtDeposit.Text.Trim()),
            };

            //【3】 Submit
            switch (actionFlag)
            {
                case 1://Add 
                    try
                    {
                        if (objMemberLevelServices.AddMemberLevel(objMemberLevel) == 1)
                        {
                            //Notice successful
                            MessageBox.Show("Added Membership Level Added Successfully!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Refresh
                            LoadMemberLevelInfo();

                            //Disable Detail 
                            gboxMemberLevel.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is an exception to adding membership level! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 2: //Modify
                    try
                    {
                        if (objMemberLevelServices.UpdateMemberLevel(objMemberLevel) == 1)
                        {
                            //Notice Successful
                            MessageBox.Show("Modify membership level to add success!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //Refresh
                            LoadMemberLevelInfo();

                            //Disable Detail 
                            gboxMemberLevel.Enabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("There is an exception in modifying the membership level! __________ Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Determine if a level is selected 
            if (string.IsNullOrWhiteSpace(lblLevelId.Text))
            {
                MessageBox.Show("A level must be selected before modification", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Enable the right detail 
            gboxMemberLevel.Enabled = true;

            //Disable member name
            txtLevelName.Enabled = false;

            //Let the library cycle get the focus
            txtLevelMonths.Focus();

            //Modify Flag
            actionFlag = 2;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Determine if a level is selected 
            if (string.IsNullOrWhiteSpace(lblLevelId.Text))
            {
                MessageBox.Show("A level must be selected before modification", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //Perform deletion 
            string levelName = txtLevelName.Text.Trim();
            string info = "You are sure you want to delete the membership level【Level name：" + levelName + "】？";
            DialogResult result = MessageBox.Show(info, "System Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (objMemberLevelServices.DeleteMemberLevel(levelName) == 1)
                    {
                        //Notice！
                        MessageBox.Show("Successful deletion of membership level information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh
                        LoadMemberLevelInfo();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Abnormal deletion of membership level information! Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else return;



        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            gboxMemberLevel.Enabled = false;

            lblLevelId.Text = string.Empty;
            txtLevelName.Text = string.Empty;
            txtLevelMonths.Text = string.Empty;
            txtMaxBorrowDays.Text = string.Empty;
            txtMaxBorrowNum.Text = string.Empty;
            txtDeposit.Text = string.Empty;
        }


        //===================================Custom Methods===========================================

        private bool CheckMemberLevelInput()
        {
            //Member name: Not allowed to be empty, cannot be repeated
            if (string.IsNullOrWhiteSpace(txtLevelName.Text))
            {
                MessageBox.Show("Level name cannot be empty！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (objMemberLevelServices.IsExistLevelName(txtLevelName.Text.Trim()) && actionFlag == 1)
            {
                MessageBox.Show("The level name already exists！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLevelName.Focus();
                txtLevelName.SelectAll();
                return false;
            }

            //Cannot be empty, must be an integer
            if (!Common.ValidateInput.IsInteger(txtLevelMonths.Text.Trim()) || string.IsNullOrWhiteSpace(txtLevelMonths.Text))
            {
                MessageBox.Show("Membership cycle must be integer and not empty！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLevelMonths.Focus();
                return false;
            }
            if (!Common.ValidateInput.IsInteger(txtMaxBorrowNum.Text.Trim()) || string.IsNullOrWhiteSpace(txtMaxBorrowNum.Text))
            {
                MessageBox.Show("The maximum borrowing period must be an integer and not empty.！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxBorrowNum.Focus();
                return false;
            }
            if (!Common.ValidateInput.IsInteger(txtMaxBorrowDays.Text.Trim()) || string.IsNullOrWhiteSpace(txtMaxBorrowDays.Text))
            {
                MessageBox.Show("Maximum borrowing time must be integer and not empty！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaxBorrowDays.Focus();
                return false;
            }
            if (!Common.ValidateInput.IsInteger(txtDeposit.Text.Trim().Replace(".", "")) || string.IsNullOrWhiteSpace(txtDeposit.Text))
            {
                MessageBox.Show("The amount of deposit must be numeric and not empty.！", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDeposit.Focus();
                return false;
            }


            return true;
        }

        private void LoadMemberLevelInfo()
        {
            //Initialization of ObjListlevel 
            try
            {
                objListLevel = objMemberLevelServices.GetMemberLevel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There is an exception in loading membership rank information! ___________ Specific reasons:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Show the data to ListView 
            //【1】Clear
            lvMemeberLevel.Items.Clear();

            //【2】Determine if it is empty
            if (objListLevel == null) return;

            //【3】If it is not empty, load the
            lvMemeberLevel.View = View.LargeIcon;
            lvMemeberLevel.LargeImageList = imageList1;
            lvMemeberLevel.BeginUpdate();

            //Traverse
            for (int i = 0; i < objListLevel.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                if (i > 5)
                {
                    lvi.ImageIndex = 5;
                }
                else
                {
                    lvi.ImageIndex = i;
                }
                lvi.Text = objListLevel[i].LevelName;
                lvMemeberLevel.Items.Add(lvi);
            }
            lvMemeberLevel.EndUpdate();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
