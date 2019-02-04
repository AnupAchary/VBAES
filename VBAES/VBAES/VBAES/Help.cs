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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            label1.Text = "- Provide voice commands to get the outputs";
            label2.Text = "- For library related queries click on library button";
            label3.Text = "- For general queries click on enquiry button";
            label4.Text = "- The first imagebox displays floor map the second imagebox shows  the destination image";
            label5.Text = "- On each page top right corner have the close button";
            label6.Text = "- The home button on each page will take you to the home screen.";
            label1.Font = label2.Font = label3.Font = label4.Font = label5.Font = label6.Font = new System.Drawing.Font("TIMES NEW ROMAN", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome W = new Welcome();
            W.Show();
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
