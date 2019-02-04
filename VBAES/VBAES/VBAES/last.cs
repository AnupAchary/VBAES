using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Synthesis;
namespace E_Receptionist
{
    public partial class last : Form
    {
        SpeechSynthesizer s = new SpeechSynthesizer();
        public last()
        {
            InitializeComponent();
            s.Speak(label1.Text);
        }
    }
}
