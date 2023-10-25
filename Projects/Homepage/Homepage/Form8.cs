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
    public partial class Go : Form
    {
        public Go()
        {
            InitializeComponent();
            view();
        }
        void view()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("NAME", 100);
            listView1.Columns.Add("AS A", 100);
            listView1.Columns.Add("TASKS", 100);
            listView1.View = View.Details;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con2.Open();
            OleDbCommand cmd2 = new OleDbCommand("select [Names],asa,tasks from records where societyname='" + home.ftext1 + "'", con2);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            listView1.Items.Clear();
            while (rd2.Read())
            {
                ListViewItem lv1 = new ListViewItem(rd2.GetString(0).ToString());
                try
                { lv1.SubItems.Add(rd2.GetString(1).ToString()); }
                catch { }
                try
                { lv1.SubItems.Add(rd2.GetString(2).ToString()); }
                catch { }
                listView1.Items.Add(lv1);
            }
            rd2.Close();
            con2.Close();
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("EVENT", 100);
            listView2.Columns.Add("TASK", 300);
            listView2.View = View.Details;
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con1.Open();
            string m = "Member";
            OleDbCommand cmd1 = new OleDbCommand("select event,tasks from records where asa='" + m + "' AND societyname='" + home.ftext1 + "' AND EMAIL='" + welcome.ptext2 + "'", con1);
            OleDbDataReader rd1 = cmd1.ExecuteReader();
            listView2.Items.Clear();
            while (rd1.Read())
            {
                try
                {
                    ListViewItem lv2 = new ListViewItem(rd1.GetString(0).ToString());
                    try
                    { lv2.SubItems.Add(rd1.GetString(1).ToString()); }
                    catch { }
                    try
                    { lv2.SubItems.Add(rd1.GetString(2).ToString()); }
                    catch { }
                    listView2.Items.Add(lv2);
                }
                catch { }
                
            }
            rd1.Close();
            con1.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome W = new welcome();
            W.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            home H = new home();
            H.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            chat c = new chat();
            c.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            ann a = new ann();
            a.Show();
        }
        
    }
}
