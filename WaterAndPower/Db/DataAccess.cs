using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Pharmonics19.DbFiles
{
    class DataAccess
    {
        static string _ConnectionString = "server=localhost;port=3306;uid=root;pwd=[password];database=freelipino";
        MySqlCommand cmd_;
        MySqlConnection conn_;
        MySqlDataAdapter adptr_;
        MySqlDataReader reader_;
        DataTable dtable_;

        public string getmessage { get; set; }

        public DataAccess()
        {
            conn_ = new MySqlConnection(_ConnectionString);
            cmd_ = new MySqlCommand();
            dtable_ = new DataTable();
            adptr_ = new MySqlDataAdapter();
        }

        public bool connect()
        {
            try
            {
                conn_.Open();
                getmessage = "Successfully connected";
                return true;
            }
            catch (Exception ex)
            {
                getmessage = "Connection error: " + ex.Message;
                return false;
            }
        }

        public bool disconnect()
        {
            try
            {
                conn_.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string getSingleValueSingleColumn(string query, out string columnData, int index)
        {
            string ret = null;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query;
                connect();
                reader_ = cmd_.ExecuteReader();
                while (reader_.Read())
                {
                    ret = reader_[index].ToString();
                }
                getmessage = "Successfully retrieved value";
            }
            catch (Exception e)
            {
                getmessage = "Error: " + e.Message;
            }
            finally
            {
                disconnect();
            }
            columnData = ret;
            return ret;
        }

        public string customInsertUpdateDelete(MySqlCommand cmd2parameterizednoconnectionNeeded)
        {
            string ret = "";
            string allQueries = cmd2parameterizednoconnectionNeeded.CommandText.ToLower();
            try
            {
                cmd2parameterizednoconnectionNeeded.Connection = conn_;
                connect();
                cmd2parameterizednoconnectionNeeded.ExecuteNonQuery();
                if (allQueries.Contains("insert into "))
                {
                    ret = getmessage = "Inserted Successfully!";
                }
                else if (allQueries.Contains("delete from "))
                {
                    ret = getmessage = "Deleted Successfully!";
                }
                else if (allQueries.Contains("create table "))
                {
                    ret = getmessage = "Table Created Successfully!";
                }
                else if (allQueries.Contains("update ") && allQueries.Contains("set="))
                {
                    ret = getmessage = "Updated Successfully";
                }
            }
            catch (Exception exp)
            {
                ret = getmessage = "Failed to execute " + cmd2parameterizednoconnectionNeeded.CommandText + "\nReason: " + exp.Message;
            }
            finally
            {
                disconnect();
            }
            return ret;
        }

        public string InsertUpdateDeleteCreate(string query)
        {
            string ret = "";
            string allQueries = query.ToLower();
            try
            {
                cmd_.CommandText = query;
                cmd_.Connection = conn_;
                connect();
                cmd_.ExecuteNonQuery();
                if (allQueries.Contains("insert into"))
                {
                    ret = getmessage = "Inserted successfully";
                }
                else if (allQueries.Contains("delete from"))
                {
                    ret = getmessage = "Delete successful";
                }
                else if (allQueries.Contains("update") && allQueries.Contains("set"))
                {
                    ret = getmessage = "Update successful";
                }
                else if (allQueries.Contains("create table"))
                {
                    ret = getmessage = "Create table successful";
                }
            }
            catch (Exception exp)
            {
                ret = getmessage = "Failed to execute " + query + "\nReason: " + exp.Message;
            }
            finally
            {
                disconnect();
            }
            return ret;
        }

        public string fillListView(string query, System.Windows.Forms.ListView dgv)
        {
            dtable_ = new System.Data.DataTable();
            string stret;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query;
                connect();
                adptr_.SelectCommand = cmd_;
                adptr_.Fill(dtable_);
                for (int i = 0; i < dtable_.Rows.Count; i++)
                {
                    DataRow dr = dtable_.Rows[i];
                    ListViewItem listItem = new ListViewItem(dr["Id"].ToString());
                    listItem.SubItems.Add(dr["Name"].ToString());
                    listItem.SubItems.Add(dr["Quantity"].ToString());
                    listItem.SubItems.Add(dr["PerUnitPrice"].ToString());
                    listItem.SubItems.Add(dr["Net Amount"].ToString());
                    dgv.Items.Add(listItem);
                }
                dgv.Refresh();
                stret = "Code executed successfully (fillListView() => DataAccess.cs)";
            }
            catch (Exception exp)
            {
                stret = "Failed (fillListView() => DataAccess.cs): " + exp.Message;
            }
            finally
            {
                disconnect();
                dtable_ = null;
            }
            return stret;
        }

        public string fillgridView(string query, System.Windows.Forms.DataGridView dgv)
        {
            dtable_ = new System.Data.DataTable();
            string stret;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query;
                connect();
                adptr_.SelectCommand = cmd_;
                adptr_.Fill(dtable_);
                dgv.DataSource = dtable_;
                dgv.Refresh();
                stret = "Code executed successfully (fillDataGridView() => DataAccess.cs)";
            }
            catch (Exception exp)
            {
                stret = "Failed (fillDataGridView() => DataAccess.cs): " + exp.Message;
            }
            finally
            {
                disconnect();
                dtable_ = null;
            }
            return stret;
        }

        public string getSingleValueAsArrayByIndex(string query, out List<string> columnData, int index)
        {
            List<string> data = new List<string>();
            string ret;
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query.ToLower();
                connect();
                reader_ = cmd_.ExecuteReader();
                while (reader_.Read())
                {
                    data.Add(reader_[index].ToString());
                }
                ret = "Operation Successful!";
                getmessage = "Values successfully retrieved from getSingleValueAsArrayByIndex() function";
            }
            catch (Exception exp)
            {
                ret = "Error in DataAccess -> getSingleValueAsArrayByIndex() Reason: " + exp.Message;
                getmessage = "Error in DataAccess getSingleValueAsArrayByIndex() for reader_\n" + exp.Message;
                data.Clear();
            }
            finally
            {
                disconnect();
            }
            columnData = data;
            return ret;
        }

        public void fillComboBox(string query, System.Windows.Forms.ComboBox cmd)
        {
            int i = 0;
            List<string> lst = new List<string>();
            getSingleValueAsArrayByIndex(query, out lst, 0);
            foreach (string val in lst)
            {
                if (val.Length > 0)
                {
                    cmd.Items.Add(val);
                    i++;
                }
            }
            if (i > 0)
            {
                cmd.SelectedIndex = 0;
            }
        }

        public string[] getArray(string query, int length)
        {
            string[] ret = new string[length];
            try
            {
                cmd_.Connection = conn_;
                cmd_.CommandText = query;
                connect();
                reader_ = cmd_.ExecuteReader();
                while (reader_.Read())
                {
                    for (int i = 0; i < reader_.FieldCount; i++)
                    {
                        ret[i] = reader_[i].ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                disconnect();
            }
            return ret;
        }
    }
}
