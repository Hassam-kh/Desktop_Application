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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            view();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        void view()
        {
            listView1.Items.Clear();
            listView1.Columns.Clear();
            listView1.Columns.Add("Email", 100);
            listView1.Columns.Add("AS A", 100);
            listView1.Columns.Add("Society", 100);
            listView1.View = View.Details;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select EMAIL,asa,societyname from Society", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                ListViewItem lv = new ListViewItem(rd.GetString(0).ToString());
                lv.SubItems.Add(rd.GetString(1).ToString());
                lv.SubItems.Add(rd.GetString(2).ToString());

                listView1.Items.Add(lv);
            }
            rd.Close();
            con.Close();
            listView2.Items.Clear();
            listView2.Columns.Clear();
            listView2.Columns.Add("Event", 100);
            listView2.Columns.Add("Start Date", 100);
            listView2.Columns.Add("Society", 100);
            listView2.View = View.Details;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con2.Open();
            OleDbCommand cmd2 = new OleDbCommand("select event,startdate,societyname from events", con2);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            listView2.Items.Clear();
            while (rd2.Read())
            {
                ListViewItem lv2 = new ListViewItem(rd2.GetString(0).ToString());
                lv2.SubItems.Add(rd2.GetDateTime(1).ToString());
                lv2.SubItems.Add(rd2.GetString(2).ToString());

                listView2.Items.Add(lv2);
            }
            rd2.Close();
            con2.Close();

            listView3.Items.Clear();
            listView3.Columns.Clear();
            listView3.Columns.Add("Event", 100);
            listView3.Columns.Add("Start Date", 100);
            listView3.Columns.Add("Society", 100);
            listView3.View = View.Details;
            OleDbConnection con3 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con3.Open();
            OleDbCommand cmd3 = new OleDbCommand("select event,startdate,societyname from Admin", con3);
            OleDbDataReader rd3 = cmd3.ExecuteReader();
            while (rd3.Read())
            {
                ListViewItem lv = new ListViewItem(rd3.GetString(0).ToString());
                lv.SubItems.Add(rd3.GetDateTime(1).ToString());
                lv.SubItems.Add(rd3.GetString(2).ToString());

                listView3.Items.Add(lv);
            }
            rd.Close();
            con.Close();
            /*/
             void view()
        {
            
        }/*/
        }
        private void listView1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            var f = listView1.SelectedItems[0];
            string em = f.ToString();
            em = em.Substring(15);
            em = em.Remove(em.Length - 1, 1);

            cmd.CommandText = "Insert into records ([USERNAME],[PASSWORD],[Names],[EMAIL],[societyname],[asa]) SELECT USERNAME,[PASSWORD],Names,EMAIL,societyname,asa FROM Society where EMAIL='" + em + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("APPROVED");
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd1 = con1.CreateCommand();
            con1.Open();
            var f1 = listView1.SelectedItems[0];
            string em1 = f1.ToString();
            em1 = em1.Substring(15);
            em1 = em1.Remove(em1.Length - 1, 1);
            cmd1.CommandText = "DELETE FROM Society WHERE EMAIL='" + em + "'";
            cmd1.ExecuteNonQuery();

            con1.Close();
            view();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome w = new welcome();
            w.Show();
        }

        private void listView2_Click(object sender, EventArgs e)
        {
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd1 = con1.CreateCommand();
            con1.Open();
            var f1 = listView2.SelectedItems[0];
            string em1 = f1.ToString();
            em1 = em1.Substring(15);
            em1 = em1.Remove(em1.Length - 1, 1);
            MessageBox.Show("REMOVED");
            cmd1.CommandText = "DELETE FROM events WHERE event='" + em1 + "'";
            cmd1.ExecuteNonQuery();

            con1.Close();
            view();
        }

        private void listView3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            var f = listView3.SelectedItems[0];
            string em = f.ToString();
            em = em.Substring(15);
            em = em.Remove(em.Length - 1, 1);

            cmd.CommandText = "Insert into events ([event],[enddate],[startdate],[societyname],[budget],[disc]) SELECT [event],[enddate],[startdate],[societyname],[budget],[disc] FROM Admin where event='" + em + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("APPROVED");
            OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd1 = con1.CreateCommand();
            con1.Open();
            var f1 = listView3.SelectedItems[0];
            string em1 = f1.ToString();
            em1 = em1.Substring(15);
            em1 = em1.Remove(em1.Length - 1, 1);
            cmd1.CommandText = "DELETE FROM Admin WHERE event='" + em + "'";
            cmd1.ExecuteNonQuery();

            con1.Close();
            view();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            chat c = new chat();
            c.Show();
        }
    }
}
