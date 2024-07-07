using Pharmonics19._1.Helpers;
using Pharmonics19.DbFiles;
using System;
using System.Windows.Forms;
using WaterAndPower.UserControls;

namespace WaterAndPower.Forms
{
    public partial class Form_Dashboard : Form
    {
        int panelWidth;
        bool Hidden;
        DataAccess ds;
        public Form_Dashboard()
        {
            InitializeComponent();
            ds = new DataAccess();
            panelWidth = panelLeft.Width;
            Hidden = false;
            UC_Dashboard uC = new UC_Dashboard();
            addControls(uC);
        }

        private void Panel4_Paint(object sender, PaintEventArgs e)
        {

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void slidePanel(Button btn)
        {
            panelSide.Height = btn.Height;
            panelSide.Top = btn.Top;
        }

        private void addControls(UserControl uc)
        {
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }


        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Dashboard";
            slidePanel(btnDashboard);
            UC_Dashboard uC = new UC_Dashboard();
            addControls(uC);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (Hidden)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= panelWidth)
                {
                    timer1.Stop();
                    Hidden = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 55)
                {
                    timer1.Stop();
                    Hidden = true;
                    this.Refresh();
                }
            }
        }

        private void BtnJobs_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnAboutUs_Click(object sender, EventArgs e)
        {
            using (Form_AboutUs uu = new Form_AboutUs())
            {
                uu.ShowDialog();
            }
        }

        private void BtnContractors_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Contractors";
            slidePanel(btnContractors);
            UC_Contractors ucc = new UC_Contractors();
            addControls(ucc);
        }

        private void BtnWorks_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Manage Works";
            slidePanel(btnWorks);
            UC_Jobs ab = new UC_Jobs();
            addControls(ab);
        }

        private void Form_Dashboard_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Helper.UserData[1];
            string RoleName = ds.getSingleValueSingleColumn("select user_type from user_account where user_id = '" + Helper.UserData[0] + "'", out RoleName, 0);
            lblRole.Text = RoleName;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void lblRole_Click(object sender, EventArgs e)
        {

        }
    }
}
