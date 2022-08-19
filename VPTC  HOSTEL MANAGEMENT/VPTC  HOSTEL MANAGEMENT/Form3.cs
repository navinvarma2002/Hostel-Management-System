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
    public partial class Form3 : Form
    {
        int count = 0;
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nav In\OneDrive\Documents\Visual Studio 2010\Projects\VPTC  HOSTEL MANAGEMENT\VPTC  HOSTEL MANAGEMENT\HOSTEL VPTC.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtYER.Text == "" || txtDEPARTMENT.Text == "" || txtBATCHOFYEAR.Text == "" || txtHOSTELFEES.Text == "" || txtMESSFEES.Text == "" || textBox2.Text == "" || txtSTATUS.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {
                try
                {
                    string STUDENTNAME, YER, DEPARTMENT, BATCHOFYEAR, HOSTELFEES, MESSFEES, TOTALAMOUNT, STATUS;

                    STUDENTNAME = textBox1.Text;
                    YER = txtYER.Text;
                    DEPARTMENT = txtDEPARTMENT.Text;
                    BATCHOFYEAR = txtBATCHOFYEAR.Text;
                    HOSTELFEES = txtHOSTELFEES.Text;
                    MESSFEES = txtMESSFEES.Text;
                    TOTALAMOUNT = textBox2.Text;

                    STATUS = txtSTATUS.Text;


                    sql = "insert into SR(STUDENTNAME, YER, DEPARTMENT, BATCHOFYEAR, HOSTELFEES, MESSFEES,TOTALAMOUNT, STATUS)values(?,?,?,?,?,?,?,?)";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("STUDENTNAME", STUDENTNAME);
                    cmd.Parameters.AddWithValue(" YER", YER);
                    cmd.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);
                    cmd.Parameters.AddWithValue(" BATCHOFYEAR", BATCHOFYEAR);
                    cmd.Parameters.AddWithValue("HOSTELFEES", HOSTELFEES);
                    cmd.Parameters.AddWithValue(" MESSFEES", MESSFEES);
                    cmd.Parameters.AddWithValue("TOTALAMOUNT", TOTALAMOUNT);
                    cmd.Parameters.AddWithValue("STATUS", STATUS);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Student Registered and Fees payment Was Finished Successfully ");
                    con.Close();
                    load();
                    txtBATCHOFYEAR.Clear();
                    txtHOSTELFEES.Clear();
                    txtMESSFEES.Clear();
                    textBox2.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            sql = "select * from SR";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (dr.Read())
            {


                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3], dr[4], dr[5], dr[6],dr[7]);


            }
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sql = "select * from  SR where STUDENTNAME= ?";
            cmd = new OleDbCommand(sql, con);
            cmd.Parameters.AddWithValue("STUDENTNAME", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                txtYER.Text = dr[1].ToString();
                txtDEPARTMENT.Text = dr[2].ToString();
                txtBATCHOFYEAR.Text = dr[3].ToString();
                txtHOSTELFEES.Text = dr[4].ToString();
                txtMESSFEES.Text = dr[5].ToString();
                textBox2.Text = dr[6].ToString();
                txtSTATUS.Text = dr[7].ToString();
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || txtYER.Text == "" || txtDEPARTMENT.Text == "" || txtBATCHOFYEAR.Text == "" || txtHOSTELFEES.Text == "" || txtMESSFEES.Text == "" || textBox2.Text == "" || txtSTATUS.Text == "")
            {
                MessageBox.Show("please Fill the data");
            }
            else
            {
                try
                {
                    string STUDENTNAME, YER, DEPARTMENT, BATCHOFYEAR, HOSTELFEES, MESSFEES, TOTALAMOUNT, STATUS;

                    STUDENTNAME = textBox1.Text;
                    YER = txtYER.Text;
                    DEPARTMENT = txtDEPARTMENT.Text;
                    BATCHOFYEAR = txtBATCHOFYEAR.Text;
                    HOSTELFEES = txtHOSTELFEES.Text;
                    MESSFEES = txtMESSFEES.Text;
                    TOTALAMOUNT = textBox2.Text;
                    STATUS = txtSTATUS.Text;


                    sql = "update SR  set STUDENTNAME = ?, YER= ?, DEPARTMENT= ?, BATCHOFYEAR= ?, HOSTELFEES= ?, MESSFEES= ?, TOTALAMOUNT = ?,STATUS = ? where STUDENTNAME = ?";
                    cmd = new OleDbCommand(sql, con);
                    con.Open();
                    cmd.Parameters.AddWithValue("STUDENTNAME", STUDENTNAME);
                    cmd.Parameters.AddWithValue(" YER", YER);
                    cmd.Parameters.AddWithValue("DEPARTMENT", DEPARTMENT);
                    cmd.Parameters.AddWithValue(" BATCHOFYEAR", BATCHOFYEAR);
                    cmd.Parameters.AddWithValue("HOSTELFEES", HOSTELFEES);
                    cmd.Parameters.AddWithValue(" MESSFEES", MESSFEES);
                    cmd.Parameters.AddWithValue("TOTALAMOUNT", TOTALAMOUNT);
                    cmd.Parameters.AddWithValue("STATUS", STATUS);
                    cmd.Parameters.AddWithValue("STUDENTNAME", dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" Updated Successfully ");
                    con.Close();
                    load();
                    textBox1.Clear();
                    txtBATCHOFYEAR.Clear();
                    txtHOSTELFEES.Clear();
                    txtMESSFEES.Clear();
                    textBox2.Clear();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            con.Open();
            OleDbCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from SR where   STUDENTNAME ='" + textBox5.Text + "'";
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form11 frm = new Form11(textBox1.Text);
            frm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GET_Click(object sender, EventArgs e)
        {
            try
            {
                int a = Convert.ToInt32(txtHOSTELFEES.Text);
                int b = Convert.ToInt32(txtMESSFEES.Text);

                int sum = a + b ;
                textBox2.Text = Convert.ToString(sum);

            }
            catch (Exception ex) { }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
