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
    public partial class home : Form
    {
        public static string ftext1 = "";
        public home()
        {
            InitializeComponent();
        }

        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            string asa = "Member";
            OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\lenovo\\Documents\\Visual Studio 2012\\Projects\\SE Project.accdb");
            con.Open();
            comboBox1.Items.Clear();
            OleDbCommand cmd = new OleDbCommand("SELECT DISTINCT societyname FROM records WHERE EMAIL='" + Homepage.welcome.ptext2 + "' AND asa='" + asa + "'", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                comboBox1.Items.Add(rd.GetString(0).ToString());
            }
            rd.Close();
            con.Close();
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            ftext1 = comboBox1.Text;
            this.Hide();
            Go w = new Go();
            w.Show();
        }
    }
}
