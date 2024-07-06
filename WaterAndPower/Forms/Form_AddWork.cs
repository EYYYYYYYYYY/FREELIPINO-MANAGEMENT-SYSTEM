using Pharmonics19.DbFiles;
using Pharmonics19._1.Helpers;
using System;
using System.Windows.Forms;

namespace WaterAndPower.Forms
{
    public partial class Form_AddWork : Form
    {
        DataAccess ds;
        
        public Form_AddWork()
        {
            InitializeComponent();
            ds = new DataAccess();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
        private void Button5_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            
=======
            if (isFormValid())
            {
                DialogResult dialog = MessageBox.Show("Are You Sure Want to add this Work?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    string hoaId = ds.getSingleValueSingleColumn("Select id from tblHeadOfAccounts where AccountNo = '"+cmbHOA.Text+"'",out hoaId,0);
                    ds.InsertUpdateDeleteCreate("insert into work_tbl(contractor_id,wor_name,work_desc,work_fee) VALUES('"+txtTitle.Text+"','"+txtTsNo.Text+ "','" + txtTsAmount.Text + "','" + txtMBNo.Text + "','" + txtPageNo.Text + "','" + hoaId + "')");
                    MessageBox.Show("Work Added Successfully..!!","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    this.Dispose();
                }
            }
>>>>>>> Stashed changes
        }

       

        private void Form_AddWork_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtTitle_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
