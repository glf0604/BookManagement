namespace BookManagement
{
    partial class frmBookType
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBookType));
            this.rtbDESC = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCommit = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTypeName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtParentTypeName = new System.Windows.Forms.TextBox();
            this.txtTypeId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtParentTypeId = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteNode = new System.Windows.Forms.Button();
            this.btnUpdateNode = new System.Windows.Forms.Button();
            this.btnAddSubNode = new System.Windows.Forms.Button();
            this.btnAddRootNode = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gboxNodeDetial = new System.Windows.Forms.GroupBox();
            this.tvBookType = new System.Windows.Forms.TreeView();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gboxNodeDetial.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbDESC
            // 
            this.rtbDESC.Location = new System.Drawing.Point(115, 150);
            this.rtbDESC.Name = "rtbDESC";
            this.rtbDESC.Size = new System.Drawing.Size(374, 89);
            this.rtbDESC.TabIndex = 4;
            this.rtbDESC.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(401, 267);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCommit
            // 
            this.btnCommit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnCommit.FlatAppearance.BorderSize = 0;
            this.btnCommit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCommit.ForeColor = System.Drawing.Color.White;
            this.btnCommit.Location = new System.Drawing.Point(289, 267);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(88, 35);
            this.btnCommit.TabIndex = 5;
            this.btnCommit.Text = "Submit";
            this.btnCommit.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 19);
            this.label7.TabIndex = 2;
            this.label7.Text = "Described：";
            // 
            // txtTypeName
            // 
            this.txtTypeName.Location = new System.Drawing.Point(322, 89);
            this.txtTypeName.Name = "txtTypeName";
            this.txtTypeName.Size = new System.Drawing.Size(167, 26);
            this.txtTypeName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(225, 94);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 19);
            this.label6.TabIndex = 0;
            this.label6.Text = "node Name：";
            // 
            // txtParentTypeName
            // 
            this.txtParentTypeName.Location = new System.Drawing.Point(368, 33);
            this.txtParentTypeName.Name = "txtParentTypeName";
            this.txtParentTypeName.Size = new System.Drawing.Size(121, 26);
            this.txtParentTypeName.TabIndex = 1;
            // 
            // txtTypeId
            // 
            this.txtTypeId.Location = new System.Drawing.Point(115, 90);
            this.txtTypeId.Name = "txtTypeId";
            this.txtTypeId.Size = new System.Drawing.Size(91, 26);
            this.txtTypeId.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(225, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "Parentnode name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 19);
            this.label5.TabIndex = 0;
            this.label5.Text = "node Id：";
            // 
            // txtParentTypeId
            // 
            this.txtParentTypeId.Location = new System.Drawing.Point(128, 33);
            this.txtParentTypeId.Name = "txtParentTypeId";
            this.txtParentTypeId.Size = new System.Drawing.Size(91, 26);
            this.txtParentTypeId.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 0;
            this.label3.Text = "Parent node Id:";
            // 
            // btnDeleteNode
            // 
            this.btnDeleteNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDeleteNode.FlatAppearance.BorderSize = 0;
            this.btnDeleteNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteNode.ForeColor = System.Drawing.Color.White;
            this.btnDeleteNode.Location = new System.Drawing.Point(465, 238);
            this.btnDeleteNode.Name = "btnDeleteNode";
            this.btnDeleteNode.Size = new System.Drawing.Size(124, 35);
            this.btnDeleteNode.TabIndex = 13;
            this.btnDeleteNode.Text = "Delete Node";
            this.btnDeleteNode.UseVisualStyleBackColor = false;
            // 
            // btnUpdateNode
            // 
            this.btnUpdateNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnUpdateNode.FlatAppearance.BorderSize = 0;
            this.btnUpdateNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateNode.ForeColor = System.Drawing.Color.White;
            this.btnUpdateNode.Location = new System.Drawing.Point(465, 180);
            this.btnUpdateNode.Name = "btnUpdateNode";
            this.btnUpdateNode.Size = new System.Drawing.Size(124, 35);
            this.btnUpdateNode.TabIndex = 12;
            this.btnUpdateNode.Text = "Modify Node";
            this.btnUpdateNode.UseVisualStyleBackColor = false;
            // 
            // btnAddSubNode
            // 
            this.btnAddSubNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddSubNode.FlatAppearance.BorderSize = 0;
            this.btnAddSubNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSubNode.ForeColor = System.Drawing.Color.White;
            this.btnAddSubNode.Location = new System.Drawing.Point(465, 122);
            this.btnAddSubNode.Name = "btnAddSubNode";
            this.btnAddSubNode.Size = new System.Drawing.Size(124, 35);
            this.btnAddSubNode.TabIndex = 11;
            this.btnAddSubNode.Text = "Add sub node";
            this.btnAddSubNode.UseVisualStyleBackColor = false;
            // 
            // btnAddRootNode
            // 
            this.btnAddRootNode.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnAddRootNode.FlatAppearance.BorderSize = 0;
            this.btnAddRootNode.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRootNode.ForeColor = System.Drawing.Color.White;
            this.btnAddRootNode.Location = new System.Drawing.Point(465, 65);
            this.btnAddRootNode.Name = "btnAddRootNode";
            this.btnAddRootNode.Size = new System.Drawing.Size(124, 35);
            this.btnAddRootNode.TabIndex = 9;
            this.btnAddRootNode.Text = "Add root node";
            this.btnAddRootNode.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BOOKS01.ICO");
            this.imageList1.Images.SetKeyName(1, "BOOK02.ICO");
            // 
            // gboxNodeDetial
            // 
            this.gboxNodeDetial.Controls.Add(this.rtbDESC);
            this.gboxNodeDetial.Controls.Add(this.btnCancel);
            this.gboxNodeDetial.Controls.Add(this.btnCommit);
            this.gboxNodeDetial.Controls.Add(this.label7);
            this.gboxNodeDetial.Controls.Add(this.txtTypeName);
            this.gboxNodeDetial.Controls.Add(this.label6);
            this.gboxNodeDetial.Controls.Add(this.txtParentTypeName);
            this.gboxNodeDetial.Controls.Add(this.txtTypeId);
            this.gboxNodeDetial.Controls.Add(this.label4);
            this.gboxNodeDetial.Controls.Add(this.label5);
            this.gboxNodeDetial.Controls.Add(this.txtParentTypeId);
            this.gboxNodeDetial.Controls.Add(this.label3);
            this.gboxNodeDetial.Location = new System.Drawing.Point(628, 56);
            this.gboxNodeDetial.Name = "gboxNodeDetial";
            this.gboxNodeDetial.Size = new System.Drawing.Size(510, 325);
            this.gboxNodeDetial.TabIndex = 14;
            this.gboxNodeDetial.TabStop = false;
            this.gboxNodeDetial.Text = "Node Information";
            // 
            // tvBookType
            // 
            this.tvBookType.ImageIndex = 0;
            this.tvBookType.ImageList = this.imageList1;
            this.tvBookType.Location = new System.Drawing.Point(12, 60);
            this.tvBookType.Name = "tvBookType";
            this.tvBookType.SelectedImageIndex = 1;
            this.tvBookType.Size = new System.Drawing.Size(400, 594);
            this.tvBookType.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(1061, 9);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 30);
            this.btnClose.TabIndex = 15;
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
            this.label2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(507, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Current Location: Book Category Management";
            // 
            // frmBookType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(1150, 662);
            this.Controls.Add(this.btnDeleteNode);
            this.Controls.Add(this.btnUpdateNode);
            this.Controls.Add(this.btnAddSubNode);
            this.Controls.Add(this.btnAddRootNode);
            this.Controls.Add(this.gboxNodeDetial);
            this.Controls.Add(this.tvBookType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmBookType";
            this.Text = "frmBookType";
            this.gboxNodeDetial.ResumeLayout(false);
            this.gboxNodeDetial.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbDESC;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCommit;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTypeName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtParentTypeName;
        private System.Windows.Forms.TextBox txtTypeId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtParentTypeId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnDeleteNode;
        private System.Windows.Forms.Button btnUpdateNode;
        private System.Windows.Forms.Button btnAddSubNode;
        private System.Windows.Forms.Button btnAddRootNode;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gboxNodeDetial;
        private System.Windows.Forms.TreeView tvBookType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}