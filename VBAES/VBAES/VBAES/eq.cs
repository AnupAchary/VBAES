using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace E_Receptionist
{
    public partial class eq : Form
    {
        Class1 cdb = new Class1();

        SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;database=library;integrated security=true");

        SqlCommand cmd = new SqlCommand();

        SqlDataReader dr;
        string str, abc;

        public eq()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = New OpenFileDialog();
            //openFileDialog aa = new openFileDialog1();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select your Image.";
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //openFileDialog1.InitialDirectory = "C:\";
            op.Filter = "Image Files|*.gif;*.jpg;*.png;*.bmp;";
            //openFileDialog1.RestoreDirectory = False;

            if (op.ShowDialog() == DialogResult.OK)
            {
                string fpt = op.FileName;
                this.pictureBox1.ImageLocation = fpt;
            }

            //pictureBox1.Image.Save(Application.StartupPath + "\\Image\\" + op.FileName);

            string fileName = op.SafeFileName;
            this.textBox2.Text = fileName;

            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "image", fileName);
            File.Copy(op.FileName, path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            //string fileName1 = op.SafeFileName;
            //MemoryStream ms = new MemoryStream();
            //pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            //byte[] data = ms.GetBuffer();

            cmd.CommandText = "Insert Into img2 Values('" + textBox1.Text + "','" + this.textBox2.Text + "','" + textBox3.Text + "')";

            con.Open();
            // SqlParameter p = new SqlParameter("@image", SqlDbType.Image);
            cmd.Connection = con;

            // p.Value = data;
            //cmd.Parameters.Add(p);
            cmd.ExecuteNonQuery();

            con.Close();

            cdb.gridload("select * from img2", dataGridView1);

        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {

            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(byteArrayIn);
            return img;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            cdb.reader("select * from img2 order by id desc");
            cdb.dr.Read();
            MessageBox.Show(cdb.dr[2].ToString());
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "image", cdb.dr[2].ToString());
            pictureBox2.ImageLocation = path;
            //cdb.reader("select * from img3");
            //cdb.dr.Read();

            //byte[] data = (byte[])cdb.dr["image"];
            ////MemoryStream ms = new MemoryStream(data);
            ////ms.Seek(0, SeekOrigin.Begin);
            ////Bitmap bmp = new Bitmap(ms);
            ////pictureBox2.Image = bmp;
            //pictureBox2.Dispose();

            //pictureBox2.Image = byteArrayToImage(data);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void eq_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            cdb.gridload("select * from img2", dataGridView1);
            String answer = "select * from img2";
            SqlCommand cmd = new SqlCommand(answer, con);
            SqlDataAdapter da = new SqlDataAdapter();

            //DS.Clear();
            cmd.CommandText = answer;
            //cmd.Connection = con;
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
/*
        private void button5_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openFileDialog1 = New OpenFileDialog();
            //openFileDialog aa = new openFileDialog1();
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select your Image.";
            op.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            //openFileDialog1.InitialDirectory = "C:\";
            op.Filter = "Image Files|*.gif;*.jpg;*.png;*.bmp;";
            //openFileDialog1.RestoreDirectory = False;

            if (op.ShowDialog() == DialogResult.OK)
            {
                string fpt = op.FileName;
                this.pictureBox3.ImageLocation = fpt;
            }

            //pictureBox1.Image.Save(Application.StartupPath + "\\Image\\" + op.FileName);

            string fileName = op.SafeFileName;
            this.textBox4.Text = fileName;

            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "image", fileName);
            File.Copy(op.FileName, path);
        }
        
  */      private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin ss = new Admin();
            ss.Show();
            this.Hide();
        }
    }
}
