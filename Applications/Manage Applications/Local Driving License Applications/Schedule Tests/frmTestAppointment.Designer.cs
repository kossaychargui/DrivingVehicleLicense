namespace Course19DVLDProject.Applications.Manage_Applications.Local_Driving_License_Applications.Schedule_Tests
{
    partial class frmTestAppointment
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
            this.lblTestAppointmentName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTake = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNumberOfRecords = new System.Windows.Forms.Label();
            this.btnScheduleTest = new System.Windows.Forms.PictureBox();
            this.pbTestAppointmentImage = new System.Windows.Forms.PictureBox();
            this.ctrlDrivingLicenseApplicationInfo1 = new Course19DVLDProject.Controls.ctrlDrivingLicenseApplicationInfo();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnScheduleTest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointmentImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTestAppointmentName
            // 
            this.lblTestAppointmentName.AutoSize = true;
            this.lblTestAppointmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestAppointmentName.ForeColor = System.Drawing.Color.Red;
            this.lblTestAppointmentName.Location = new System.Drawing.Point(316, 155);
            this.lblTestAppointmentName.Name = "lblTestAppointmentName";
            this.lblTestAppointmentName.Size = new System.Drawing.Size(274, 29);
            this.lblTestAppointmentName.TabIndex = 1;
            this.lblTestAppointmentName.Text = "Vision Test Appointment";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Location = new System.Drawing.Point(12, 622);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(893, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemEdit,
            this.toolStripMenuItemTake});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(112, 56);
            // 
            // toolStripMenuItemEdit
            // 
            this.toolStripMenuItemEdit.Image = global::Course19DVLDProject.Properties.Resources.edit_person;
            this.toolStripMenuItemEdit.Name = "toolStripMenuItemEdit";
            this.toolStripMenuItemEdit.Size = new System.Drawing.Size(111, 26);
            this.toolStripMenuItemEdit.Text = "Edit";
            this.toolStripMenuItemEdit.Click += new System.EventHandler(this.toolStripMenuItemEdit_Click);
            // 
            // toolStripMenuItemTake
            // 
            this.toolStripMenuItemTake.Image = global::Course19DVLDProject.Properties.Resources.written_Test;
            this.toolStripMenuItemTake.Name = "toolStripMenuItemTake";
            this.toolStripMenuItemTake.Size = new System.Drawing.Size(111, 26);
            this.toolStripMenuItemTake.Text = "Take";
            this.toolStripMenuItemTake.Click += new System.EventHandler(this.toolStripMenuItemTake_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 599);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appointments :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 781);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "# Records :";
            // 
            // lblNumberOfRecords
            // 
            this.lblNumberOfRecords.AutoSize = true;
            this.lblNumberOfRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumberOfRecords.Location = new System.Drawing.Point(114, 781);
            this.lblNumberOfRecords.Name = "lblNumberOfRecords";
            this.lblNumberOfRecords.Size = new System.Drawing.Size(35, 18);
            this.lblNumberOfRecords.TabIndex = 6;
            this.lblNumberOfRecords.Text = "???";
            // 
            // btnScheduleTest
            // 
            this.btnScheduleTest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnScheduleTest.Image = global::Course19DVLDProject.Properties.Resources.Schedule_Appointment;
            this.btnScheduleTest.Location = new System.Drawing.Point(854, 569);
            this.btnScheduleTest.Name = "btnScheduleTest";
            this.btnScheduleTest.Size = new System.Drawing.Size(51, 50);
            this.btnScheduleTest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnScheduleTest.TabIndex = 7;
            this.btnScheduleTest.TabStop = false;
            this.btnScheduleTest.Click += new System.EventHandler(this.btnScheduleTest_Click);
            // 
            // pbTestAppointmentImage
            // 
            this.pbTestAppointmentImage.Image = global::Course19DVLDProject.Properties.Resources.Vision_Test;
            this.pbTestAppointmentImage.Location = new System.Drawing.Point(381, 12);
            this.pbTestAppointmentImage.Name = "pbTestAppointmentImage";
            this.pbTestAppointmentImage.Size = new System.Drawing.Size(137, 123);
            this.pbTestAppointmentImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbTestAppointmentImage.TabIndex = 0;
            this.pbTestAppointmentImage.TabStop = false;
            // 
            // ctrlDrivingLicenseApplicationInfo1
            // 
            this.ctrlDrivingLicenseApplicationInfo1.Location = new System.Drawing.Point(12, 187);
            this.ctrlDrivingLicenseApplicationInfo1.Name = "ctrlDrivingLicenseApplicationInfo1";
            this.ctrlDrivingLicenseApplicationInfo1.Size = new System.Drawing.Size(894, 383);
            this.ctrlDrivingLicenseApplicationInfo1.TabIndex = 2;
            // 
            // frmTestAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 808);
            this.Controls.Add(this.btnScheduleTest);
            this.Controls.Add(this.lblNumberOfRecords);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ctrlDrivingLicenseApplicationInfo1);
            this.Controls.Add(this.lblTestAppointmentName);
            this.Controls.Add(this.pbTestAppointmentImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmTestAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vesion Test Appointment";
            this.Load += new System.EventHandler(this.frmVisionTestAppointment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnScheduleTest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTestAppointmentImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbTestAppointmentImage;
        private System.Windows.Forms.Label lblTestAppointmentName;
        private Controls.ctrlDrivingLicenseApplicationInfo ctrlDrivingLicenseApplicationInfo1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNumberOfRecords;
        private System.Windows.Forms.PictureBox btnScheduleTest;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEdit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTake;
    }
}