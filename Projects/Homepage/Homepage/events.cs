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
namespace SE
{
    public partial class events : Form
    {
        public events()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string sname = comboBox1.Text;
            string ename = textBox1.Text;
            string des = textBox2.Text;
            string sdate = dateTimePicker1.Value.Date.ToString();
            string nsdate="";
            string nedate="";
            for (int i = 0; i < sdate.Length; i++)
            {
                if (sdate[i] != ' ')
                {
                    nsdate = nsdate + sdate[i];
                }
                else { break; }
            }
            string edate = dateTimePicker2.Value.Date.ToString();
            for (int i = 0; i < edate.Length; i++)
            {
                if (edate[i] != ' ')
                {
                    nedate = nedate + edate[i];
                }
                else { break; }
            }
            string budget = numericUpDown1.Value.ToString();


            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd1 = con1.CreateCommand();
            con1.Open();
            cmd1.CommandText = "Select event from Admin where event='" + ename + "'";
            OleDbDataReader reader1 = cmd1.ExecuteReader();
            if (!reader1.Read())
            {
                


                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
                OleDbCommand cmd = con.CreateCommand();
                if (ename != "" && sdate != "" && edate != "" && budget != "" && sname != "" && des != "")
                {
                    con.Open();
                    cmd.CommandText = "Insert into Admin ([event],[enddate],[societyname],[startdate],[budget],[disc]) values ('" + ename + "','" + nedate + "','" + sname + "','" + nsdate + "','" + budget + "','" + des + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("YOUR REQUEST IS SENT TO Admin FOR APPROVAL");
                }
                else
                {
                    MessageBox.Show("KINDLY FILL THE NECESSARY INFORMATION");
                }
            }
            else
            {
                MessageBox.Show("EVENT ALREADY EXIT");
            }
            con1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage.Head obj = new Homepage.Head();
            obj.Show();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox1.Items.Clear();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT societyname FROM records where societyname='" + Homepage.welcome.ptext1 + "'", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd.GetString(0).ToString());
            }
            rd.Close();
            con.Close();
        }
        

        private void listView2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Homepage.Head obj = new Homepage.Head();
            obj.Show();
        }
    }
}
