namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications
{
    partial class frmLocalDrivingLicenseApplications
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
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowApplicationDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemEditApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDeleteApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemCancelApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemScheduleTests = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScheduleVisionTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShceduleWrittenTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemScheduleStreetTest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemIssueDrivingLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowLicense = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.btnAddNewLocalDrivingLicenseApplication = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewLocalDrivingLicenseApplication)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.Location = new System.Drawing.Point(272, 189);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(200, 22);
            this.tbFilterBy.TabIndex = 24;
            this.tbFilterBy.Visible = false;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(110, 577);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(17, 18);
            this.lblNumberOfRecords.TabIndex = 23;
            this.lblNumberOfRecords.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 577);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 22;
            this.label3.Text = "# Records :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(11, 218);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1199, 356);
            this.dataGridView1.TabIndex = 21;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowApplicationDetails,
            this.toolStripSeparator1,
            this.toolStripMenuItemEditApplication,
            this.toolStripMenuItemDeleteApplication,
            this.toolStripSeparator2,
            this.toolStripMenuItemCancelApplication,
            this.toolStripSeparator3,
            this.toolStripMenuItemScheduleTests,
            this.toolStripSeparator4,
            this.toolStripMenuItemIssueDrivingLicense,
            this.toolStripSeparator5,
            this.toolStripMenuItemShowLicense,
            this.toolStripSeparator6,
            this.toolStripMenuItemShowPersonLicenseHistory});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(293, 232);
            this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
            // 
            // toolStripMenuItemShowApplicationDetails
            // 
            this.toolStripMenuItemShowApplicationDetails.Name = "toolStripMenuItemShowApplicationDetails";
            this.toolStripMenuItemShowApplicationDetails.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemShowApplicationDetails.Text = "Show Application Details";
            this.toolStripMenuItemShowApplicationDetails.Click += new System.EventHandler(this.toolStripMenuItemShowApplicationDetails_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemEditApplication
            // 
            this.toolStripMenuItemEditApplication.Name = "toolStripMenuItemEditApplication";
            this.toolStripMenuItemEditApplication.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemEditApplication.Text = "Edit Application";
            this.toolStripMenuItemEditApplication.Click += new System.EventHandler(this.toolStripMenuItemEditApplication_Click);
            // 
            // toolStripMenuItemDeleteApplication
            // 
            this.toolStripMenuItemDeleteApplication.Name = "toolStripMenuItemDeleteApplication";
            this.toolStripMenuItemDeleteApplication.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemDeleteApplication.Text = "Delete Application";
            this.toolStripMenuItemDeleteApplication.Click += new System.EventHandler(this.toolStripMenuItemDeleteApplication_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemCancelApplication
            // 
            this.toolStripMenuItemCancelApplication.Name = "toolStripMenuItemCancelApplication";
            this.toolStripMenuItemCancelApplication.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemCancelApplication.Text = "Cancel Application";
            this.toolStripMenuItemCancelApplication.Click += new System.EventHandler(this.toolStripMenuItemCancelApplication_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemScheduleTests
            // 
            this.toolStripMenuItemScheduleTests.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemScheduleVisionTest,
            this.toolStripMenuItemShceduleWrittenTest,
            this.toolStripMenuItemScheduleStreetTest});
            this.toolStripMenuItemScheduleTests.Name = "toolStripMenuItemScheduleTests";
            this.toolStripMenuItemScheduleTests.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemScheduleTests.Text = "Schedule Tests";
            // 
            // toolStripMenuItemScheduleVisionTest
            // 
            this.toolStripMenuItemScheduleVisionTest.Name = "toolStripMenuItemScheduleVisionTest";
            this.toolStripMenuItemScheduleVisionTest.Size = new System.Drawing.Size(235, 26);
            this.toolStripMenuItemScheduleVisionTest.Text = "Schedule Vision Test";
            this.toolStripMenuItemScheduleVisionTest.Click += new System.EventHandler(this.toolStripMenuItemScheduleVisionTest_Click);
            // 
            // toolStripMenuItemShceduleWrittenTest
            // 
            this.toolStripMenuItemShceduleWrittenTest.Name = "toolStripMenuItemShceduleWrittenTest";
            this.toolStripMenuItemShceduleWrittenTest.Size = new System.Drawing.Size(235, 26);
            this.toolStripMenuItemShceduleWrittenTest.Text = "Schedule Written Test";
            this.toolStripMenuItemShceduleWrittenTest.Click += new System.EventHandler(this.toolStripMenuItemShceduleWrittenTest_Click);
            // 
            // toolStripMenuItemScheduleStreetTest
            // 
            this.toolStripMenuItemScheduleStreetTest.Name = "toolStripMenuItemScheduleStreetTest";
            this.toolStripMenuItemScheduleStreetTest.Size = new System.Drawing.Size(235, 26);
            this.toolStripMenuItemScheduleStreetTest.Text = "Schedule Street Test";
            this.toolStripMenuItemScheduleStreetTest.Click += new System.EventHandler(this.toolStripMenuItemScheduleStreetTest_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemIssueDrivingLicense
            // 
            this.toolStripMenuItemIssueDrivingLicense.Name = "toolStripMenuItemIssueDrivingLicense";
            this.toolStripMenuItemIssueDrivingLicense.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemIssueDrivingLicense.Text = "Issue Driving License (First Time)";
            this.toolStripMenuItemIssueDrivingLicense.Click += new System.EventHandler(this.toolStripMenuItemIssueDrivingLicense_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemShowLicense
            // 
            this.toolStripMenuItemShowLicense.Name = "toolStripMenuItemShowLicense";
            this.toolStripMenuItemShowLicense.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemShowLicense.Text = "Show License";
            this.toolStripMenuItemShowLicense.Click += new System.EventHandler(this.toolStripMenuItemShowLicense_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(289, 6);
            // 
            // toolStripMenuItemShowPersonLicenseHistory
            // 
            this.toolStripMenuItemShowPersonLicenseHistory.Name = "toolStripMenuItemShowPersonLicenseHistory";
            this.toolStripMenuItemShowPersonLicenseHistory.Size = new System.Drawing.Size(292, 24);
            this.toolStripMenuItemShowPersonLicenseHistory.Text = "Show Person License History";
            this.toolStripMenuItemShowPersonLicenseHistory.Click += new System.EventHandler(this.toolStripMenuItemShowPersonLicenseHistory_Click);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "LocalDrivingLicenseApplicationID",
            "FullName",
            "NationalNo",
            "Status"});
            this.cbFilterBy.Location = new System.Drawing.Point(94, 188);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(171, 24);
            this.cbFilterBy.TabIndex = 20;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            this.cbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbFilterBy_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Filter By :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(409, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 29);
            this.label1.TabIndex = 18;
            this.label1.Text = "Local Driving License Applications";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "All",
            "New",
            "Cancelled",
            "Completed"});
            this.cbStatus.Location = new System.Drawing.Point(272, 188);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(123, 24);
            this.cbStatus.TabIndex = 26;
            this.cbStatus.Visible = false;
            this.cbStatus.SelectedIndexChanged += new System.EventHandler(this.cbStatus_SelectedIndexChanged);
            // 
            // btnAddNewLocalDrivingLicenseApplication
            // 
            this.btnAddNewLocalDrivingLicenseApplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddNewLocalDrivingLicenseApplication.Image = global::Course19DVLDProject.Properties.Resources.Add_Local_Driving_License_Application;
            this.btnAddNewLocalDrivingLicenseApplication.Location = new System.Drawing.Point(1146, 159);
            this.btnAddNewLocalDrivingLicenseApplication.Name = "btnAddNewLocalDrivingLicenseApplication";
            this.btnAddNewLocalDrivingLicenseApplication.Size = new System.Drawing.Size(64, 53);
            this.btnAddNewLocalDrivingLicenseApplication.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddNewLocalDrivingLicenseApplication.TabIndex = 25;
            this.btnAddNewLocalDrivingLicenseApplication.TabStop = false;
            this.btnAddNewLocalDrivingLicenseApplication.Click += new System.EventHandler(this.btnAddNewLocalDrivingLicenseApplication_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course19DVLDProject.Properties.Resources.Manage_Test_Types;
            this.pictureBox1.Location = new System.Drawing.Point(518, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = global::Course19DVLDProject.Properties.Resources.close;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1073, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 43);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmLocalDrivingLicenseApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1219, 633);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.btnAddNewLocalDrivingLicenseApplication);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmLocalDrivingLicenseApplications";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Local Driving License Applications";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenseApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnAddNewLocalDrivingLicenseApplication)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnAddNewLocalDrivingLicenseApplication;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowApplicationDetails;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEditApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDeleteApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCancelApplication;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleTests;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemIssueDrivingLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowLicense;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleVisionTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShceduleWrittenTest;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemScheduleStreetTest;
        private System.Windows.Forms.Button btnClose;
    }
}