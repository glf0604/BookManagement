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
    }
}
