using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Homepage
{
    public partial class Task : Form
    {
        public Task()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Head h = new Head();
            h.Show();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox1.Items.Clear();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT event FROM events where societyname='" + Homepage.welcome.ptext1 + "'", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd.GetString(0).ToString());
            }
            rd.Close();
            con.Close();
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            string asa1 = "Member";
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox2.Items.Clear();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT [EMAIL] FROM records where societyname='" + Homepage.welcome.ptext1 + "' AND asa='" + asa1 + "'", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox2.Items.Add(rd.GetString(0).ToString());
            }
            rd.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            string email = comboBox2.Text;
            string task = textBox2.Text;
            string event1 = comboBox1.Text;
            con.Open();
            cmd.CommandText = "UPDATE records SET [event]='" + event1 + "',[tasks]='" + task + "' where EMAIL='" + email + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            this.Hide();
            Head obj = new Head();
            obj.Show();
        }
    }
}