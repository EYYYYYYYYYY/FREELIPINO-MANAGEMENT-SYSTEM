using Pharmonics19._1.Helpers;
using Pharmonics19.DbFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterAndPower.Forms
{
    public partial class Form_Login : Form
    {
        DataAccess ds;
       
        public Form_Login()
        {
            InitializeComponent();
            ds = new DataAccess();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool isFormValid()
        {
            if (txtUserName.Text.Trim() == string.Empty || txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("User Name and Password both are required..", "Enter User Name and Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool isLoginDetailsCorrect()
        {
            if(ds.connect()==true)
            {
                string userID = ds.getSingleValueSingleColumn("select user_id from user_account where user_email = '" + txtUserName.Text + "' and user_password = '" + txtPassword.Text + "'", out userID, 0);
                if (userID == null)
                {
                    MessageBox.Show("UserName or Password is Incorrect.", "Incorrect Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Not Connected");
                return false;
            }


        }
        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                if (isLoginDetailsCorrect())
                {
                    string[] UserData = ds.getArray("select id,FullName,RoleId from tblUsers where userName = '" + txtUserName.Text + "' and password = '" + txtPassword.Text + "'", 4);
                    Helper.UserData = UserData;

                    using (Form_Dashboard fd = new Form_Dashboard())
                    {
                        fd.ShowDialog();
                    }
                    txtUserName.Text = "";
                    txtPassword.Text = "";
                    txtUserName.Focus();
                }
            }
        }

        private void Label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please contact with System Administrator: info@csharpui.com","Forgot Password?",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void TxtPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.BtnLogin_Click(sender, e);
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }

        private void txtPassword_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
