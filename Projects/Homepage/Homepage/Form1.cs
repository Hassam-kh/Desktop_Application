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
    public partial class Form1 : Form
    {
        string username;
        string password;
        string asa;
        string society;
        string name;
        string email;

        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            OleDbCommand cmd = con.CreateCommand();
            username = textBox2.Text;
            password = textBox4.Text;
            name = textBox1.Text;
            email = textBox3.Text;
            string reason = textBox5.Text;
            society = comboBox1.Text;
            asa = "Member";
            string asa1="Head";
            if (username != "" && password != "" && name != "" && email != "" && !email.Contains(" ") && society != "" && asa != "")
                {
                    if (email.Contains("@nu.edu.pk") && email != "admin@nu.edu.pk" && !(email.Length < 17) && !(password.Length < 7))
                    {
                        OleDbConnection con2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
                        OleDbCommand cmd2 = con2.CreateCommand();
                        con2.Open();
                        cmd2.CommandText = "Select  EMAIL,societyname from records where (asa='" + asa + "' OR asa='" + asa1 + "') AND societyname='" + society + "' AND EMAIL='" + email + "'";
                        OleDbDataReader reader1 = cmd2.ExecuteReader();
                        if (!reader1.Read())
                        {
                            /*/if (asa == "Head")
                            {
                                con.Open();
                                cmd.CommandText = "Select  * from records where asa='Head' AND societyname='" + society + "'";
                                OleDbDataReader reader = cmd.ExecuteReader();
                                if (!reader.Read())
                                {
                                
                                        OleDbConnection con1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
                                        OleDbCommand cmd1 = con1.CreateCommand();
                                        con1.Open();
                                        cmd1.CommandText = "Insert into Admin ([USERNAME],[PASSWORD],[Names],[EMAIL],[societyname],[asa],[reason]) values ('" + username + "','" + password + "','" + name + "','" + email + "','" + society + "','" + asa + "','" + reason + "')";
                                        cmd1.ExecuteNonQuery();
                                        con1.Close();
                                        MessageBox.Show("YOUR REQUEST IS SENT TO ADMIN FOR APPROVAL");
                                        this.Hide();
                                        welcome obj = new welcome();
                                        obj.Show();
                                    }
                                    else
                                    {
                                        MessageBox.Show("CAN'T REGISTER AS HEAD");
                                    }
                                    con2.Close();
                                }
                                else
                                {
                                    MessageBox.Show("CAN'T REGISTER AS HEAD");
                                }
                                con.Close();
                            }
                            else {
                              /*/
                            con.Open();
                            cmd.CommandText = "Insert into Head ([USERNAME],[PASSWORD],[Names],[EMAIL],[societyname],[asa],[reason]) values ('" + username + "','" + password + "','" + name + "','" + email + "','" + society + "','" + asa + "','" + reason + "')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("YOUR REQUEST IS SENT TO HEAD FOR APPROVAL");
                            this.Hide();
                            welcome obj = new welcome();
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("USER ALREADY EXSISTS");
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

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("(FSMS) : FAST SOCIETY MANAGEMENT SYSTEM. IT'S A PERFECT PLATFORM FOR STUDENTS TO ACTIVELY PARTICIPATE IN CO-CURRICULAR ACTIVITIES");
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox1.Items.Clear();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT societyname FROM records", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd.GetString(0).ToString());
            }
            rd.Close();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Society s = new Society();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            welcome w = new welcome();
            w.Show();
        }
    }
}
