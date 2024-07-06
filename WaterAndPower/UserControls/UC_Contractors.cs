using System;
using System.Windows.Forms;
using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;

namespace WaterAndPower.UserControls
{
    public partial class UC_Contractors : UserControl
    {
        private DataAccess ds;
        private int selectedContractorId;

        public UC_Contractors()
        {
            InitializeComponent();
            ds = new DataAccess();
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void Panel8_Paint(object sender, PaintEventArgs e)
        {
            // Code for Panel8_Paint event
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == string.Empty && txtAddress.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Fill all required Fields", "Required Fields are Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialog = MessageBox.Show("Are you sure want to add this Contractor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    ds.InsertUpdateDeleteCreate("insert into contractor_tbl(user_id,contractor_name,contractor_address) VALUES('" + Helper.UserData[0] + "','" + txtName.Text + "','" + txtAddress.Text + "')");
                    if (ds.getmessage == "Inserted successfully")
                    {
                        MessageBox.Show("Contractor Added Successfully!", "Contractor Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtAddress.Text = "";
                        txtName.Text = "";
                        this.OnLoad(e);
                    }
                }
            }
        }

        private void UC_Contractors_Load(object sender, EventArgs e)
        {
            ds.fillgridView("select contractor_id as `Contractor ID`,contractor_name as `Contractor Name`,contractor_address as `Contractor Address`,date_added as `Date Added` from contractor_tbl where user_id = '"+ Helper.UserData[0]+"'", dataGridView1);
            lblNo.Text = dataGridView1.Rows.Count.ToString();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.Text == "Contractor Id")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`,contractor_name as `Contractor Name`,contractor_address as `Contractor Address`,date_added as `Date Added` from contractor_tbl where contractor_id = '" + txtSearch.Text + "' AND where user_id = '"+ Helper.UserData[0]+"'", dataGridView1);
            }
            else if (cmbSearchType.Text == "Name")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`,contractor_name as `Contractor Name`,contractor_address as `Contractor Address`,date_added as `Date Added` from contractor_tbl where contractor_name like '%" + txtSearch.Text + "%' AND where user_id = '"+ Helper.UserData[0]+"'", dataGridView1);
            }
            else if (cmbSearchType.Text == "Address")
            {
                ds.fillgridView("select contractor_id as `Contractor ID`,contractor_name as `Contractor Name`,contractor_address as `Contractor Address`,date_added as `Date Added` from contractor_tbl where contractor_address like '%" + txtSearch.Text + "%' AND where user_id = '"+ Helper.UserData[0]+"'", dataGridView1);
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

        private void delete(int contractorId)
        {
            ds.InsertUpdateDeleteCreate("delete from contractor_tbl where contractor_id = '" + contractorId + "'");
            if (ds.getmessage == "Delete successful")
            {
                MessageBox.Show("Contractor Deleted Successfully!", "Contractor Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                selectedContractorId = Convert.ToInt32(row.Cells["Contractor Id"].Value);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            delete(selectedContractorId);
            this.OnLoad(e);
        }
    }
}
