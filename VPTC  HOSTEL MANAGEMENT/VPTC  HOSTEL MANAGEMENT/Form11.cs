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
    public partial class Form11 : Form
    {
        public Form11(string value)
        {
            InitializeComponent();
            textBox1.Text = value;
        }

        public Form11()
        {
           
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nav In\OneDrive\Documents\Visual Studio 2010\Projects\VPTC  HOSTEL MANAGEMENT\VPTC  HOSTEL MANAGEMENT\HOSTEL VPTC.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;



        private void Form11_Load(object sender, EventArgs e)
        {
            load();
        }
                                                                                                                  
        public void load()
        {
            sql = "select * from  ROOMALLOTMENT";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView2.Rows.Clear();

            while (dr.Read())
            {


                dataGridView2.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4]);


            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter da = new OleDbDataAdapter("select RoomNo from ROOMALLOTMENT where RoomNo = '" + txtRoomNo.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("This Room was alredy Alloted");
            }

            else if (textBox1.Text == "" || txtyer.Text == "" || txtDept.Text == "" || txtRoomNo.Text == "" || txtRoomStatus.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {
                try
                {
                    string studentName, yer, Dept, RoomNo, RoomStatus;

                    studentName = textBox1.Text;
                    yer = txtyer.Text;
                    Dept = txtDept.Text;
                    RoomNo = txtRoomNo.Text;
                    RoomStatus = txtRoomStatus.Text;

                    sql = "insert into ROOMALLOTMENT(studentName, yer, Dept, RoomNo, RoomStatus)values(?,?,?,?,?)";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("studentName", studentName);
                    cmd.Parameters.AddWithValue("yer", yer);
                    cmd.Parameters.AddWithValue("Dept", Dept);
                    cmd.Parameters.AddWithValue("RoomNo", RoomNo);
            
                    cmd.Parameters.AddWithValue("RoomStatus", RoomStatus);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Room Alloted Successfully ");
                    con.Close();
                    load();
                    textBox1.Clear();
                    txtRoomNo.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sql = "select * from  ROOMALLOTMENT where studentName= ?";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("studentName", dataGridView2.CurrentRow.Cells[0].Value.ToString());

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                txtyer.Text = dr[1].ToString();
                txtDept.Text = dr[2].ToString();
                txtRoomNo.Text = dr[3].ToString();
                txtRoomStatus.Text = dr[4].ToString();
            }
            con.Close();
        }

      

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select STUDENTNAME, YER, DEPARTMENT from SR";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
