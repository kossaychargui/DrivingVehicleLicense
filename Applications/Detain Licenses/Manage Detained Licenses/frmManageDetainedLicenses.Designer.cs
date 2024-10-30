namespace Course19DVLDProject.Applications.Detain_Licenses.Manage_Detained_Licenses
{
    partial class frmManageDetainedLicenses
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
            this.cbIsReleased = new System.Windows.Forms.ComboBox();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetanLicense = new System.Windows.Forms.PictureBox();
            this.btnReleaseLicense = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemShowPersonDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemsShowLicenseDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemShowPersonLicenseHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemReleaseDetainedLicense = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetanLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReleaseLicense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbIsReleased
            // 
            this.cbIsReleased.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIsReleased.FormattingEnabled = true;
            this.cbIsReleased.Items.AddRange(new object[] {
            "All",
            "Yes",
            "No"});
            this.cbIsReleased.Location = new System.Drawing.Point(277, 278);
            this.cbIsReleased.Name = "cbIsReleased";
            this.cbIsReleased.Size = new System.Drawing.Size(121, 24);
            this.cbIsReleased.TabIndex = 19;
            this.cbIsReleased.Visible = false;
            this.cbIsReleased.SelectedIndexChanged += new System.EventHandler(this.cbIsReleased_SelectedIndexChanged);
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.Location = new System.Drawing.Point(114, 574);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(35, 18);
            this.lblRecordsNumber.TabIndex = 18;
            this.lblRecordsNumber.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "# Records :";
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilterBy.Location = new System.Drawing.Point(277, 278);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(186, 22);
            this.tbFilterBy.TabIndex = 15;
            this.tbFilterBy.Visible = false;
            this.tbFilterBy.TextChanged += new System.EventHandler(this.tbFilterBy_TextChanged);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "None",
            "Detain ID",
            "Is Released",
            "National No.",
            "FullName",
            "Release Appliction ID"});
            this.cbFilterBy.Location = new System.Drawing.Point(98, 278);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(173, 24);
            this.cbFilterBy.TabIndex = 14;
            this.cbFilterBy.SelectedIndexChanged += new System.EventHandler(this.cbFilterBy_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter By :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 306);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1084, 264);
            this.dataGridView1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(388, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(314, 36);
            this.label1.TabIndex = 11;
            this.label1.Text = "List Detained Licenses";
            // 
            // btnDetanLicense
            // 
            this.btnDetanLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnDetanLicense.Image = global::Course19DVLDProject.Properties.Resources.Detain_Licence;
            this.btnDetanLicense.Location = new System.Drawing.Point(1022, 223);
            this.btnDetanLicense.Name = "btnDetanLicense";
            this.btnDetanLicense.Size = new System.Drawing.Size(74, 72);
            this.btnDetanLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDetanLicense.TabIndex = 20;
            this.btnDetanLicense.TabStop = false;
            this.btnDetanLicense.Click += new System.EventHandler(this.btnDetanLicense_Click);
            // 
            // btnReleaseLicense
            // 
            this.btnReleaseLicense.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnReleaseLicense.Image = global::Course19DVLDProject.Properties.Resources.Release;
            this.btnReleaseLicense.Location = new System.Drawing.Point(945, 223);
            this.btnReleaseLicense.Name = "btnReleaseLicense";
            this.btnReleaseLicense.Size = new System.Drawing.Size(71, 72);
            this.btnReleaseLicense.TabIndex = 16;
            this.btnReleaseLicense.TabStop = false;
            this.btnReleaseLicense.Click += new System.EventHandler(this.btnReleaseLicense_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Course19DVLDProject.Properties.Resources.Detain;
            this.pictureBox1.Location = new System.Drawing.Point(449, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemShowPersonDetails,
            this.toolStripMenuItemsShowLicenseDetails,
            this.toolStripMenuItemShowPersonLicenseHistory,
            this.toolStripSeparator1,
            this.toolStripMenuItemReleaseDetainedLicense});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(269, 142);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);

            // 
            // toolStripMenuItemShowPersonDetails
            // 
            this.toolStripMenuItemShowPersonDetails.Image = global::Course19DVLDProject.Properties.Resources.person_Details;
            this.toolStripMenuItemShowPersonDetails.Name = "toolStripMenuItemShowPersonDetails";
            this.toolStripMenuItemShowPersonDetails.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemShowPersonDetails.Text = "Show Person Details";
            this.toolStripMenuItemShowPersonDetails.Click += new System.EventHandler(this.toolStripMenuItemShowPersonDetails_Click);
            // 
            // toolStripMenuItemsShowLicenseDetails
            // 
            this.toolStripMenuItemsShowLicenseDetails.Image = global::Course19DVLDProject.Properties.Resources.Driving_License;
            this.toolStripMenuItemsShowLicenseDetails.Name = "toolStripMenuItemsShowLicenseDetails";
            this.toolStripMenuItemsShowLicenseDetails.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemsShowLicenseDetails.Text = "Show License Details";
            this.toolStripMenuItemsShowLicenseDetails.Click += new System.EventHandler(this.toolStripMenuItemsShowLicenseDetails_Click);
            // 
            // toolStripMenuItemShowPersonLicenseHistory
            // 
            this.toolStripMenuItemShowPersonLicenseHistory.Image = global::Course19DVLDProject.Properties.Resources.list_1_;
            this.toolStripMenuItemShowPersonLicenseHistory.Name = "toolStripMenuItemShowPersonLicenseHistory";
            this.toolStripMenuItemShowPersonLicenseHistory.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemShowPersonLicenseHistory.Text = "Show Person License History";
            this.toolStripMenuItemShowPersonLicenseHistory.Click += new System.EventHandler(this.toolStripMenuItemShowPersonLicenseHistory_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(265, 6);
            // 
            // toolStripMenuItemReleaseDetainedLicense
            // 
            this.toolStripMenuItemReleaseDetainedLicense.Image = global::Course19DVLDProject.Properties.Resources.Release;
            this.toolStripMenuItemReleaseDetainedLicense.Name = "toolStripMenuItemReleaseDetainedLicense";
            this.toolStripMenuItemReleaseDetainedLicense.Size = new System.Drawing.Size(268, 26);
            this.toolStripMenuItemReleaseDetainedLicense.Text = "Release Detained License";
            this.toolStripMenuItemReleaseDetainedLicense.Click += new System.EventHandler(this.toolStripMenuItemReleaseDetainedLicense_Click);
            // 
            // frmManageDetainedLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 600);
            this.Controls.Add(this.btnDetanLicense);
            this.Controls.Add(this.cbIsReleased);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnReleaseLicense);
            this.Controls.Add(this.tbFilterBy);
            this.Controls.Add(this.cbFilterBy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmManageDetainedLicenses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "List Detained Licenses";
            this.Load += new System.EventHandler(this.frmManageDetainedLicenses_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDetanLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnReleaseLicense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbIsReleased;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox btnReleaseLicense;
        private System.Windows.Forms.TextBox tbFilterBy;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnDetanLicense;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPersonDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemsShowLicenseDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemShowPersonLicenseHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemReleaseDetainedLicense;
    }
}