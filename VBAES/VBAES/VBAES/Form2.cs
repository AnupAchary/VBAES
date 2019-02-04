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
using System.IO;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace E_Receptionist
{
    public partial class Form2 : Form
    {

        SqlConnection con = new SqlConnection("Data Source=DESKTOP-JOAPCGV\\SQLEXPRESS;Initial Catalog=library;Trusted_Connection=true;");
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

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choices colors = new Choices();

            colors.Add(new string[] { "hello" });

            string grammer = "select title from img2";

            {
                using (SqlCommand cm = new SqlCommand(grammer, con))
                {
                    con.Close();
                    con.Open();
                    SqlDataReader reader = cm.ExecuteReader();
                    while (reader.Read())
                    {

                        colors.Add(reader.GetString(0));
                    }
                }

                con.Close();

            }

            //string grammer2 = "select Title from BookUpdate2";
            string grammer2 = "select title from img2";


            {
                using (SqlCommand cmd = new SqlCommand(grammer2, con))
                {

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {

                        colors.Add(reader.GetString(0));
                    }
                }

                con.Close();

            }



            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(colors);

            /* foreach(var item in colors)
             {
                 Console.WriteLine(item.ToString());
             }*/
            Grammar g = new Grammar(gb);
            recognizer.LoadGrammar(g);


            recognizer.SpeechRecognized +=
              new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
        }

        Boolean cb;
        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            /* if (textBox1.Text == "")
             {
                 sSynth.Speak("Please enter Your question"); 
             }

             else
             {*/
            
            textBox1.Text = e.Result.Text;
            MessageBox.Show(textBox1.Text);
            //Lib edit
            //string answer = "select * from BookUpdate2 where Title='"  +this.textBox1.Text + "'";
            string answer = "select * from img2 where title='" + this.textBox1.Text + "'";
           

            cb = objdm.CheckIsRecordExist(answer);
          //  MessageBox.Show(cb.ToString());
            //if(cb)
            //{
                db.Reader(answer);
                //db.dr.Read();
                if(db.dr.Read())
                {
                    var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "image", db.dr[2].ToString());
                    pictureBox1.ImageLocation = path;
                    textBox2.Text = db.dr[3].ToString();
                    sSynth.Speak(db.dr[3].ToString());
                }
             


              
          //  }

            
            //MessageBox.Show("its"+cb);
            //DataSet objdss = objdm.GetDataSet(answer);

            // if (objdss.Tables[0].Rows.Count >= 0)
            //{
            // string a = "Select * from BookUpdate2";
            string question = textBox1.Text;
            //textBox1.Text = "";
            //SqlCommand cmd = new SqlCommand(answer, con);
            //SqlDataAdapter da = new SqlDataAdapter();

            //DS.Clear();
            //cmd.CommandText = answer;

            //cmd.ExecuteReader();
            //dr = 
            //cmd.Connection = con;
            //DA.SelectCommand = cmd;
           // DataTable dt = new DataTable();
           // DA.Fill(dt);
           // this.dataGridView1.DataSource = dt.DefaultView;

            // textBox1.Text = objdss.Tables[0].Rows[0]["Answer"].ToString();
            // pBuilder.AppendText(textBox1.Text);
           
            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Welcome ss = new Welcome();
            ss.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
