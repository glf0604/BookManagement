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
using System.Collections;

namespace BookManagement
{
    public partial class frmBookDetail : Form
    {
        //Instantiate the Operation class of the publishing house
        private BookPressServices objBookPressServices = new BookPressServices();
        //The Operation class of instantiated books
        private BookServices objBookServices = new BookServices();
        //Operational classes that instantiate book categories
        private BookTypeServices objBookTypeServices = new BookTypeServices();
        //Define the Global book publishing house List initialization drop-down box
        private List<BookPress> objListPress = new List<BookPress>();
        //Define a global book category (Level I) List initialization drop-down box
        private List<BookType> objListTypeOne = new List<BookType>();
        //Define a global book category (level two) List initialization drop-down box
        private List<BookType> objListTypeTwo = new List<BookType>();
        //Define an action identity variable
        private int actionFlag = 0; //2----Add    3----Modify
        //Define a camera operation class
        private Video objVideo = null;

        public frmBookDetail()
        {
            InitializeComponent();

            //Initialize drop-down box data
            LoadDropListInfo();

            //Set BookID to Empty
            lblBookId.Text = string.Empty;
        }
        //Constructing method with Parameters
        public frmBookDetail(int flag, Book objBook) : this()
        {
            //Initialization of local actionFlag 
            actionFlag = flag;
            //More flag uses an impassable initialization
            switch (flag)
            {
                case 1:
                    //View book information only
                    LoadViewForm(objBook);
                    break;
                case 2:
                    //Add book
                    LoadAddForm();
                    break;
                case 3:
                    //Modify book information
                    LoadUpdateForm(objBook);
                    break;
            }
        }

    }
}
