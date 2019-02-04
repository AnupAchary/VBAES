using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace E_Receptionist
{
    public partial class Admin_Login : Form
    {
        public Admin_Login()
        {
            InitializeComponent();
            pass.PasswordChar ='*';
           
        }
        public SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;database=library;integrated security=true");

        //SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=E-Reception;Trusted_Connection=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            string login = "select * from adminlogin where username='" + un.Text + "' and password='" + pass.Text + "'";
            
            SqlCommand cmd = new SqlCommand(login, con);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = cmd;
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Admin ss = new Admin();
                ss.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Invalid");


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Admin_Login_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

     /*   private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Signin ss = new Signin();
            ss.Show();
            this.Hide();
        }
        */
       

        private void un_TextChanged(object sender, EventArgs e)
        {

        }
        private void pass_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
