namespace Course19DVLDProject.Controls
{
    partial class ctrlFilterPerson
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbFilterBy = new System.Windows.Forms.TextBox();
            this.cbFilterBy = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAddPerson = new System.Windows.Forms.PictureBox();
            this.btnSearchForPerson = new System.Windows.Forms.PictureBox();
            this.cntrlPersonInformation1 = new Course19DVLDProject.Controls.cntrlPersonInformation();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchForPerson)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbFilterBy);
            this.groupBox1.Controls.Add(this.btnAddPerson);
            this.groupBox1.Controls.Add(this.btnSearchForPerson);
            this.groupBox1.Controls.Add(this.cbFilterBy);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(875, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // tbFilterBy
            // 
            this.tbFilterBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFilterBy.Location = new System.Drawing.Point(310, 52);
            this.tbFilterBy.Name = "tbFilterBy";
            this.tbFilterBy.Size = new System.Drawing.Size(232, 22);
            this.tbFilterBy.TabIndex = 4;
            this.tbFilterBy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFilterBy_KeyPress);
            // 
            // cbFilterBy
            // 
            this.cbFilterBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterBy.FormattingEnabled = true;
            this.cbFilterBy.Items.AddRange(new object[] {
            "NationalNo",
            "PersonID"});
            this.cbFilterBy.Location = new System.Drawing.Point(101, 51);
            this.cbFilterBy.Name = "cbFilterBy";
            this.cbFilterBy.Size = new System.Drawing.Size(202, 24);
            this.cbFilterBy.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By :";
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnAddPerson.Image = global::Course19DVLDProject.Properties.Resources.add_person;
            this.btnAddPerson.Location = new System.Drawing.Point(619, 43);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(38, 37);
            this.btnAddPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnAddPerson.TabIndex = 3;
            this.btnAddPerson.TabStop = false;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnSearchForPerson
            // 
            this.btnSearchForPerson.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnSearchForPerson.Image = global::Course19DVLDProject.Properties.Resources.search_for_person;
            this.btnSearchForPerson.Location = new System.Drawing.Point(560, 43);
            this.btnSearchForPerson.Name = "btnSearchForPerson";
            this.btnSearchForPerson.Size = new System.Drawing.Size(38, 37);
            this.btnSearchForPerson.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnSearchForPerson.TabIndex = 2;
            this.btnSearchForPerson.TabStop = false;
            this.btnSearchForPerson.Click += new System.EventHandler(this.btnSearchForPerson_Click);
            // 
            // cntrlPersonInformation1
            // 
            this.cntrlPersonInformation1.Location = new System.Drawing.Point(3, 128);
            this.cntrlPersonInformation1.Name = "cntrlPersonInformation1";
            this.cntrlPersonInformation1.Size = new System.Drawing.Size(885, 324);
            this.cntrlPersonInformation1.TabIndex = 1;
            // 
            // ctrlFilterPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cntrlPersonInformation1);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlFilterPerson";
            this.Size = new System.Drawing.Size(886, 450);
            this.Load += new System.EventHandler(this.ctrlFilterPerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchForPerson)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private cntrlPersonInformation cntrlPersonInformation1;
        private System.Windows.Forms.PictureBox btnAddPerson;
        private System.Windows.Forms.PictureBox btnSearchForPerson;
        private System.Windows.Forms.ComboBox cbFilterBy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbFilterBy;
    }
}
