using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Speech;
using System.Speech.Recognition;
using System.Threading;

//using SpeechLib;


using System.Data.SqlClient;
using System.Data.Sql;

using System.IO;
namespace E_Receptionist
{
    public partial class Gen : Form
    {
      /*  
        public SqlConnection con = new SqlConnection("server=S-PC;database=library;integrated security=true");
        SqlConnection con = new SqlConnection("Data Source=localhost;Initial Catalog=library;Trusted_Connection=true;");
        DataManager objdm = new DataManager();
        SpeechRecognizer recognizer = new SpeechRecognizer();
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        PromptBuilder pBuilder = new PromptBuilder();
        // DataSet DS;
        SqlDataAdapter DA = new SqlDataAdapter();
        SqlDataReader dr;
        // Class1 db = new Class1();
        //
        Class1 db = new Class1();
        */
        public Gen()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection("server=S-PC;database=library;integrated security=true");


        private void Gen_Load(object sender, EventArgs e)
        {
            /*this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Insert into img1 values('" + textBox1.Text + "','"+ textBox2+"')");
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Saved");
            con.Close();
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string a = "SELECT [image] FROM [library].[dbo].[img1] where name = '" + textBox1.Text + "'",con;

            pictureBox1.Image = Image.FromFile(a);
            
           /* string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
             // MessageBox.Show(projectPath);
             string im = projectPath + "select * from img1 ";
            
             pictureBox1.Image = Image.FromFile(im);
            //string answer = "select * from img ";
            */
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
