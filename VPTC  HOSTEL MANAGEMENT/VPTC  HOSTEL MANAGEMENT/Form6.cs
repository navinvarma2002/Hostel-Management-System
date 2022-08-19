using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace VPTC__HOSTEL_MANAGEMENT
{
    public partial class Form6 : Form
    {
        int count = 0;
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nav In\OneDrive\Documents\Visual Studio 2010\Projects\VPTC  HOSTEL MANAGEMENT\VPTC  HOSTEL MANAGEMENT\HOSTEL VPTC.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;

        private void Form6_Load(object sender, EventArgs e)
        {
            load();
        }

        public void load()
        {
            sql = "select * from WR";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (dr.Read())
            {


                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5]);


            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select Employeeid from WR where Employeeid = '" + txtEmployeeid.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("This EmployeeID was alredy Alloted");
            }
            else  if (txtEmployeeid.Text == "" || txtEmployeeName.Text == "" || txtContactNumber.Text == "" || txtAddress.Text == "" || txtCity.Text == "" || txtEmployeeWork.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {
                try
                {
                    string Employeeid, EmployeeName, ContactNumber, Address, City, EmployeeWork;

                    Employeeid = txtEmployeeid.Text;
                    EmployeeName = txtEmployeeName.Text;
                    ContactNumber = txtContactNumber.Text;
                    Address = txtAddress.Text;
                    City = txtCity.Text;
                    EmployeeWork = txtEmployeeWork.Text;

                    sql = "insert into WR(Employeeid, EmployeeName, ContactNumber, Address, City, EmployeeWork)values(?,?,?,?,?,?)";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("Employeeid", Employeeid);
                    cmd.Parameters.AddWithValue("EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("ContactNumber", ContactNumber);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue(" City", City);
                    cmd.Parameters.AddWithValue("EmployeeWork", EmployeeWork);

                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Submited Successfully ");
                    con.Close();
                    load();
                    txtEmployeeid.Clear();
                    txtEmployeeName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    txtCity.Clear();
                 


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sql = "select * from WR where Employeeid= ?";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("Employeeid", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                txtEmployeeid.Text = dr[0].ToString();
                txtEmployeeName.Text = dr[1].ToString();
                txtContactNumber.Text = dr[2].ToString();
                txtAddress.Text = dr[3].ToString();
                txtCity.Text = dr[4].ToString();
                txtEmployeeWork.Text = dr[5].ToString();
                
              
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtEmployeeid.Text == "" || txtEmployeeName.Text == "" || txtContactNumber.Text == "" || txtAddress.Text == "" || txtCity.Text == "" || txtEmployeeWork.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {
                try
                {
                    string Employeeid, EmployeeName, ContactNumber, Address, EmployeeWork;

                    Employeeid = txtEmployeeid.Text;
                    EmployeeName = txtEmployeeName.Text;
                    ContactNumber = txtContactNumber.Text;
                    Address = txtAddress.Text;
                    EmployeeWork = txtEmployeeWork.Text;

                    sql = "update WR  set Employeeid = ?, EmployeeName = ?, ContactNumber = ?, Address = ?, EmployeeWork = ? where Employeeid = ?";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("Employeeid", Employeeid);
                    cmd.Parameters.AddWithValue("EmployeeName", EmployeeName);
                    cmd.Parameters.AddWithValue("ContactNumber", ContactNumber);
                    cmd.Parameters.AddWithValue("Address", Address);
                    cmd.Parameters.AddWithValue("EmployeeWork", EmployeeWork);

                    cmd.Parameters.AddWithValue("Employeeid", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Submited Successfully ");
                    con.Close();
                    load();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from WR where   Employeeid ='" + textBox5.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            count = Convert.ToInt32(dt.Rows.Count.ToString());
            dataGridView2.DataSource = dt;
            con.Close();


            if (count == 0)
            {
                MessageBox.Show("record not found");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }
    }
}
