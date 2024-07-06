using System;
using System.Windows.Forms;
using WaterAndPower.Forms;
using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;

namespace WaterAndPower.UserControls
{
    public partial class UC_Jobs : UserControl
    {
        DataAccess ds;
        private int selectedWorkId;
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
            ds.fillgridView("select work_id as `Work ID`, work_name as `Work Name`, work_desc as `Work Description`, work_fee as `Amount`, start_date as `Date Added`, end_date as `Date Ended`, status as `Status` from work_tbl where user_id = '" + Helper.UserData[0] + "'", dataGridView1);
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedWorkId = Convert.ToInt32(row.Cells["Work Id"].Value);
            }
        }
    }
}
