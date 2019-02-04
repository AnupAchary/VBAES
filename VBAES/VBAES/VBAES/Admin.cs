using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Receptionist
{
    public partial class Admin : Form
    {

        public Admin()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LibData w = new LibData();
            w.Show();
            this.Hide();

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eq w = new eq();
            w.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Signin ss = new Signin();
            ss.Show();
            this.Hide();
        }
    }
}
