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
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace E_Receptionist
{
    public partial class Form4 : Form
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

        public Form4()
        {
            InitializeComponent();
            
          

        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { sSynth.Speak("Please enter Your question"); }
            else
            {

                switch (textBox1.Text)
                {

                    case "hello":
                        textBox1.Text = "How are you?";
                        // pBuilder.AppendText(textBox1.Text);
                        sSynth.Speak(textBox1.Text);
                        break;

                    default:

                        string a = "Select * from ques_ans";
                        string question = textBox1.Text;
                        textBox1.Text = "";
                        SqlCommand cmd = new SqlCommand(a, con);
                        SqlDataAdapter da = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        int n = ds.Tables[0].Rows.Count;
                        for (int count = 0; count < n; count++)
                        {
                            // string str =textBox1.Text;
                            string i = ds.Tables[0].Rows[count]["question"].ToString();

                            if (i.ToLower().Contains(question.ToLower()))
                            {
                                //  Response.Write("String found");
                                string answer = "select Answer from ques_ans where question='" + i + "'";
                                DataSet objdss = objdm.GetDataSet(answer);
                                if (objdss.Tables[0].Rows.Count > 0)
                                {
                                    textBox1.Text = "";
                                    textBox1.Text = objdss.Tables[0].Rows[0]["Answer"].ToString();
                                    //pBuilder.AppendText(textBox1.Text);
                                    sSynth.Speak(textBox1.Text);
                                    break;
                                }
                                else
                                {
                                    sSynth.Speak("I am sorry that am not able to answer your question");

                                }
                            }

                        }
                        if (textBox1.Text == "")
                        {

                            string sstudy = "insert into tb_self_study(question)values('" + question + "')";
                            con.Open();
                            SqlCommand sqlcom = new SqlCommand(sstudy, con);
                            sqlcom.ExecuteNonQuery();
                            con.Close();
                            sSynth.Speak("I am sorry that am not able to answer your question");
                        }
                        break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TextBox4.Text = this.dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();

        }
        //Boolean ck;


        private void button8_Click(object sender, EventArgs e)
        {
            Boolean o, b, C, F, bc, upd, io;
            int no = 0;
            string n1;
            if (this.TextBox2.Text == "" || this.TextBox3.Text == "" || this.TextBox3.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please enter all fields");

            }
            else
            {
                string a ="select No_of_Copies from BookUpdate2 where Call_No='" + TextBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(a, con);
                SqlDataAdapter da1 = new SqlDataAdapter();
                DataSet ds1 = new DataSet();
                da1.SelectCommand = cmd;
                da1.Fill(ds1);
               
                //string i = ds1.Tables[0].Rows[count]["question"].ToString();
               
                    n1 = ds1.Tables[0].Rows[0]["No_of_Copies"].ToString();
                    no = Convert.ToInt16(n1);
                


                if (no != 0)
                {
                    int aka;
                    Boolean fc;
                    aka = no - 1;
                    


                    C = db.chk("select Reg_No,Call_No from ApplyBook where  Reg_No=  '" + textBox5.Text + "' and Call_No=  '" + TextBox4.Text + "' and Status='Applied'");
                    if (C == true)
                    {
                        MessageBox.Show("Already applied");
                    }
                    else
                    {
                        //db.select("SELECT COUNT(*)   FROM [library].[dbo].[ApplyBook] where Status ='Applied' and  Reg_No=  '" + textBox1.Text + "' ");
                        string a1 = "SELECT COUNT(*) FROM [library].[dbo].[ApplyBook] where Status ='Applied' and  Reg_No= '" + textBox5.Text + "'";
                        SqlCommand cmd1 = new SqlCommand(a1, con);
                        SqlDataAdapter da2 = new SqlDataAdapter();
                        DataSet ds2 = new DataSet();
                        da2.SelectCommand = cmd1;
                        da2.Fill(ds2);
                        
                         string n11 = ds2.Tables[0].Rows[0][0].ToString();
                         MessageBox.Show("sdf"+n11);
                  //      string i = ds1.Tables[0].Rows.Count.ToString();
                            int count = Convert.ToInt16(n11);
                            if (count == 1)
                            {
                                MessageBox.Show("Already applied for 1  books");
                            }
                            else
                            {
                                fc = db.chk("select * from Fine_Calculation where Reg_No=  '" + textBox5.Text + "' and Status='balance'");
                                if (fc == true)
                                {
                                    MessageBox.Show("you have fine please pay");
                                }
                                else
                                {
                                    bc = db.dml("insert into ApplyBook(Reg_No,Name,Class_Name,Apply_Date,Call_No,Return_Date,Status,Issue_Type) values('" + textBox5.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + DateTimePicker1.Text + "','" + TextBox4.Text + "','','Applied','" + comboBox1.SelectedItem + "')");
                                    io = db.dml("update BookUpdate2 set No_Of_Copies='" + aka.ToString() + "' where Call_No=  '" + TextBox4.Text + "'");
                                    if (bc == true && io == true)
                                    {
                                        MessageBox.Show("inserted");
                                    }
                                    else
                                    {
                                        MessageBox.Show("not inserted");
                                        db.gridload("select * from  BookUpdate2 where Call_No='" + TextBox4.Text + "'", dataGridView1);
                                    }
                                    
                                  // MessageBox.Show("requested Book not available");
                                }
                            }
                        }

                    
                }
                else
                {
                    MessageBox.Show("requested Book not available");
                }
              //  
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {

             string a = "SELECT [Stud_name],[Course] FROM [library].[dbo].[StudInfo] where Reg_No = '" + textBox5.Text + "'";
                        
                        SqlCommand cmd = new SqlCommand(a, con);
                        SqlDataAdapter da1 = new SqlDataAdapter();
                        DataSet ds1 = new DataSet();
                        da1.SelectCommand = cmd;
                        da1.Fill(ds1);
                        int n = ds1.Tables[0].Rows.Count;
                        //string i = ds1.Tables[0].Rows[count]["question"].ToString();
                        if(n>0)
                        {
                            TextBox2.Text = ds1.Tables[0].Rows[0]["Stud_name"].ToString();
                            TextBox3.Text = ds1.Tables[0].Rows[0]["Course"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Register number not found....!");
                        }
                       
            //TextBox3.Text = dr[1].ToString();
            //db.select("SELECT [Stud_name],[Course] FROM [library].[dbo].[StudInfo] where Reg_No = '" + textBox5.Text + "'");

            //db.dr.Read();
            //TextBox2.Text = dr[0].ToString();
            //TextBox3.Text = dr[1].ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Choices colors = new Choices();

            colors.Add(new string[] { "hello" });

            string grammer = "select Subject from BookUpdate2";

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
            string grammer2 = "select Subject from BookUpdate2";


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
            //MessageBox.Show (e.Result.Text);
            textBox1.Text = e.Result.Text;

            //Lib edit
            //string answer = "select * from BookUpdate2 where Title='"  +this.textBox1.Text + "'";
            string answer = "select * from BookUpdate2 where Subject='" + this.textBox1.Text + "'";
            cb = objdm.CheckIsRecordExist(answer);
            //MessageBox.Show("its"+cb);
            //DataSet objdss = objdm.GetDataSet(answer);

            // if (objdss.Tables[0].Rows.Count >= 0)
            //{
            // string a = "Select * from BookUpdate2";
            string question = textBox1.Text;
            //textBox1.Text = "";
            SqlCommand cmd = new SqlCommand(answer, con);
            SqlDataAdapter da = new SqlDataAdapter();

            //DS.Clear();
            cmd.CommandText = answer;
            //cmd.Connection = con;
            DA.SelectCommand = cmd;
            DataTable dt = new DataTable();
            DA.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;

            // textBox1.Text = objdss.Tables[0].Rows[0]["Answer"].ToString();
            // pBuilder.AppendText(textBox1.Text);
            sSynth.Speak(textBox1.Text);
            

        }

 
        private void Form4_Load(object sender, EventArgs e)
        {
           db.cmdload ("SELECT [Issue_Type] FROM [library].[dbo].[Issue_Type]",comboBox1);
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void button6_Click(object sender, EventArgs e)
        {
           Environment.Exit (0);
        }
        
        private void button7_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            textBox5.Text = "";
            TextBox4.Text = "";
            TextBox3.Text = "";

        }
    }
}
            