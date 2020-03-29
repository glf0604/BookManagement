namespace BookManagement
{
    partial class frmBorrowBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblCurrentBorrowNum = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dgvBorrowedList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCurrentBorrowList = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnViewAllInfo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lblOverdueNum = new System.Windows.Forms.Label();
            this.lblMemberStatus = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCanBorrowNum = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblBorrowedNum = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblMemberName = new System.Windows.Forms.Label();
            this.lblBorrowTotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbCurrentImage = new System.Windows.Forms.PictureBox();
            this.txtBookISBN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMemberCardId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentBorrowList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(866, 185);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 33);
            this.btnDelete.TabIndex = 135;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // lblCurrentBorrowNum
            // 
            this.lblCurrentBorrowNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCurrentBorrowNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentBorrowNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentBorrowNum.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentBorrowNum.Location = new System.Drawing.Point(658, 187);
            this.lblCurrentBorrowNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentBorrowNum.Name = "lblCurrentBorrowNum";
            this.lblCurrentBorrowNum.Size = new System.Drawing.Size(81, 30);
            this.lblCurrentBorrowNum.TabIndex = 161;
            this.lblCurrentBorrowNum.Text = "0";
            this.lblCurrentBorrowNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(334, 189);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(320, 22);
            this.label14.TabIndex = 160;
            this.label14.Text = "The total number of books borrowed:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label9.Location = new System.Drawing.Point(12, 223);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(190, 24);
            this.label9.TabIndex = 159;
            this.label9.Text = "This book borrowing:";
            // 
            // dgvBorrowedList
            // 
            this.dgvBorrowedList.AllowUserToAddRows = false;
            this.dgvBorrowedList.AllowUserToDeleteRows = false;
            this.dgvBorrowedList.AllowUserToResizeColumns = false;
            this.dgvBorrowedList.AllowUserToResizeRows = false;
            this.dgvBorrowedList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBorrowedList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvBorrowedList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBorrowedList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
            this.dgvBorrowedList.EnableHeadersVisualStyles = false;
            this.dgvBorrowedList.Location = new System.Drawing.Point(8, 493);
            this.dgvBorrowedList.Name = "dgvBorrowedList";
            this.dgvBorrowedList.ReadOnly = true;
            this.dgvBorrowedList.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvBorrowedList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBorrowedList.RowTemplate.Height = 23;
            this.dgvBorrowedList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowedList.Size = new System.Drawing.Size(1132, 163);
            this.dgvBorrowedList.TabIndex = 157;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "ISBN";
            this.dataGridViewTextBoxColumn6.HeaderText = "ISBN";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 220;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "BookId";
            this.dataGridViewTextBoxColumn7.HeaderText = "BookId";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 220;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BookName";
            this.dataGridViewTextBoxColumn8.HeaderText = "BookName";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "BorrowDate";
            this.dataGridViewTextBoxColumn9.HeaderText = "BorrowDate";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.Width = 150;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "LastReturnDate";
            this.dataGridViewTextBoxColumn10.HeaderText = "ReturnDate";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 150;
            // 
            // dgvCurrentBorrowList
            // 
            this.dgvCurrentBorrowList.AllowUserToAddRows = false;
            this.dgvCurrentBorrowList.AllowUserToDeleteRows = false;
            this.dgvCurrentBorrowList.AllowUserToResizeColumns = false;
            this.dgvCurrentBorrowList.AllowUserToResizeRows = false;
            this.dgvCurrentBorrowList.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCurrentBorrowList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCurrentBorrowList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCurrentBorrowList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dgvCurrentBorrowList.EnableHeadersVisualStyles = false;
            this.dgvCurrentBorrowList.Location = new System.Drawing.Point(8, 248);
            this.dgvCurrentBorrowList.Name = "dgvCurrentBorrowList";
            this.dgvCurrentBorrowList.ReadOnly = true;
            this.dgvCurrentBorrowList.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgvCurrentBorrowList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvCurrentBorrowList.RowTemplate.Height = 23;
            this.dgvCurrentBorrowList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCurrentBorrowList.Size = new System.Drawing.Size(1132, 212);
            this.dgvCurrentBorrowList.TabIndex = 133;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ISBN";
            this.dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 220;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BookId";
            this.dataGridViewTextBoxColumn2.HeaderText = "BookId";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 220;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BookName";
            this.dataGridViewTextBoxColumn3.HeaderText = "BookName";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "BorrowDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "BorrowDate";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ReturnDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "ReturnDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCommit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCommit.FlatAppearance.BorderSize = 0;
            this.btnCommit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnCommit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCommit.ForeColor = System.Drawing.Color.White;
            this.btnCommit.Location = new System.Drawing.Point(766, 184);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(82, 33);
            this.btnCommit.TabIndex = 134;
            this.btnCommit.Text = "Submit";
            this.btnCommit.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.label8.Location = new System.Drawing.Point(11, 467);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 24);
            this.label8.TabIndex = 158;
            this.label8.Text = "Borrowed books:";
            // 
            // btnViewAllInfo
            // 
            this.btnViewAllInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnViewAllInfo.FlatAppearance.BorderSize = 0;
            this.btnViewAllInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAllInfo.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnViewAllInfo.ForeColor = System.Drawing.Color.White;
            this.btnViewAllInfo.Location = new System.Drawing.Point(866, 105);
            this.btnViewAllInfo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewAllInfo.Name = "btnViewAllInfo";
            this.btnViewAllInfo.Size = new System.Drawing.Size(82, 30);
            this.btnViewAllInfo.TabIndex = 131;
            this.btnViewAllInfo.Text = "Query All";
            this.btnViewAllInfo.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(3, 159);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(957, 3);
            this.label6.TabIndex = 156;
            // 
            // lblOverdueNum
            // 
            this.lblOverdueNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOverdueNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOverdueNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverdueNum.ForeColor = System.Drawing.Color.Navy;
            this.lblOverdueNum.Location = new System.Drawing.Point(744, 105);
            this.lblOverdueNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverdueNum.Name = "lblOverdueNum";
            this.lblOverdueNum.Size = new System.Drawing.Size(80, 30);
            this.lblOverdueNum.TabIndex = 155;
            this.lblOverdueNum.Text = "0";
            this.lblOverdueNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberStatus
            // 
            this.lblMemberStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberStatus.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberStatus.Location = new System.Drawing.Point(832, 60);
            this.lblMemberStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberStatus.Name = "lblMemberStatus";
            this.lblMemberStatus.Size = new System.Drawing.Size(116, 30);
            this.lblMemberStatus.TabIndex = 154;
            this.lblMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(654, 113);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 22);
            this.label17.TabIndex = 153;
            this.label17.Text = "Overdue:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(747, 64);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 22);
            this.label10.TabIndex = 152;
            this.label10.Text = "Status：";
            // 
            // lblCanBorrowNum
            // 
            this.lblCanBorrowNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCanBorrowNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCanBorrowNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanBorrowNum.ForeColor = System.Drawing.Color.Navy;
            this.lblCanBorrowNum.Location = new System.Drawing.Point(498, 132);
            this.lblCanBorrowNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCanBorrowNum.Name = "lblCanBorrowNum";
            this.lblCanBorrowNum.Size = new System.Drawing.Size(80, 30);
            this.lblCanBorrowNum.TabIndex = 151;
            this.lblCanBorrowNum.Text = "0";
            this.lblCanBorrowNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(445, 93);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 22);
            this.label15.TabIndex = 150;
            this.label15.Text = "Total remaining:";
            // 
            // lblBorrowedNum
            // 
            this.lblBorrowedNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBorrowedNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorrowedNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBorrowedNum.ForeColor = System.Drawing.Color.Navy;
            this.lblBorrowedNum.Location = new System.Drawing.Point(316, 129);
            this.lblBorrowedNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowedNum.Name = "lblBorrowedNum";
            this.lblBorrowedNum.Size = new System.Drawing.Size(81, 30);
            this.lblBorrowedNum.TabIndex = 149;
            this.lblBorrowedNum.Text = "0";
            this.lblBorrowedNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(271, 93);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(143, 22);
            this.label13.TabIndex = 145;
            this.label13.Text = "Total borrowed:";
            // 
            // lblMemberName
            // 
            this.lblMemberName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberName.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberName.Location = new System.Drawing.Point(633, 60);
            this.lblMemberName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(104, 30);
            this.lblMemberName.TabIndex = 148;
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBorrowTotal
            // 
            this.lblBorrowTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBorrowTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorrowTotal.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBorrowTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblBorrowTotal.Location = new System.Drawing.Point(84, 129);
            this.lblBorrowTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowTotal.Name = "lblBorrowTotal";
            this.lblBorrowTotal.Size = new System.Drawing.Size(81, 30);
            this.lblBorrowTotal.TabIndex = 147;
            this.lblBorrowTotal.Text = "0";
            this.lblBorrowTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(549, 64);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 22);
            this.label5.TabIndex = 146;
            this.label5.Text = "Name：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(13, 93);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(225, 22);
            this.label11.TabIndex = 144;
            this.label11.Text = "Total borrowable amount:";
            // 
            // lblMemberId
            // 
            this.lblMemberId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberId.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberId.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberId.Location = new System.Drawing.Point(401, 59);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(131, 31);
            this.lblMemberId.TabIndex = 143;
            this.lblMemberId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(351, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 22);
            this.label4.TabIndex = 142;
            this.label4.Text = "ID:";
            // 
            // pbCurrentImage
            // 
            this.pbCurrentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurrentImage.Location = new System.Drawing.Point(970, 47);
            this.pbCurrentImage.Name = "pbCurrentImage";
            this.pbCurrentImage.Size = new System.Drawing.Size(167, 195);
            this.pbCurrentImage.TabIndex = 141;
            this.pbCurrentImage.TabStop = false;
            // 
            // txtBookISBN
            // 
            this.txtBookISBN.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBookISBN.Location = new System.Drawing.Point(122, 182);
            this.txtBookISBN.Name = "txtBookISBN";
            this.txtBookISBN.Size = new System.Drawing.Size(185, 34);
            this.txtBookISBN.TabIndex = 132;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(12, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 26);
            this.label7.TabIndex = 140;
            this.label7.Text = "ISBN：";
            // 
            // txtMemberCardId
            // 
            this.txtMemberCardId.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemberCardId.Location = new System.Drawing.Point(165, 56);
            this.txtMemberCardId.Name = "txtMemberCardId";
            this.txtMemberCardId.Size = new System.Drawing.Size(159, 34);
            this.txtMemberCardId.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 26);
            this.label3.TabIndex = 139;
            this.label3.Text = "Member Card：";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1144, 3);
            this.label2.TabIndex = 138;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(385, 28);
            this.label1.TabIndex = 137;
            this.label1.Text = "Current Location: Borrowing Books";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1061, 6);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 30);
            this.btnClose.TabIndex = 136;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // frmBorrowBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1150, 662);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lblCurrentBorrowNum);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dgvBorrowedList);
            this.Controls.Add(this.dgvCurrentBorrowList);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnViewAllInfo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblOverdueNum);
            this.Controls.Add(this.lblMemberStatus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lblCanBorrowNum);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.lblBorrowedNum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.lblMemberName);
            this.Controls.Add(this.lblBorrowTotal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pbCurrentImage);
            this.Controls.Add(this.txtBookISBN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMemberCardId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmBorrowBook";
            this.Text = "frmBorrowBook";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowedList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCurrentBorrowList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblCurrentBorrowNum;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dgvBorrowedList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridView dgvCurrentBorrowList;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnViewAllInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblOverdueNum;
        private System.Windows.Forms.Label lblMemberStatus;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblCanBorrowNum;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblBorrowedNum;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblMemberName;
        private System.Windows.Forms.Label lblBorrowTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbCurrentImage;
        private System.Windows.Forms.TextBox txtBookISBN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMemberCardId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
    }
}