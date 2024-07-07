using System;
using System.Windows.Forms;
using Pharmonics19._1.Helpers;
using Pharmonics19.DbFiles;

namespace WaterAndPower.Forms
{
    public partial class Form_Edit : Form
    {
        private DataAccess ds;
        private int workId;
        private string workName;
        private int contractorId;
        private string workDesc;
        private int amount;

        public Form_Edit(int workId, string workName, int contractorId, string workDesc, int amount)
        {
            InitializeComponent();
            ds = new DataAccess();
            this.workId = workId;
            this.workName = workName;
            this.contractorId = contractorId;
            this.workDesc = workDesc;
            this.amount = amount;
            // Set the retrieved values to the corresponding text boxes
            txtTitle.Text = workName;
            txtTsNo.Text = contractorId.ToString();
            txtMBNo.Text = workDesc;
            txtTsAmount.Text = amount.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (isFormValid())
            {
                DialogResult dialog = MessageBox.Show("Are You Sure Want to add this Work?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (checkBox1.Checked)
                    {
                        ds.InsertUpdateDeleteCreate("update work_tbl set contractor_id = '" + txtTsNo.Text +"', work_name = '" + txtTitle.Text + "', work_desc = '" + txtMBNo.Text + "', work_fee = '" + txtTsAmount.Text + "', end_date = curdate(), status ='Completed' WHERE work_id = '" + workId + "'");
                        if (ds.getmessage == "Update successful")
                        {
                            MessageBox.Show("Work Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Error Occured While Updating Work!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        ds.InsertUpdateDeleteCreate("update work_tbl set contractor_id = '" + txtTsNo.Text + "', work_name = '" + txtTitle.Text + "', work_desc = '" + txtMBNo.Text + "', work_fee = '" + txtTsAmount.Text + "' WHERE work_id = '" + workId + "'");
                        if (ds.getmessage == "Update successful")
                        {
                            MessageBox.Show("Work Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Error Occured While Updating Work!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void txtMBNo_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTsAmount_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTsNo_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private bool isFormValid()
        {
            if (txtTitle.Text.Trim() == string.Empty || txtTsNo.Text.Trim() == string.Empty || txtMBNo.Text.Trim() == string.Empty || txtTsAmount.Text.Trim() == string.Empty)
            {
                MessageBox.Show("All fields are required", "Enter all the required fields", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
