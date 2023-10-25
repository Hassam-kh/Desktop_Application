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
    public partial class Head : Form
    {
        public Head()
        {
            InitializeComponent();
            view();
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
            OleDbCommand cmd = new OleDbCommand("select EMAIL,asa,societyname from Head where societyname='" + welcome.ptext1 + "'", con);
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
            listView2.Columns.Add("Email", 100);
            listView2.Columns.Add("AS A", 100);
            listView2.Columns.Add("Society", 100);
            listView2.View = View.Details;
            OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con2.Open();
            string m = "Member";
            OleDbCommand cmd2 = new OleDbCommand("select EMAIL,asa,societyname from records where asa='" + m + "' AND societyname='" + welcome.ptext1 +"'", con2);
            OleDbDataReader rd2 = cmd2.ExecuteReader();
            listView2.Items.Clear();
            while (rd2.Read())
            {
                ListViewItem lv2 = new ListViewItem(rd2.GetString(0).ToString());
                lv2.SubItems.Add(rd2.GetString(1).ToString());
                lv2.SubItems.Add(rd2.GetString(2).ToString());

                listView2.Items.Add(lv2);
            }
            rd2.Close();
            con2.Close();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            
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
           
                cmd.CommandText = "Insert into records ([USERNAME],[PASSWORD],[Names],[EMAIL],[societyname],[asa]) SELECT USERNAME,[PASSWORD],Names,EMAIL,societyname,asa FROM Head where EMAIL='" + em + "'";
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
                cmd1.CommandText = "DELETE FROM Head WHERE EMAIL='" + em + "'";
                cmd1.ExecuteNonQuery();
            
            con1.Close();
            view();
        }

        private void listView1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome obj = new welcome();
            obj.Show();
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
            cmd1.CommandText = "DELETE FROM records WHERE EMAIL='" + em1 + "'";
            cmd1.ExecuteNonQuery();

            con1.Close();
            view();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            SE.events ev = new SE.events();
            ev.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Task t = new Task();
            t.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            chat c = new chat();
            c.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string ann = textBox1.Text;
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "Insert into announ ([society],[email],[ann]) values ('" + welcome.ptext1 + "','" + welcome.ptext2 + "','" + ann + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("ADDED");
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            ann a = new ann();
            a.Show();
        }
    }
}
