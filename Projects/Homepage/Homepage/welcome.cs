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
    public partial class welcome : Form
    {

        public static string ptext1 = "";
        public static string ptext2 = "";
        public static string ptext3 = "";
        public welcome()
        {
            InitializeComponent();
            view();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
       
            this.Hide();
            Form1 o = new Form1();
            o.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            string uname;
            string passw;
            string POS;
            uname = textBox2.Text;
            passw = textBox4.Text;
            POS = comboBox1.Text;
            if (uname != "" && passw != "" && !uname.Contains(" ") && POS != "")
            {
                OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
                OleDbCommand cmd = con.CreateCommand();
                con.Open();
                cmd.CommandText = "Select  * from records where EMAIL='" + uname + "' AND PASSWORD='" + passw + "' AND asa='" + POS + "'";
                OleDbDataReader reader = cmd.ExecuteReader();
                if (POS == "ADMIN")
                {
                    if (uname == "admin@nu.edu.pk" && passw == "fsms")
                    {
                        this.Hide();
                        Admin ob = new Admin();
                        ob.Show();
                    }
                    else
                    {
                        MessageBox.Show("INVALID");
                    }
                }
                else if (reader.Read())
                {
                    ptext3 = POS;
                    ptext2 = reader.GetString(2).ToString();
                    if (POS == "HEAD")
                    {
                        ptext1 = reader.GetString(6).ToString();
                        this.Hide();
                        Head ob = new Head();
                        ob.Show();
                    }
                    else
                    {
                        ptext1 = reader.GetString(6).ToString();
                        this.Hide();
                        home obj = new home();
                        obj.Show();
                    }
                }
                else
                {
                    MessageBox.Show("INVALID : KINDLY RECHECK");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Kindly Fill Neccessary INFo");
            }
        }
        void view()
        {
            
            listView1.Columns.Add("Society--Names", 150);
            listView1.View = View.Details;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\dortemon\\Documents\\Visual Studio 2012\\Visual Studio 2012\\Projects\\SE Project.accdb;Extended Properties='Excel 12.0 Xml;HDR=YES';\r\n");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT societyname FROM records", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd.GetString(0).ToString());
                lv.SubItems.Add(rd.GetString(0).ToString());
                    listView1.Items.Add(lv);
            }
            rd.Close();
            con.Close();
            
        }

        private void listView1_SelectedIndexChanged_3(object sender, EventArgs e)
        {
            
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void monthCalendar2_DateSelected(object sender, DateRangeEventArgs e)
        {
            this.monthCalendar2.Visible = true;
            string str = monthCalendar2.SelectionStart.Date.ToString();
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("Upcoming Events:", 150);
            listView2.View = View.Details;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select event from events where startdate=#" + DateTime.Parse(str).ToString("MM/dd/yyyy") + "# ", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            
            while (rd.Read())
            {
                
                ListViewItem lv = new ListViewItem(rd.GetString(0).ToString());
                lv.SubItems.Add(rd.GetString(0).ToString());

                listView2.Items.Add(lv);
            }
            rd.Dispose();
            con.Close();
        }

        private void monthCalendar2_DateChanged(object sender, DateRangeEventArgs e)
        {

        }


    }
}
