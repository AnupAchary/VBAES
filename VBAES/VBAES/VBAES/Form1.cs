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
    public partial class Form1 : Form
    {
        Class1 c = new Class1();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // c.cmdload1("SELECT [Issue_Type] FROM [library].[dbo].[Issue_Type]",comboBox1     );
        }
    }
}
