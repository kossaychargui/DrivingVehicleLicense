using DVLDBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Course19DVLDProject
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            _LoadUserCredentials();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsGlobalSettings.LoggedInUser = clsUser.FindUserByCredentials(tbUserName.Text, tbPassword.Text);
            if (clsGlobalSettings.LoggedInUser == null)
            {
                MessageBox.Show("Wrong UserName/Password", "Failed To Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
               _SaveLoggedInUserCredentials();
                Main frm = new Main();
                frm.ShowDialog();
            }
        }
        private void _SaveLoggedInUserCredentials()
        {
            string FilePath = @"C:\Users\Media\source\repos\Course19DVLDProject\LoggedInUserCredentials.txt";
            
                try{
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    if (cbRememberMe.Checked)
                    {
                        writer.WriteLine(tbUserName.Text);
                        writer.WriteLine(tbPassword.Text);
                    }
                }

                }
                catch(Exception ex) {
                    MessageBox.Show("Error " + ex.Message);
                }
            
            
        }
        private void _LoadUserCredentials()
        {
            string FilePath = @"C:\Users\Media\source\repos\Course19DVLDProject\LoggedInUserCredentials.txt";
            try
            {
                string[] lines = File.ReadAllLines(FilePath);
                if (lines.Length >= 2)
                {
                    tbUserName.Text = lines[0];
                    tbPassword.Text = lines[1];
                    cbRememberMe.Checked = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

    }
}
