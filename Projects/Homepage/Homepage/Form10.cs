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
    public partial class chat : Form
    {
        string fuser;
        string c;
        string euser;
        public chat()
        {
            InitializeComponent();
            view();
           
        }
        void view1()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("EMAIL", 80);
            listView1.Columns.Add("CHAT", 200);
            listView1.View = View.Details;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con2.Open();
            if (welcome.ptext3 == "HEAD")
            {
                OleDbCommand cmd2 = new OleDbCommand("select [fperson],chat from chats where societyname='" + welcome.ptext1 + "' AND ((fperson='" + fuser + "' AND enduser='" + euser + "') OR (fperson='" + euser + "' AND enduser='" + fuser + "'))", con2);
                OleDbDataReader rd2 = cmd2.ExecuteReader();
                listView1.Items.Clear();
                while (rd2.Read())
                {
                    ListViewItem lv1 = new ListViewItem(rd2.GetString(0).ToString());
                    try
                    { lv1.SubItems.Add(rd2.GetString(1).ToString()); }
                    catch { }
                    listView1.Items.Add(lv1);
                }
                rd2.Close();
            
            }
            else if (welcome.ptext3 == "MEMBER")
            {
                OleDbCommand cmd2 = new OleDbCommand("select [fperson],chat from chats where societyname='" + home.ftext1 + "' AND ((fperson='" + fuser + "' AND enduser='" + euser + "') OR (fperson='" + euser + "' AND enduser='" + fuser + "'))", con2);
                OleDbDataReader rd2 = cmd2.ExecuteReader();
                listView1.Items.Clear();
                while (rd2.Read())
                {
                    ListViewItem lv1 = new ListViewItem(rd2.GetString(0).ToString());
                    try
                    { lv1.SubItems.Add(rd2.GetString(1).ToString()); }
                    catch { }
                    listView1.Items.Add(lv1);
                }
                rd2.Close();
            
            }
            con2.Close();
            
        }
        void view()
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox1.Items.Clear();
            if (welcome.ptext3 == "MEMBER")
            {
                OleDbCommand cmd = new OleDbCommand("SELECT [EMAIL] FROM records WHERE societyname='" + home.ftext1 + "' AND NOT EMAIL='" + welcome.ptext2 + "'", con);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd.GetString(0).ToString());
                }
                rd.Close();
            }
            else if (welcome.ptext3 == "HEAD")
            {
                OleDbCommand cmd = new OleDbCommand("SELECT [EMAIL] FROM records WHERE societyname='" + welcome.ptext1 + "' AND NOT EMAIL='" + welcome.ptext2 + "'", con);
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    comboBox1.Items.Add(rd.GetString(0).ToString());
                }
                rd.Close();
            }
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            fuser = welcome.ptext2;
            euser = comboBox1.Text;
            c = textBox1.Text;
            con.Open();
            if (welcome.ptext3 == "MEMBER")
            {
                cmd.CommandText = "Insert into chats ([fperson],[enduser],[chat],[societyname]) values ('" + fuser + "','" + euser + "','" + c + "','" + home.ftext1 + "')";
                cmd.ExecuteNonQuery();
            }
            else if (welcome.ptext3 == "HEAD")
            {
                cmd.CommandText = "Insert into chats ([fperson],[enduser],[chat],[societyname]) values ('" + fuser + "','" + euser + "','" + c + "','" + welcome.ptext1 + "')";
                cmd.ExecuteNonQuery();
            }
            con.Close();
            textBox1.Clear();
            view1();
        }

       

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            fuser = welcome.ptext2;
            euser = comboBox1.Text;
            view1();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (welcome.ptext3 == "HEAD")
            {
                this.Hide();
                Head h = new Head();
                h.Show();
            }
            else
            {
                this.Hide();
                Go g = new Go();
                g.Show();
            }
        }
    }
}
