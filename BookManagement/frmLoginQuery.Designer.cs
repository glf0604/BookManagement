namespace BookManagement
{
    partial class frmLoginQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.rbStartEnd = new System.Windows.Forms.RadioButton();
            this.rbYear = new System.Windows.Forms.RadioButton();
            this.rbMonth = new System.Windows.Forms.RadioButton();
            this.rbWeek = new System.Windows.Forms.RadioButton();
            this.rbToday = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLoginLogs = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAll = new System.Windows.Forms.Button();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtLoginId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginLogs)).BeginInit();
            this.SuspendLayout();
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.DataPropertyName = "ExitTime";
            this.Column5.HeaderText = "Exit Time";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 220;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column3.DataPropertyName = "LoginComputer";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle4;
            this.Column3.HeaderText = "Login Computer";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UserName";
            this.Column2.HeaderText = "Username";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 180;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(665, 105);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 19);
            this.label7.TabIndex = 73;
            this.label7.Text = "To";
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnd.Location = new System.Drawing.Point(698, 99);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(117, 26);
            this.dtpEnd.TabIndex = 63;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStart.Location = new System.Drawing.Point(523, 99);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(117, 26);
            this.dtpStart.TabIndex = 62;
            // 
            // rbStartEnd
            // 
            this.rbStartEnd.AutoSize = true;
            this.rbStartEnd.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbStartEnd.Location = new System.Drawing.Point(453, 101);
            this.rbStartEnd.Name = "rbStartEnd";
            this.rbStartEnd.Size = new System.Drawing.Size(64, 23);
            this.rbStartEnd.TabIndex = 61;
            this.rbStartEnd.Text = "Form";
            this.rbStartEnd.UseVisualStyleBackColor = true;
            // 
            // rbYear
            // 
            this.rbYear.AutoSize = true;
            this.rbYear.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbYear.Location = new System.Drawing.Point(366, 101);
            this.rbYear.Name = "rbYear";
            this.rbYear.Size = new System.Drawing.Size(58, 23);
            this.rbYear.TabIndex = 60;
            this.rbYear.Text = "Year";
            this.rbYear.UseVisualStyleBackColor = true;
            // 
            // rbMonth
            // 
            this.rbMonth.AutoSize = true;
            this.rbMonth.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbMonth.Location = new System.Drawing.Point(294, 101);
            this.rbMonth.Name = "rbMonth";
            this.rbMonth.Size = new System.Drawing.Size(74, 23);
            this.rbMonth.TabIndex = 59;
            this.rbMonth.Text = "Month";
            this.rbMonth.UseVisualStyleBackColor = true;
            // 
            // rbWeek
            // 
            this.rbWeek.AutoSize = true;
            this.rbWeek.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbWeek.Location = new System.Drawing.Point(221, 101);
            this.rbWeek.Name = "rbWeek";
            this.rbWeek.Size = new System.Drawing.Size(66, 23);
            this.rbWeek.TabIndex = 58;
            this.rbWeek.Text = "Week";
            this.rbWeek.UseVisualStyleBackColor = true;
            // 
            // rbToday
            // 
            this.rbToday.AutoSize = true;
            this.rbToday.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbToday.Location = new System.Drawing.Point(150, 100);
            this.rbToday.Name = "rbToday";
            this.rbToday.Size = new System.Drawing.Size(70, 23);
            this.rbToday.TabIndex = 57;
            this.rbToday.Text = "Today";
            this.rbToday.UseVisualStyleBackColor = true;
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbAll.Location = new System.Drawing.Point(101, 101);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(46, 23);
            this.rbAll.TabIndex = 56;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "LoginId";
            this.Column1.HeaderText = "LoginId";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 180;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "LogId";
            this.Column8.HeaderText = "LogId";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // dgvLoginLogs
            // 
            this.dgvLoginLogs.AllowUserToAddRows = false;
            this.dgvLoginLogs.AllowUserToDeleteRows = false;
            this.dgvLoginLogs.AllowUserToResizeColumns = false;
            this.dgvLoginLogs.AllowUserToResizeRows = false;
            this.dgvLoginLogs.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.HotTrack;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLoginLogs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvLoginLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoginLogs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvLoginLogs.EnableHeadersVisualStyles = false;
            this.dgvLoginLogs.Location = new System.Drawing.Point(11, 143);
            this.dgvLoginLogs.Name = "dgvLoginLogs";
            this.dgvLoginLogs.ReadOnly = true;
            this.dgvLoginLogs.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Navy;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Green;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            this.dgvLoginLogs.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvLoginLogs.RowTemplate.Height = 23;
            this.dgvLoginLogs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoginLogs.Size = new System.Drawing.Size(1126, 511);
            this.dgvLoginLogs.TabIndex = 66;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "LoginTime";
            this.Column4.HeaderText = "Login Time";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 220;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.Location = new System.Drawing.Point(1061, 95);
            this.btnAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(76, 30);
            this.btnAll.TabIndex = 65;
            this.btnAll.Text = "ALL";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnQuery
            // 
            this.btnQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnQuery.FlatAppearance.BorderSize = 0;
            this.btnQuery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuery.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnQuery.ForeColor = System.Drawing.Color.White;
            this.btnQuery.Location = new System.Drawing.Point(1061, 55);
            this.btnQuery.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(76, 30);
            this.btnQuery.TabIndex = 64;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = false;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(44, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 19);
            this.label6.TabIndex = 72;
            this.label6.Text = "Time：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(303, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 19);
            this.label5.TabIndex = 71;
            this.label5.Text = "Name：";
            // 
            // txtLoginId
            // 
            this.txtLoginId.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtLoginId.Location = new System.Drawing.Point(125, 60);
            this.txtLoginId.Name = "txtLoginId";
            this.txtLoginId.Size = new System.Drawing.Size(162, 26);
            this.txtLoginId.TabIndex = 54;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(16, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 19);
            this.label4.TabIndex = 70;
            this.label4.Text = "MemberIID：";
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUserName.Location = new System.Drawing.Point(374, 60);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(162, 26);
            this.txtUserName.TabIndex = 55;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1061, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 30);
            this.btnClose.TabIndex = 67;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(3, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1144, 3);
            this.label2.TabIndex = 69;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(384, 28);
            this.label1.TabIndex = 68;
            this.label1.Text = "Current Location: Logon Log Query";
            // 
            // frmLoginQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1150, 662);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.rbStartEnd);
            this.Controls.Add(this.rbYear);
            this.Controls.Add(this.rbMonth);
            this.Controls.Add(this.rbWeek);
            this.Controls.Add(this.rbToday);
            this.Controls.Add(this.rbAll);
            this.Controls.Add(this.dgvLoginLogs);
            this.Controls.Add(this.btnAll);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtLoginId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLoginQuery";
            this.Text = "frmLoginQuery";
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoginLogs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.RadioButton rbStartEnd;
        private System.Windows.Forms.RadioButton rbYear;
        private System.Windows.Forms.RadioButton rbMonth;
        private System.Windows.Forms.RadioButton rbWeek;
        private System.Windows.Forms.RadioButton rbToday;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridView dgvLoginLogs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtLoginId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}