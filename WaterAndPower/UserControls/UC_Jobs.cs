using System;
using System.Windows.Forms;
using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;
using WaterAndPower.Forms;

namespace WaterAndPower.UserControls
{
    public partial class UC_Jobs : UserControl
    {
        DataAccess ds;
        public int selectedWorkId, selectedAmount, selectedContractorID;
        public string selectedWorkName, selectedWorkDesc;

        public UC_Jobs()
        {
            InitializeComponent();
            ds = new DataAccess();
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            using (Form_AddWork aw = new Form_AddWork())
            {
                aw.ShowDialog();
                this.OnLoad(e);
            }
        }

        private void UC_Jobs_Load(object sender, EventArgs e)
        {
            ds.fillgridView("select contractor_id as `Contractor ID`, work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where user_id = '" + Helper.UserData[0] + "'", dataGridView1);
            lblQty.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedWorkId != 0)
            {
                using (Form_Edit ew = new Form_Edit(selectedWorkId, selectedWorkName, selectedContractorID, selectedWorkDesc, selectedAmount))
                {
                    ew.ShowDialog();
                    this.OnLoad(e);
                }
            }
            else
            {
                MessageBox.Show("Please select a job to edit.");
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedWorkId = Convert.ToInt32(row.Cells["Work Id"].Value);
                selectedWorkName = Convert.ToString(row.Cells["Work Name"].Value);
                selectedWorkDesc = Convert.ToString(row.Cells["Work Description"].Value);
                selectedAmount = Convert.ToInt32(row.Cells["Amount"].Value);
                selectedContractorID = Convert.ToInt32(row.Cells["Contractor ID"].Value);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Work Id")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`, work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where work_id = '" + txtSearch.Text + "' AND user_id = '" + Helper.UserData[0] + "'", dataGridView1);
            }
            else if (cmbSearchType.Text == "Work Name")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`, work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where work_name like '%" + txtSearch.Text + "%' AND user_id = '" + Helper.UserData[0] + "'", dataGridView1);
            }
            else if (cmbSearchType.Text == "Description")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`, work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where work_desc like '%" + txtSearch.Text + "%' AND user_id = '" + Helper.UserData[0] + "'", dataGridView1);
            }
            else if (cmbSearchType.Text == "Amount")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`, work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where work_fee = '" + txtSearch.Text + "' AND where user_id = '" + Helper.UserData[0] + "'", dataGridView1);
            }
            else
            {
                this.OnLoad(e);
            }
            if (txtSearch.Text.Length <= 0)
            {
                this.OnLoad(e);
            }
        }
    }
}
