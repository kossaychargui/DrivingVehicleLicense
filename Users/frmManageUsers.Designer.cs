namespace Course19DVLDProject.Users
{
    partial class frmManageUsers
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAddNewUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEditUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteUser = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.btnAddUser = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.cbIsActive = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(336, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manager Users";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 306);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(891, 187);
            this.dataGridView1.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItemAddNewUser,
            this.toolStripMenuItemEditUser,
            this.toolStripMenuItemDeleteUser,
            this.toolStripMenuItemChangePassword,
            this.toolStripSeparator2,
            this.toolStripMenuItemSendEmail,
            this.toolStripMenuItemPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(198, 198);
            // 
            // toolStripMenuItemShowDetails
            // 
            this.toolStripMenuItemShowDetails.Image = global::Course19DVLDProject.Properties.Resources.person_Details;
            this.toolStripMenuItemShowDetails.Name = "toolStripMenuItemShowDetails";
            this.toolStripMenuItemShowDetails.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemShowDetails.Text = "Show Details";
            this.toolStripMenuItemShowDetails.Click += new System.EventHandler(this.toolStripMenuItemShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemAddNewUser
            // 
            this.toolStripMenuItemAddNewUser.Image = global::Course19DVLDProject.Properties.Resources.add_user;
            this.toolStripMenuItemAddNewUser.Name = "toolStripMenuItemAddNewUser";
            this.toolStripMenuItemAddNewUser.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemAddNewUser.Text = "Add New User";
            this.toolStripMenuItemAddNewUser.Click += new System.EventHandler(this.toolStripMenuItemAddNewUser_Click);
            // 
            // toolStripMenuItemEditUser
            // 
            this.toolStripMenuItemEditUser.Image = global::Course19DVLDProject.Properties.Resources.edit_person;
            this.toolStripMenuItemEditUser.Name = "toolStripMenuItemEditUser";
            this.toolStripMenuItemEditUser.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemEditUser.Text = "Edit";
            this.toolStripMenuItemEditUser.Click += new System.EventHandler(this.toolStripMenuItemEditUser_Click);
            // 
            // toolStripMenuItemDeleteUser
            // 
            this.toolStripMenuItemDeleteUser.Image = global::Course19DVLDProject.Properties.Resources.delete_person;
            this.toolStripMenuItemDeleteUser.Name = "toolStripMenuItemDeleteUser";
            this.toolStripMenuItemDeleteUser.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemDeleteUser.Text = "Delete";
            this.toolStripMenuItemDeleteUser.Click += new System.EventHandler(this.toolStripMenuItemDeleteUser_Click);
            // 
            // toolStripMenuItemChangePassword
            // 
            this.toolStripMenuItemChangePassword.Image = global::Course19DVLDProject.Properties.Resources.password;
            this.toolStripMenuItemChangePassword.Name = "toolStripMenuItemChangePassword";
            this.toolStripMenuItemChangePassword.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemChangePassword.Text = "Change Password";
            this.toolStripMenuItemChangePassword.Click += new System.EventHandler(this.toolStripMenuItemChangePassword_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(194, 6);
            // 
            // toolStripMenuItemSendEmail
            // 
            this.toolStripMenuItemSendEmail.Image = global::Course19DVLDProject.Properties.Resources.email;
            this.toolStripMenuItemSendEmail.Name = "toolStripMenuItemSendEmail";
            this.toolStripMenuItemSendEmail.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemSendEmail.Text = "Send Email";
            this.toolStripMenuItemSendEmail.Click += new System.EventHandler(this.toolStripMenuItemSendEmail_Click);
            // 
            // toolStripMenuItemPhoneCall
            // 
            this.toolStripMenuItemPhoneCall.Image = global::Course19DVLDProject.Properties.Resources.clamshell_phone;
            this.toolStripMenuItemPhoneCall.Name = "toolStripMenuItemPhoneCall";
            this.toolStripMenuItemPhoneCall.Size = new System.Drawing.Size(197, 26);
            this.toolStripMenuItemPhoneCall.Text = "Phone Call";
            this.toolStripMenuItemPhoneCall.Click += new System.EventHandler(this.toolStripMenuItemPhoneCall_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 277);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filter By :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "UserID",
            "UserName",
            "FullName",
            "IsActive"});
            this.cbFilterBy.Location = new System.Drawing.Point(98, 276);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(173, 24);
            this.cbFilterBy.TabIndex = 4;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilterBy.Location = new System.Drawing.Point(277, 278);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(186, 22);
            this.tbFilterBy.TabIndex = 5;
            this.tbFilterBy.Visible = false;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // btnAddUser
            // 
            this.btnAddUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddUser.Image = global::Course19DVLDProject.Properties.Resources.add_user;
            this.btnAddUser.Location = new System.Drawing.Point(828, 222);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(74, 72);
            this.btnAddUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddUser.TabIndex = 6;
            this.btnAddUser.TabStop = false;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course19DVLDProject.Properties.Resources.application_manager;
            this.pictureBox1.Location = new System.Drawing.Point(353, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 505);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "# Records :";
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.Location = new System.Drawing.Point(111, 506);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(35, 18);
            this.lblRecordsNumber.TabIndex = 8;
            this.lblRecordsNumber.Text = "???";
            // 
            // cbIsActive
            // 
            this.cbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsActive.FormattingEnabled = true;
            this.cbIsActive.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsActive.Location = new System.Drawing.Point(277, 278);
            this.cbIsActive.Name = "cbIsActive";
            this.cbIsActive.Size = new System.Drawing.Size(121, 24);
            this.cbIsActive.TabIndex = 9;
            this.cbIsActive.Visible = false;
            this.cbIsActive.SelectedIndexChanged += new System.EventHandler(this.cbIsActive_SelectedIndexChanged);
            // 
            // frmManageUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 533);
            this.Controls.Add(this.cbIsActive);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddUser);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Users";
            this.Load += new System.EventHandler(this.frmManageUsers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.PictureBox btnAddUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.ComboBox cbIsActive;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAddNewUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditUser;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteUser;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSendEmail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPhoneCall;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemChangePassword;
    }
}