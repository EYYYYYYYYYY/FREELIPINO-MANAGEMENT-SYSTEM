﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Pharmonics19.DbFiles;

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
        string contractors, noOfJobs, AssignedJobs, completedJobs, WorkDoneAmt, workToBeDone, TotalPaid;

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
           contractors = ds.getSingleValueSingleColumn("select count(id) from tblContractors",out contractors,0);
           noOfJobs = ds.getSingleValueSingleColumn("select count(id) from tblWorks",out noOfJobs,0);
           AssignedJobs = ds.getSingleValueSingleColumn("select count(id) from tblWorkAssigned",out AssignedJobs,0);
           completedJobs = ds.getSingleValueSingleColumn("select count(id) from tblWorkAssigned where isCompleted = 1", out completedJobs,0);

           WorkDoneAmt = ds.getSingleValueSingleColumn("select sum(WorkDone) from tblCalculations", out WorkDoneAmt,0);
           workToBeDone = ds.getSingleValueSingleColumn("select sum(WorkToBeDone) from tblCalculations", out workToBeDone,0);
            TotalPaid = ds.getSingleValueSingleColumn("select sum(AmountPaid) from tblCalculations", out TotalPaid, 0);


            lblContractors.Text = contractors;
            lblJobs.Text = noOfJobs;
            blCompletedJobs.Text = completedJobs;
            blWorkDone.Text = WorkDoneAmt;
            blWorkToBeDone.Text = workToBeDone;
            lblTotalPaid.Text = TotalPaid;

        }
    }
}
