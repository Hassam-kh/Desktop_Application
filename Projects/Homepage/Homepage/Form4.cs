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
    public partial class Society : Form
    {
        public Society()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            string username = textBox2.Text;
            string password = textBox4.Text;
            string name = textBox1.Text;
            string email = textBox3.Text;
            string reason = textBox6.Text;
            string society = textBox5.Text;
            string asa = "Head";
            if (username != "" && password != "" && name != "" && email != "" && society != "" && asa != "")
            {
                if (email.Contains("@nu.edu.pk") && email != "admin@nu.edu.pk" && !email.Contains(" ") && !(email.Length < 17) && !(password.Length < 7))
                {
                    OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
                        OleDbCommand cmd2 = con2.CreateCommand();
                        con2.Open();
                        cmd2.CommandText = "Select  EMAIL from records where EMAIL='" + email + "' OR societyname='" + society + "'";
                        OleDbDataReader reader1 = cmd2.ExecuteReader();
                        if (!reader1.Read())
                        {
                            con.Open();
                            cmd.CommandText = "Insert into Society ([USERNAME],[PASSWORD],[Names],[EMAIL],[societyname],[asa],[reason]) values ('" + username + "','" + password + "','" + name + "','" + email + "','" + society + "','" + asa + "','" + reason + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("YOUR REQUEST IS SENT TO Admin FOR APPROVAL");
                            this.Hide();
                            welcome obj = new welcome();
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("USER ALREADY A MEMBER/HEAD OR SOCIETY ALREADY EXSIST");
                        }
                }
                else
                {
                    MessageBox.Show("KINDLY REGISTER FROM NUCES GIVEN MAIL/ DON'T USE OFFICAL MAIL");
                }
            }
            else
            {
                MessageBox.Show("KINDLY FILL THE NECESSARY INFORMATION");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }
    }
}
