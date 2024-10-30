namespace Course19DVLDProject.People
{
    partial class frmManagePeople
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuShowDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuAddNewPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEditPerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuDeletePerson = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuSendEmail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuPhoneCall = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(469, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 239);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By :";
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "PersonID",
            "NationalNo",
            "FirstName",
            "SecondName",
            "ThirdName",
            "LastName",
            "Nationality",
            "Gendor",
            "Phone",
            "Email"});
            this.cbFilterBy.Location = new System.Drawing.Point(98, 239);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(171, 24);
            this.cbFilterBy.TabIndex = 3;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(15, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1206, 301);
            this.dataGridView1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuShowDetails,
            this.toolStripSeparator1,
            this.toolStripMenuAddNewPerson,
            this.toolStripMenuEditPerson,
            this.toolStripMenuDeletePerson,
            this.toolStripSeparator2,
            this.toolStripMenuSendEmail,
            this.toolStripMenuPhoneCall});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(192, 172);
            // 
            // toolStripMenuShowDetails
            // 
            this.toolStripMenuShowDetails.Image = global::Course19DVLDProject.Properties.Resources.person_Details;
            this.toolStripMenuShowDetails.Name = "toolStripMenuShowDetails";
            this.toolStripMenuShowDetails.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuShowDetails.Text = "Show Details";
            this.toolStripMenuShowDetails.Click += new System.EventHandler(this.toolStripMenuShowDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuAddNewPerson
            // 
            this.toolStripMenuAddNewPerson.Image = global::Course19DVLDProject.Properties.Resources.add_person;
            this.toolStripMenuAddNewPerson.Name = "toolStripMenuAddNewPerson";
            this.toolStripMenuAddNewPerson.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuAddNewPerson.Text = "Add New Person";
            this.toolStripMenuAddNewPerson.Click += new System.EventHandler(this.toolStripMenuAddNewPerson_Click);
            // 
            // toolStripMenuEditPerson
            // 
            this.toolStripMenuEditPerson.Image = global::Course19DVLDProject.Properties.Resources.edit_person;
            this.toolStripMenuEditPerson.Name = "toolStripMenuEditPerson";
            this.toolStripMenuEditPerson.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuEditPerson.Text = "Edit Person";
            this.toolStripMenuEditPerson.Click += new System.EventHandler(this.toolStripMenuEditPerson_Click);
            // 
            // toolStripMenuDeletePerson
            // 
            this.toolStripMenuDeletePerson.Image = global::Course19DVLDProject.Properties.Resources.delete_person;
            this.toolStripMenuDeletePerson.Name = "toolStripMenuDeletePerson";
            this.toolStripMenuDeletePerson.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuDeletePerson.Text = "Delete Person";
            this.toolStripMenuDeletePerson.Click += new System.EventHandler(this.toolStripMenuDeletePerson_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuSendEmail
            // 
            this.toolStripMenuSendEmail.Image = global::Course19DVLDProject.Properties.Resources.clamshell_phone;
            this.toolStripMenuSendEmail.Name = "toolStripMenuSendEmail";
            this.toolStripMenuSendEmail.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuSendEmail.Text = "Send Email";
            this.toolStripMenuSendEmail.Click += new System.EventHandler(this.toolStripMenuSendEmail_Click);
            // 
            // toolStripMenuPhoneCall
            // 
            this.toolStripMenuPhoneCall.Image = global::Course19DVLDProject.Properties.Resources.email;
            this.toolStripMenuPhoneCall.Name = "toolStripMenuPhoneCall";
            this.toolStripMenuPhoneCall.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuPhoneCall.Text = "Phone Call";
            this.toolStripMenuPhoneCall.Click += new System.EventHandler(this.toolStripMenuPhoneCall_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "# Records :";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(114, 573);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(17, 18);
            this.lblNumberOfRecords.TabIndex = 6;
            this.lblNumberOfRecords.Text = "0";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddPerson.Image = global::Course19DVLDProject.Properties.Resources.add_person;
            this.btnAddPerson.Location = new System.Drawing.Point(1151, 213);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(58, 50);
            this.btnAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddPerson.TabIndex = 7;
            this.btnAddPerson.TabStop = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course19DVLDProject.Properties.Resources.icons8_conférence_téléphonique_64;
            this.pictureBox1.Location = new System.Drawing.Point(501, 35);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Location = new System.Drawing.Point(276, 240);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(208, 22);
            this.tbFilterBy.TabIndex = 8;
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // frmManagePeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1233, 600);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManagePeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage People";
            this.Load += new System.EventHandler(this.frmManagePeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.PictureBox btnAddPerson;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuShowDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuAddNewPerson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEditPerson;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuDeletePerson;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuSendEmail;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuPhoneCall;
        private System.Windows.Forms.TextBox tbFilterBy;
    }
}