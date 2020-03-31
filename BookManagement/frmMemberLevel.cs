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
    }
}
