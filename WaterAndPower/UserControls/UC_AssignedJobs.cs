using System;
using System.Windows.Forms;
using WaterAndPower.Forms;
using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;

namespace WaterAndPower.UserControls
{
    public partial class UC_AssignedJobs : UserControl
    {
        DataAccess ds;
        private int selectedWorkId;
        public UC_AssignedJobs()
        {
            InitializeComponent();
            ds = new DataAccess();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (workAssignId !=null && !completed)
            {
                using (Form_PayAmount py = new Form_PayAmount())
                {
                    py.WorkAssignId = workAssignId;
                    py.WorkTitle = title;
                    py.ContractorName = ContractorName;
                    py.CACost = CACost;
                    py.ShowDialog();
                    this.OnLoad(e);
                }
            }
            
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            if (workAssignId != null && !completed)
            {
                using (Form_AddWorkDone wd = new Form_AddWorkDone())
                {
                    wd.WorkTitle = title;
                    wd.ContractorName = ContractorName;
                    wd.WorkAssgnId = workAssignId;
                    wd.CACost = CACost;
                    wd.ShowDialog();
                }
            }
            
        }

        private bool completed;
        private void UC_AssignedJobs_Load(object sender, EventArgs e)
        {
            ds.fillgridView("select work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where user_id = '"+ Helper.UserData[0]+"'", dataGridView1);
            completed = false;
        }

        string workAssignId, title, ContractorName,CACost;

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedWorkId = Convert.ToInt32(row.Cells["work_id"].Value);
            }
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (!completed)
            {
                ds.fillgridView("select wa.id,w.title as 'Work Title',c.name as 'Contractor Name',wa.CACost,wa.AssignDate,wa.Period from tblWorkAssigned as wa inner join tblWorks as w ON wa.WorkId = w.id inner join tblContractors as c ON wa.ContractorId = c.id where w.isAssigned = 1 and wa.isCompleted = 1", dataGridView1);
                completed = true;
                btnEdit.Text = "   Not Completed";
            }
            else
            {
                btnEdit.Text = "   Completed Jobs";
                this.OnLoad(e);
            }
        }

    }
}
