using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace E_Receptionist
{
    public partial class Signin : Form
    {
        public SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;database=library;integrated security=true");
        public Signin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[a-zA-Z0-9]"))
            {
                MessageBox.Show("This textbox accepts only alphabetical characters");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Admin_Login ss = new Admin_Login();
            ss.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Welcome ss = new Welcome();
            ss.Show();
            this.Hide();
        }

        private void Signin_Load(object sender, EventArgs e)
        {
            /*this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into adminlogin values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +textBox4.Text+"')");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            con.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
