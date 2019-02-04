using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Receptionist
{
    public partial class AddQuestion : Form
    {

        public AddQuestion()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=E-Reception;Trusted_Connection=true;");
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != null && textBox1.Text != null)
            {
                string add = "insert into dbo.ques_ans(question,Answer,keyword)values('" + textBox1.Text + "','" + textBox2.Text + "','"+textBox3.Text+"')";
                con.Open();
                SqlCommand sqlcom = new SqlCommand(add, con);
                sqlcom.ExecuteNonQuery();
                con.Close();

                string delete = "update dbo.tb_self_study set flag=0 where question='" + textBox1.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.ExecuteNonQuery();
                con.Close();

                self_study ss = new self_study();
                ss.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Enter Question and Answer");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            self_study ss = new self_study();
            ss.Show();
            this.Hide();
        }

        private void AddQuestion_Load(object sender, EventArgs e)
        {

        }

        
    }
}
