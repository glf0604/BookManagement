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
    }
}
