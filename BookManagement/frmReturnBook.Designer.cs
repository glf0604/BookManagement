namespace BookManagement
{
    partial class frmReturnBook
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
            this.btnLost = new System.Windows.Forms.Button();
            this.lblOperatingTime = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblOverdueAmount = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lblBookCompensation = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTotalMoney = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.lblPoundage = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnMoneyDetail = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.lblCurrentReturnBookNumber = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvReturn = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnViewAll = new System.Windows.Forms.Button();
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
            this.pbCurrentImage = new System.Windows.Forms.PictureBox();
            this.txtMemberCardId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.lblMemberId = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtISBN = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLost
            // 
            this.btnLost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnLost.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLost.FlatAppearance.BorderSize = 0;
            this.btnLost.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnLost.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLost.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLost.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLost.ForeColor = System.Drawing.Color.White;
            this.btnLost.Location = new System.Drawing.Point(700, 175);
            this.btnLost.Name = "btnLost";
            this.btnLost.Size = new System.Drawing.Size(78, 33);
            this.btnLost.TabIndex = 173;
            this.btnLost.Text = "Loss";
            this.btnLost.UseVisualStyleBackColor = false;
            this.btnLost.Click += new System.EventHandler(this.btnLost_Click);
            // 
            // lblOperatingTime
            // 
            this.lblOperatingTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOperatingTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOperatingTime.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOperatingTime.ForeColor = System.Drawing.Color.Navy;
            this.lblOperatingTime.Location = new System.Drawing.Point(938, 625);
            this.lblOperatingTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperatingTime.Name = "lblOperatingTime";
            this.lblOperatingTime.Size = new System.Drawing.Size(199, 30);
            this.lblOperatingTime.TabIndex = 211;
            this.lblOperatingTime.Text = "2019/12/20 11:01:01";
            this.lblOperatingTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(848, 628);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(66, 22);
            this.label24.TabIndex = 210;
            this.label24.Text = "Time：";
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblUserName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblUserName.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblUserName.ForeColor = System.Drawing.Color.Navy;
            this.lblUserName.Location = new System.Drawing.Point(719, 625);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(111, 30);
            this.lblUserName.TabIndex = 209;
            this.lblUserName.Text = "Wang";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(642, 629);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(66, 17);
            this.label22.TabIndex = 208;
            this.label22.Text = "Operator:";
            // 
            // lblOverdueAmount
            // 
            this.lblOverdueAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOverdueAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOverdueAmount.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverdueAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblOverdueAmount.Location = new System.Drawing.Point(336, 228);
            this.lblOverdueAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverdueAmount.Name = "lblOverdueAmount";
            this.lblOverdueAmount.Size = new System.Drawing.Size(81, 30);
            this.lblOverdueAmount.TabIndex = 207;
            this.lblOverdueAmount.Text = "0.00";
            this.lblOverdueAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(232, 231);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 22);
            this.label20.TabIndex = 206;
            this.label20.Text = "Late Fee：";
            // 
            // lblBookCompensation
            // 
            this.lblBookCompensation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBookCompensation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBookCompensation.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBookCompensation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblBookCompensation.Location = new System.Drawing.Point(126, 228);
            this.lblBookCompensation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBookCompensation.Name = "lblBookCompensation";
            this.lblBookCompensation.Size = new System.Drawing.Size(93, 30);
            this.lblBookCompensation.TabIndex = 203;
            this.lblBookCompensation.Text = "0.00";
            this.lblBookCompensation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(11, 232);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 22);
            this.label16.TabIndex = 202;
            this.label16.Text = "Compensa：";
            // 
            // lblTotalMoney
            // 
            this.lblTotalMoney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblTotalMoney.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblTotalMoney.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTotalMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTotalMoney.Location = new System.Drawing.Point(719, 226);
            this.lblTotalMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalMoney.Name = "lblTotalMoney";
            this.lblTotalMoney.Size = new System.Drawing.Size(150, 30);
            this.lblTotalMoney.TabIndex = 205;
            this.lblTotalMoney.Text = "0.00";
            this.lblTotalMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(625, 231);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(68, 22);
            this.label25.TabIndex = 201;
            this.label25.Text = "Total：";
            // 
            // lblPoundage
            // 
            this.lblPoundage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblPoundage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPoundage.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPoundage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblPoundage.Location = new System.Drawing.Point(507, 226);
            this.lblPoundage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPoundage.Name = "lblPoundage";
            this.lblPoundage.Size = new System.Drawing.Size(93, 30);
            this.lblPoundage.TabIndex = 204;
            this.lblPoundage.Text = "0.00";
            this.lblPoundage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(429, 232);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 22);
            this.label9.TabIndex = 200;
            this.label9.Text = "Service:";
            // 
            // btnMoneyDetail
            // 
            this.btnMoneyDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnMoneyDetail.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnMoneyDetail.FlatAppearance.BorderSize = 0;
            this.btnMoneyDetail.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnMoneyDetail.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnMoneyDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMoneyDetail.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnMoneyDetail.ForeColor = System.Drawing.Color.White;
            this.btnMoneyDetail.Location = new System.Drawing.Point(787, 175);
            this.btnMoneyDetail.Name = "btnMoneyDetail";
            this.btnMoneyDetail.Size = new System.Drawing.Size(78, 33);
            this.btnMoneyDetail.TabIndex = 174;
            this.btnMoneyDetail.Text = "Fee";
            this.btnMoneyDetail.UseVisualStyleBackColor = false;
            this.btnMoneyDetail.Click += new System.EventHandler(this.btnMoneyDetail_Click);
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
            this.btnCommit.Location = new System.Drawing.Point(874, 175);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(82, 33);
            this.btnCommit.TabIndex = 175;
            this.btnCommit.Text = "SReturn";
            this.btnCommit.UseVisualStyleBackColor = false;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // lblCurrentReturnBookNumber
            // 
            this.lblCurrentReturnBookNumber.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCurrentReturnBookNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCurrentReturnBookNumber.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCurrentReturnBookNumber.ForeColor = System.Drawing.Color.Navy;
            this.lblCurrentReturnBookNumber.Location = new System.Drawing.Point(477, 179);
            this.lblCurrentReturnBookNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentReturnBookNumber.Name = "lblCurrentReturnBookNumber";
            this.lblCurrentReturnBookNumber.Size = new System.Drawing.Size(81, 30);
            this.lblCurrentReturnBookNumber.TabIndex = 199;
            this.lblCurrentReturnBookNumber.Text = "0";
            this.lblCurrentReturnBookNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(362, 183);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 22);
            this.label14.TabIndex = 198;
            this.label14.Text = "Return：";
            // 
            // dgvReturn
            // 
            this.dgvReturn.AllowUserToAddRows = false;
            this.dgvReturn.AllowUserToDeleteRows = false;
            this.dgvReturn.AllowUserToResizeColumns = false;
            this.dgvReturn.AllowUserToResizeRows = false;
            this.dgvReturn.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReturn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReturn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReturn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn5,
            this.Column1,
            this.Column4,
            this.Column3,
            this.Column5});
            this.dgvReturn.EnableHeadersVisualStyles = false;
            this.dgvReturn.Location = new System.Drawing.Point(12, 261);
            this.dgvReturn.Name = "dgvReturn";
            this.dgvReturn.ReadOnly = true;
            this.dgvReturn.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgvReturn.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReturn.RowTemplate.Height = 23;
            this.dgvReturn.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReturn.Size = new System.Drawing.Size(1126, 353);
            this.dgvReturn.TabIndex = 176;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ISBN";
            this.dataGridViewTextBoxColumn1.HeaderText = "ISBN";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "BookId";
            this.Column2.HeaderText = "BooId";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "BookName";
            this.dataGridViewTextBoxColumn3.HeaderText = "Book Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "LastReturnDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "LastReturnDate";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 150;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IsOverdue";
            this.Column1.FalseValue = "false";
            this.Column1.HeaderText = "IsOverdue";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column1.TrueValue = "true";
            // 
            // Column4
            // 
            this.Column4.FalseValue = "false";
            this.Column4.HeaderText = "IsLoss";
            this.Column4.IndeterminateValue = "false";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column4.TrueValue = "true";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Payment";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "This submission";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // btnViewAll
            // 
            this.btnViewAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnViewAll.FlatAppearance.BorderSize = 0;
            this.btnViewAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAll.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnViewAll.ForeColor = System.Drawing.Color.White;
            this.btnViewAll.Location = new System.Drawing.Point(874, 107);
            this.btnViewAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnViewAll.Name = "btnViewAll";
            this.btnViewAll.Size = new System.Drawing.Size(82, 33);
            this.btnViewAll.TabIndex = 171;
            this.btnViewAll.Text = "Query All";
            this.btnViewAll.UseVisualStyleBackColor = false;
            this.btnViewAll.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(3, 160);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(960, 3);
            this.label6.TabIndex = 197;
            // 
            // lblOverdueNum
            // 
            this.lblOverdueNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblOverdueNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblOverdueNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOverdueNum.ForeColor = System.Drawing.Color.Navy;
            this.lblOverdueNum.Location = new System.Drawing.Point(719, 107);
            this.lblOverdueNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOverdueNum.Name = "lblOverdueNum";
            this.lblOverdueNum.Size = new System.Drawing.Size(80, 33);
            this.lblOverdueNum.TabIndex = 196;
            this.lblOverdueNum.Text = "0";
            this.lblOverdueNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMemberStatus
            // 
            this.lblMemberStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberStatus.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberStatus.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberStatus.Location = new System.Drawing.Point(840, 61);
            this.lblMemberStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberStatus.Name = "lblMemberStatus";
            this.lblMemberStatus.Size = new System.Drawing.Size(116, 30);
            this.lblMemberStatus.TabIndex = 195;
            this.lblMemberStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(625, 112);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(94, 22);
            this.label17.TabIndex = 194;
            this.label17.Text = "Overdue：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(755, 65);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 22);
            this.label10.TabIndex = 193;
            this.label10.Text = "Status：";
            // 
            // lblCanBorrowNum
            // 
            this.lblCanBorrowNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblCanBorrowNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCanBorrowNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCanBorrowNum.ForeColor = System.Drawing.Color.Navy;
            this.lblCanBorrowNum.Location = new System.Drawing.Point(520, 109);
            this.lblCanBorrowNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCanBorrowNum.Name = "lblCanBorrowNum";
            this.lblCanBorrowNum.Size = new System.Drawing.Size(80, 33);
            this.lblCanBorrowNum.TabIndex = 192;
            this.lblCanBorrowNum.Text = "0";
            this.lblCanBorrowNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(427, 114);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 22);
            this.label15.TabIndex = 191;
            this.label15.Text = "Surplus：";
            // 
            // lblBorrowedNum
            // 
            this.lblBorrowedNum.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBorrowedNum.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorrowedNum.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBorrowedNum.ForeColor = System.Drawing.Color.Navy;
            this.lblBorrowedNum.Location = new System.Drawing.Point(320, 110);
            this.lblBorrowedNum.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowedNum.Name = "lblBorrowedNum";
            this.lblBorrowedNum.Size = new System.Drawing.Size(81, 33);
            this.lblBorrowedNum.TabIndex = 190;
            this.lblBorrowedNum.Text = "0";
            this.lblBorrowedNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(222, 114);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 22);
            this.label13.TabIndex = 186;
            this.label13.Text = "Borrowed：";
            // 
            // lblMemberName
            // 
            this.lblMemberName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberName.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberName.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberName.Location = new System.Drawing.Point(631, 61);
            this.lblMemberName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMemberName.Name = "lblMemberName";
            this.lblMemberName.Size = new System.Drawing.Size(104, 30);
            this.lblMemberName.TabIndex = 189;
            this.lblMemberName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblBorrowTotal
            // 
            this.lblBorrowTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblBorrowTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblBorrowTotal.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBorrowTotal.ForeColor = System.Drawing.Color.Navy;
            this.lblBorrowTotal.Location = new System.Drawing.Point(120, 110);
            this.lblBorrowTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBorrowTotal.Name = "lblBorrowTotal";
            this.lblBorrowTotal.Size = new System.Drawing.Size(81, 33);
            this.lblBorrowTotal.TabIndex = 188;
            this.lblBorrowTotal.Text = "0";
            this.lblBorrowTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(547, 65);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 22);
            this.label5.TabIndex = 187;
            this.label5.Text = "Name ：";
            // 
            // pbCurrentImage
            // 
            this.pbCurrentImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbCurrentImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbCurrentImage.Location = new System.Drawing.Point(964, 48);
            this.pbCurrentImage.Name = "pbCurrentImage";
            this.pbCurrentImage.Size = new System.Drawing.Size(173, 207);
            this.pbCurrentImage.TabIndex = 182;
            this.pbCurrentImage.TabStop = false;
            // 
            // txtMemberCardId
            // 
            this.txtMemberCardId.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtMemberCardId.Location = new System.Drawing.Point(122, 57);
            this.txtMemberCardId.Name = "txtMemberCardId";
            this.txtMemberCardId.Size = new System.Drawing.Size(185, 34);
            this.txtMemberCardId.TabIndex = 170;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(27, 114);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 22);
            this.label11.TabIndex = 185;
            this.label11.Text = "Borrow：";
            // 
            // lblMemberId
            // 
            this.lblMemberId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblMemberId.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMemberId.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblMemberId.ForeColor = System.Drawing.Color.Navy;
            this.lblMemberId.Location = new System.Drawing.Point(401, 60);
            this.lblMemberId.Name = "lblMemberId";
            this.lblMemberId.Size = new System.Drawing.Size(131, 31);
            this.lblMemberId.TabIndex = 184;
            this.lblMemberId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(321, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 22);
            this.label4.TabIndex = 183;
            this.label4.Text = "MemID:";
            // 
            // txtISBN
            // 
            this.txtISBN.Font = new System.Drawing.Font("Microsoft YaHei", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtISBN.Location = new System.Drawing.Point(120, 177);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new System.Drawing.Size(185, 34);
            this.txtISBN.TabIndex = 172;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(8, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 26);
            this.label7.TabIndex = 181;
            this.label7.Text = "ISBN：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 26);
            this.label3.TabIndex = 180;
            this.label3.Text = "MemCard：";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1061, 7);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 30);
            this.btnClose.TabIndex = 177;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1144, 3);
            this.label2.TabIndex = 179;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(346, 28);
            this.label1.TabIndex = 178;
            this.label1.Text = "Current Location: Return Books";
            // 
            // frmReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1150, 662);
            this.Controls.Add(this.btnLost);
            this.Controls.Add(this.lblOperatingTime);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblOverdueAmount);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.lblBookCompensation);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.lblTotalMoney);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.lblPoundage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnMoneyDetail);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.lblCurrentReturnBookNumber);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvReturn);
            this.Controls.Add(this.btnViewAll);
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
            this.Controls.Add(this.pbCurrentImage);
            this.Controls.Add(this.txtMemberCardId);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblMemberId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReturnBook";
            this.Text = "frmReturnBook";
            ((System.ComponentModel.ISupportInitialize)(this.dgvReturn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCurrentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLost;
        private System.Windows.Forms.Label lblOperatingTime;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblOverdueAmount;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label lblBookCompensation;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTotalMoney;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblPoundage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnMoneyDetail;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label lblCurrentReturnBookNumber;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvReturn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column5;
        private System.Windows.Forms.Button btnViewAll;
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
        private System.Windows.Forms.PictureBox pbCurrentImage;
        private System.Windows.Forms.TextBox txtMemberCardId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblMemberId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtISBN;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}