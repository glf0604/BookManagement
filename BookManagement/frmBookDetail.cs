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
    }
}