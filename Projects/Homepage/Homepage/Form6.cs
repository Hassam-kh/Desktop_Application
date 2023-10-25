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
    public partial class ann : Form
    {
        public ann()
        {
            InitializeComponent();
            view();
        }
        void view(){
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("HEAD", 100);
            listView1.Columns.Add("SOCIETY", 100);
            listView1.Columns.Add("ANNOUNCEMENTS", 300);
            listView1.View = View.Details;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con2.Open();
            if (welcome.ptext3 == "MEMBER")
            {
                OleDbCommand cmd2 = new OleDbCommand("select email,society,ann from announ where society='" + home.ftext1 + "'", con2);
                OleDbDataReader rd2 = cmd2.ExecuteReader();
                listView1.Items.Clear();
                while (rd2.Read())
                {
                    ListViewItem lv1 = new ListViewItem(rd2.GetString(0).ToString());
                    lv1.SubItems.Add(rd2.GetString(1).ToString());
                    lv1.SubItems.Add(rd2.GetString(2).ToString());
                    listView1.Items.Add(lv1);
                }
                rd2.Close();
            }
            else
            {
                OleDbCommand cmd2 = new OleDbCommand("select email,society,ann from announ where society='" + welcome.ptext1 + "'", con2);
                OleDbDataReader rd2 = cmd2.ExecuteReader();
                listView1.Items.Clear();
                while (rd2.Read())
                {
                    ListViewItem lv1 = new ListViewItem(rd2.GetString(0).ToString());
                    lv1.SubItems.Add(rd2.GetString(1).ToString());
                    lv1.SubItems.Add(rd2.GetString(2).ToString());
                    listView1.Items.Add(lv1);
                }
                rd2.Close();
            }
            
            
            con2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (welcome.ptext3 == "MEMBER")
            {
                this.Hide();
                Go g = new Go();
                g.Show();
            }
            else
            {
                this.Hide();
                Head h = new Head();
                h.Show();
            }
        }
    }
}
