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
        //=================================Control events=====================================
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //Trigger event when selecting a drop-down box
        private void cboBookTypeOne_SelectedValueChanged(object sender, EventArgs e)
        {
            //Determine if the options in the correct selection
            if (cboBookTypeOne.SelectedValue == null) return;
            else if (!ValidateInput.IsInteger(cboBookTypeOne.SelectedValue.ToString())) return;
            else
            {
                //Determine if there are no level two options, if any, enable, load data in the database, no, remain disabled
                if (objBookTypeServices.IsExistSubType(Convert.ToInt32(cboBookTypeOne.SelectedValue.ToString())))
                {
                    //Enable subclass drop-down box
                    cboBookTypeTwo.Enabled = true;
                    //Load
                    LoadSubTypeInfo(Convert.ToInt32(cboBookTypeOne.SelectedValue.ToString()));
                }
                else
                {
                    //Disable Subclass drop-down box
                    cboBookTypeTwo.Enabled = false;
                    cboBookTypeTwo.Text = "No secondary class";
                }
                //Generate numbers
                lblBookId.Text = objBookServices.BuildNewBookId(Convert.ToInt32(cboBookTypeOne.SelectedValue.ToString()));
            }



        }

        private void cboBookTypeTwo_SelectedValueChanged(object sender, EventArgs e)
        {
            //Determine if the options in the correct selection
            if (cboBookTypeTwo.SelectedValue == null) return;
            else if (!ValidateInput.IsInteger(cboBookTypeTwo.SelectedValue.ToString())) return;
            else
            {
                //Generate numbers！
                lblBookId.Text = objBookServices.BuildNewBookId(Convert.ToInt32(cboBookTypeTwo.SelectedValue.ToString()));
            }

        }

        private void btnCommit_Click(object sender, EventArgs e)
        {

            //【1】 Input for validation 

            //【2】 encapsulation 
            Book objBook = new Book()
            {
                BookId = lblBookId.Text,
                BookName = txtBookName.Text.Trim(),
                BookType = cboBookTypeTwo.Enabled == true ? Convert.ToInt32(cboBookTypeTwo.SelectedValue.ToString()) : Convert.ToInt32(cboBookTypeOne.SelectedValue),
                ISBN = txtBookISBN.Text,
                BookAuthor = txtBookAuthor.Text.Trim(),
                BookPrice = Convert.ToDouble(txtBookPrice.Text.Trim()),
                BookPress = Convert.ToInt32(cboBookPress.SelectedValue),
                BookPublishDate = Convert.ToDateTime(dtpPublishDate.Text),
                StorageInNum = Convert.ToInt32(txtStorageInNum.Text.Trim()),
                InventoryNum = Convert.ToInt32(lblInventoryNum.Text.Trim()),
                BorrowedNum = Convert.ToInt32(lblBorrowedNum.Text.Trim()),
                StorageInDate = Convert.ToDateTime(lblStorageInDate.Text),
            };
            ///Picture--> text
            if (pbCurrentImage.BackgroundImage == null) objBook.BookImage = null;
            else objBook.BookImage = new Common.SerializeObjectToString().SerializeObject(pbCurrentImage.BackgroundImage);



            //Perform 
            switch (actionFlag)
            {
                case 2:
                    try
                    {
                        if (objBookServices.AddBook(objBook) == 1)
                        {
                            //Prompt for Success！
                            MessageBox.Show("Successful addition of book information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close a form
                            Close();
                            //Return ok 
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error adding book information! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                case 3:
                    try
                    {
                        if (objBookServices.UpdateBook(objBook) == 1)
                        {
                            //Notice Successful！
                            MessageBox.Show("Successful revision of book information!", "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Close From
                            Close();
                            //Return OK 
                            this.DialogResult = DialogResult.OK;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in revising book information! Specific errors:" + ex.Message, "System Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }
        private void txtStorageInNum_TextChanged(object sender, EventArgs e)
        {
            lblInventoryNum.Text = txtStorageInNum.Text;
            lblBorrowedNum.Text = "0";
            lblStorageInDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private void frmBookDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmBorrowBook.objFrmBookDetail = null;
            frmReturnBook.objFrmBookDetail = null;
        }
        #region Processing of book pictures (select pictures, take photos via camera)
        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            //Instantiate Open File dialog box
            OpenFileDialog objOpenFile = new OpenFileDialog();
            //Setting File types
            objOpenFile.Filter = "Picture files|*.jpg;*.png;*.bmp";
            //If you select a good file, show
            if (objOpenFile.ShowDialog() == DialogResult.OK)
            {
                pbCurrentImage.BackgroundImage = Image.FromFile(objOpenFile.FileName);
            }
        }
        private void btnClearPhoto_Click(object sender, EventArgs e)
        {
            pbCurrentImage.BackgroundImage = null;
        }

        private void btnStartCamera_Click(object sender, EventArgs e)
        {
            //Start camera: Instantiate a camera Operation class
            try
            {
                objVideo = new Video(pbImage.Handle, pbImage.Left, pbImage.Top, pbImage.Width, (short)pbImage.Height);
                objVideo.OpenVideo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to call camera! Specific reasons:" + ex.Message, "System Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void btnCloseCamera_Click(object sender, EventArgs e)
        {
            objVideo.CloseVideo();
        }

        private void btnStartPhoto_Click(object sender, EventArgs e)
        {
            pbCurrentImage.BackgroundImage = objVideo.CatchVideo();
        }
        #endregion

        //=================================Custom Methods=====================================

        private void LoadViewForm(Book objBook)
        {
            //Modify Form Title Name
            lblTitle.Text = "【View Book Information】";

            //隐藏控件 
            pbImage.Visible = false;
            btnSelectPhoto.Visible = false;
            btnClearPhoto.Visible = false;
            btnStartCamera.Visible = false;
            btnCloseCamera.Visible = false;
            btnStartPhoto.Visible = false;
            btnCommit.Visible = false;
            //Assign a value
            //=======Book Type
            string[] typeName = objBookTypeServices.GetTypeNameById(objBook.BookType);
            if (typeName[0].Contains("All"))
            {
                cboBookTypeOne.Text = typeName[1];
                cboBookTypeTwo.Text = string.Empty;
            }
            else
            {
                cboBookTypeOne.Text = typeName[0];
                cboBookTypeTwo.Text = typeName[1];
            }

            lblBookId.Text = objBook.BookId.ToString();
            txtBookName.Text = objBook.BookName;
            txtBookISBN.Text = objBook.ISBN;
            txtBookAuthor.Text = objBook.BookAuthor;
            txtBookPrice.Text = objBook.BookPrice.ToString();
            cboBookPress.Text = objBookPressServices.GetPressNameById(objBook.BookPress);
            dtpPublishDate.Text = objBook.BookPublishDate.ToString();
            txtStorageInNum.Text = objBook.StorageInNum.ToString();
            lblInventoryNum.Text = objBook.InventoryNum.ToString();
            lblBorrowedNum.Text = objBook.BorrowedNum.ToString();
            lblStorageInDate.Text = objBook.StorageInDate.ToString();
            //Turn the text into a diagram
            if (string.IsNullOrWhiteSpace(objBook.BookImage)) pbCurrentImage.BackgroundImage = null;
            else pbCurrentImage.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objBook.BookImage);

            //Disable input
            cboBookTypeOne.Enabled = false;
            cboBookTypeTwo.Enabled = false;
            txtBookISBN.Enabled = false;
            txtBookName.Enabled = false;
            txtBookAuthor.Enabled = false;
            txtBookPrice.Enabled = false;
            cboBookPress.Enabled = false;
            dtpPublishDate.Enabled = false;
            txtStorageInNum.Enabled = false;


            //Modify the text of a button
            btnClose.Text = "Close";



        }
        private void LoadAddForm()
        {
            //Modify Form Title Name
            lblTitle.Text = "【Adding Book Information】";

            //Modify button Name
            btnClose.Text = "Cancel and close";

        }
        private void LoadUpdateForm(Book objBook)
        {
            //Modify Form Title Name
            lblTitle.Text = "【Modify Book Information】";


            //Assign a value
            //=======Book Type
            string[] typeName = objBookTypeServices.GetTypeNameById(objBook.BookType);
            if (typeName[0].Contains("All"))
            {
                cboBookTypeOne.Text = typeName[1];
                cboBookTypeTwo.Text = string.Empty;
            }
            else
            {
                cboBookTypeOne.Text = typeName[0];
                cboBookTypeTwo.Text = typeName[1];
            }

            lblBookId.Text = objBook.BookId.ToString();
            txtBookName.Text = objBook.BookName;
            txtBookISBN.Text = objBook.ISBN;
            txtBookAuthor.Text = objBook.BookAuthor;
            txtBookPrice.Text = objBook.BookPrice.ToString();
            cboBookPress.Text = objBookPressServices.GetPressNameById(objBook.BookPress);
            dtpPublishDate.Text = objBook.BookPublishDate.ToString();
            txtStorageInNum.Text = objBook.StorageInNum.ToString();
            lblInventoryNum.Text = objBook.InventoryNum.ToString();
            lblBorrowedNum.Text = objBook.BorrowedNum.ToString();
            lblStorageInDate.Text = objBook.StorageInDate.ToString();
            //Turn the text into a diagram
            if (string.IsNullOrWhiteSpace(objBook.BookImage)) pbCurrentImage.BackgroundImage = null;
            else pbCurrentImage.BackgroundImage = (Image)new Common.SerializeObjectToString().DeserializeObject(objBook.BookImage);

            //Disable Book Type
            cboBookTypeOne.Enabled = false;
            cboBookTypeTwo.Enabled = false;
            txtStorageInNum.Enabled = false;

            //Modify button Name
            btnClose.Text = "Cancel and close";


        }
        private void LoadDropListInfo()
        {
            //Get the following box information (Press)
            try
            {
                objListPress = objBookPressServices.GetPressList();
                objListTypeOne = objBookTypeServices.GetBookTypeList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to get drop-down data! Specific reasons:" + ex.Message, "System message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Binding Publishing House

            cboBookPress.DataSource = objListPress;
            cboBookPress.DisplayMember = "PressName";
            cboBookPress.ValueMember = "PressId";

            cboBookPress.SelectedIndex = -1;
            cboBookPress.Text = "Please choose the publishing house.";

            cboBookPress.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboBookPress.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //First level classification of bound books
            cboBookTypeOne.DataSource = objListTypeOne;
            cboBookTypeOne.DisplayMember = "TypeName";
            cboBookTypeOne.ValueMember = "TypeId";

            cboBookTypeOne.SelectedIndex = -1;
            cboBookTypeOne.Text = "Please select the book category.";

            cboBookTypeOne.AutoCompleteSource = AutoCompleteSource.ListItems;
            cboBookTypeOne.AutoCompleteMode = AutoCompleteMode.SuggestAppend;

            //Initialize level two Class
            cboBookTypeTwo.Text = "Selection of secondary classes";
            cboBookTypeTwo.Enabled = false;

        }
    }
}
