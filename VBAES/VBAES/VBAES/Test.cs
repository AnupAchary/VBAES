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
using System.Speech.Synthesis;
using System.Threading;

//using SpeechLib;

using System.Data.SqlClient;
using System.Data.Sql;
using System.IO;
using coll;

namespace E_Receptionist
{
    public partial class Test : Form
    {
        libclass c = new libclass();
        public SpeechRecognitionEngine recognizor;
        SpeechRecognizer recognizer = new SpeechRecognizer();
        SpeechSynthesizer sSynth = new SpeechSynthesizer();
        public Grammar grammer;
        public Thread recthread;
        public bool recognizorstate = true;
        public Test()
        {
            InitializeComponent();
        }

        private void Test_Load(object sender, EventArgs e)
        {
            this.TopMost = true;

            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

           // label1.Text = "YOUR DESTINATION IMAGE";
            //label2.Text = "ASK YOUR QUERIES";
            //label3.Text = "FLOOR MAP";
            //label1.Font = label2.Font = label3.Font = new System.Drawing.Font("ALGERIAN", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            GrammarBuilder build = new GrammarBuilder();
            build.AppendDictation();

            grammer = new Grammar(build);

            recognizor = new SpeechRecognitionEngine();
            recognizor.LoadGrammar(grammer);
            recognizor.SetInputToDefaultAudioDevice();

            recognizor.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(recognizor_speachrecognized);
            recognizorstate = true;
            recthread = new Thread(new ThreadStart(RecthreadFunction));
            recthread.Start();
        }

        public void recognizor_speachrecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (!recognizorstate)
            {
                return;
            }

            this.Invoke((MethodInvoker)delegate
            {
                string st = "";
                //textBox1.Text = "";
                //textBox1.Text += ("" + e.Result.Text.ToLower());
                st += ("" + e.Result.Text.ToLower());

                //SpVoice vo = new SpVoice();


                if (st.Contains("doctor") || st.Contains("offers") || st == "they're in all" || st.Contains("readers") || st.Contains("result") || st.Contains("office") || st == "many saudies" || st == "when he saw" || st.Contains("miz") || st.Contains("lewis") || st.Contains("amid") || st.Contains("this") || st.Contains("please") || st.Contains("oldies"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is office??", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("You can move to ground floor office 1 is near to principal's chamber and office 2 is near to board room");
                        MessageBox.Show("You can move to ground floor office 1 is near to principal's chamber and office 2 is near to board room"); //where is office??
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "office.jpg";

                        pictureBox1.Image = Image.FromFile(im);

                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;


                        string im1 = projectPathName + "\\" + "gnd.jpg";
                        pictureBox2.Image = Image.FromFile(im1);
                    }

                }


                else if (st.Contains("new line the") || st.Contains("dont you the") || st.Contains("those") || st.Contains("holish") || st.Contains("venice") || st.Contains("computer") || st.Contains("science") || st.Contains("department") || st.Contains("many unread") || st.Contains("the path"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is computer science department", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("First floor main building ");
                        MessageBox.Show("First floor main buildingko "); //computer science department
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "cs.jpg";

                        pictureBox1.Image = Image.FromFile(im);

                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        string im1 = projectPathName + "\\" + "1st(1).jpg";

                        pictureBox2.Image = Image.FromFile(im1);
                    }
                }
                else if (st.Contains("is") || st.Contains("information") || st.Contains("science") || st.Contains("department") || st.Contains("and") || st.Contains("the holish") || st.Contains("holish") || st.Contains("and while") || st.Contains("polish") || st.Contains("owners"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is information science department", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("Fourth floor main building ");
                        MessageBox.Show("fourth floor main building "); //information science department
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "is.jpg";

                        pictureBox1.Image = Image.FromFile(im);

                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        string im1 = projectPathName + "\\" + "4th(1).jpg";

                        pictureBox2.Image = Image.FromFile(im1);
                    }
                }
                else if (st.Contains("OS") || st.Contains("os") || st.Contains("ss") || st.Contains("SS") || st.Contains("lab") || st.Contains("system") || st.Contains("software"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is SS OS Lab??", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("First floor main building ");
                        MessageBox.Show("First floor main building "); //SS os lab
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "ssos.jpg";

                        pictureBox1.Image = Image.FromFile(im);
                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        string im1 = projectPathName + "\\" + "1st.jpg";

                        pictureBox2.Image = Image.FromFile(im1);
                    }
                }
                else if (st.Contains("doctor") || st.Contains("offers") || st == "they're" || st.Contains("readers") || st.Contains("digital") || st.Contains("library"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is digital library??", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("You can move straight right to entrance");
                        MessageBox.Show("You can move stright right to entrance"); //where is digital library??
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "digital.jpg";

                        pictureBox1.Image = Image.FromFile(im);

                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        string im1 = projectPathName + "\\" + "gnd.jpg";

                        pictureBox2.Image = Image.FromFile(im1);
                    }

                }
                else if (st.Contains("circulation") || st.Contains("offers") || st == "section" || st.Contains("readers") || st.Contains("digital") || st.Contains("library"))
                {
                    DialogResult dialogResult = MessageBox.Show("Where is Circulation section??", "Do you mean", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    if (dialogResult == DialogResult.Yes)
                    {
                        sSynth.Speak("You can go to library building ground floor");
                        MessageBox.Show("You can go to library building ground floor"); //where is circulation section??
                        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                        // MessageBox.Show(projectPath);
                        string im = projectPath + "\\" + "circulation.jpg";

                        pictureBox1.Image = Image.FromFile(im);

                        string projectPathName = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

                        string im1 = projectPathName + "\\" + "ground.jpg";

                        pictureBox2.Image = Image.FromFile(im1);
                    }

                }

                else
                {
                    sSynth.Speak("i am not hearing you clearly please speak out loudly and clearly");
                    MessageBox.Show("i am not hearing you clearly plase speak out loudly and clearly....!");

                }

            });
        }
        public void RecthreadFunction()
        {
            while (true)
            {
                try
                {
                    recognizor.Recognize();
                }
                catch
                {

                }
            }
        }

        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            recthread.Abort();
            recthread = null;

            recognizor.UnloadAllGrammars();
            recognizor.Dispose();
            grammer = null;
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Welcome W = new Welcome();
            W.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
