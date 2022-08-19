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
    public partial class Form7 : Form
    {
        int count = 0;
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Nav In\OneDrive\Documents\Visual Studio 2010\Projects\VPTC  HOSTEL MANAGEMENT\VPTC  HOSTEL MANAGEMENT\HOSTEL VPTC.accdb");
        OleDbCommand cmd;
        OleDbDataReader dr;
        string sql;

        private void Form7_Load(object sender, EventArgs e)
        {
            load();
        }
        public void load()
        {
            sql = "select * from ROOMALLOTMENT";
            cmd = new OleDbCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            con.Close();


            int count = dataGridView1.RowCount;
            textBox1.Text = count.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    

   
  
