using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;

namespace WaterAndPower.UserControls
{
    public partial class UC_Dashboard : UserControl
    {
        DataAccess ds;
        public UC_Dashboard()
        {
            InitializeComponent();
            ds = new DataAccess();
        }
        string contractors, noOfJobs, completedJobs, workToBeDone, TotalPaid;

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
           contractors = ds.getSingleValueSingleColumn("select count(contractor_id) from contractor_tbl where user_id = '"+ Helper.UserData[0] + "'",out contractors,0);
           noOfJobs = ds.getSingleValueSingleColumn("select count(work_id) from work_tbl where user_id = '"+ Helper.UserData[0] + "'", out noOfJobs,0);
           completedJobs = ds.getSingleValueSingleColumn("select count(work_id) from work_tbl where status = 'Completed' AND user_id = '"+ Helper.UserData[0] + "'", out completedJobs,0);
           workToBeDone = ds.getSingleValueSingleColumn("select count(work_id) from work_tbl where status = 'In Progress' AND user_id = '"+ Helper.UserData[0] + "'", out workToBeDone,0);
           TotalPaid = ds.getSingleValueSingleColumn("select sum(work_fee) from work_tbl where status = 'Completed' AND user_id = '"+ Helper.UserData[0] + "'", out TotalPaid, 0);


            lblContractors.Text = contractors;
            lblJobs.Text = noOfJobs;
            blCompletedJobs.Text = completedJobs;
            blWorkToBeDone.Text = workToBeDone;
            lblTotalPaid.Text = TotalPaid;

        }
    }
}
