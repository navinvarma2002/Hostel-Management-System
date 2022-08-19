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
    public partial class Form5 : Form
    {
        int count = 0;
        public Form5()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nav In\OneDrive\Documents\Visual Studio 2010\Projects\VPTC  HOSTEL MANAGEMENT\VPTC  HOSTEL MANAGEMENT\HOSTEL VPTC.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;

        private void Form5_Load(object sender, EventArgs e)
        {
        }
      

        private void button1_Click(object sender, EventArgs e)
        {

            if (txtStudentName.Text == "" || txtYer.Text == "" || txtDepartment.Text == "" || txtContactNumber.Text == "" || txtAddress.Text == "" || txtDte.Text == "" || txtTimein.Text == "" || txtTimeout.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {

                try
                {
                    string StudentName, Yer, Department, Relationship, ContactNumber, Address, Dte, City, Timein, Timeout;

                    StudentName = txtStudentName.Text;
                    Yer = txtYer.Text;
                    Department = txtDepartment.Text;
                    Relationship = txtRelationship.Text;
                    ContactNumber = txtContactNumber.Text;                   
                    Address = txtAddress.Text;
                    City = textBox2.Text;
                    Dte = txtDte.Text;
                    Timein = txtTimein.Text;
                    Timeout = txtTimeout.Text;


                    sql = "insert into VD(StudentName, Yer, Department, Relationship, ContactNumber, Address, City, Dte, Timein, Timeout)values(?,?,?,?,?,?,?,?,?,?)";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("StudentName", StudentName);
                    cmd.Parameters.AddWithValue("Yer", Yer);
                    cmd.Parameters.AddWithValue("Department", Department);
                    cmd.Parameters.AddWithValue(" Relationship", Relationship);
                    cmd.Parameters.AddWithValue("ContactNumber", ContactNumber);
                    cmd.Parameters.AddWithValue(" Address", Address);
                    cmd.Parameters.AddWithValue(" City", City);
                    cmd.Parameters.AddWithValue("Dte", Dte);
                    cmd.Parameters.AddWithValue("Timein", Timein);
                    cmd.Parameters.AddWithValue("Timeout", Timeout);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Submited Successfully ");
                    con.Close();
                    txtStudentName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    textBox2.Clear();
                    txtDte.Clear();
              

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            txtDte.Text = Convert.ToString(dateTimePicker1.Value.Date);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from ROOMALLOTMENT where   studentName ='" + textBox1.Text + "'";
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Form2 f2 = new Form2();
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
