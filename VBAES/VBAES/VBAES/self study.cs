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
    public partial class self_study : Form
    {
        public self_study()
        {
            InitializeComponent();
        }

        private void self_study_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_E_ReceptionDataSet.tb_self_study' table. You can move, or remove it, as needed.
            this.tb_self_studyTableAdapter.Fill(this._E_ReceptionDataSet.tb_self_study);
            DataGridViewLinkColumn Addlink = new DataGridViewLinkColumn();
            Addlink.UseColumnTextForLinkValue = true;
            Addlink.HeaderText = "Add to Database";
            Addlink.DataPropertyName = "lnkColumn";
            Addlink.LinkBehavior = LinkBehavior.SystemDefault;
            Addlink.Text = "Add";
            dataGridView1.Columns.Add(Addlink);



            DataGridViewLinkColumn Deletelink = new DataGridViewLinkColumn();
            Deletelink.UseColumnTextForLinkValue = true;
            Deletelink.HeaderText = "Delete";
            Deletelink.DataPropertyName = "lnkColumn";
            Deletelink.LinkBehavior = LinkBehavior.SystemDefault;
            Deletelink.Text = "Delete";
            dataGridView1.Columns.Add(Deletelink);



        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns[1].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var question = row.Cells[0].Value.ToString();
                AddQuestion add = new AddQuestion();
                add.Show();
                this.Hide();
                add.textBox1.Text = question;
            }
            else if (e.ColumnIndex == dataGridView1.Columns[2].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                var question = row.Cells[0].Value.ToString();
                string delete = "update tb_self_study set flag=0 where question='"+question+"'";
                SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=E-Reception;user=sa;password=sql123;Trusted_Connection=true;");
                SqlCommand cmd = new SqlCommand(delete, conn);
                SqlDataReader dbr;
                try
                {
                    conn.Open();
                    dbr = cmd.ExecuteReader();
                    MessageBox.Show("  Deleted  ");


                    dataGridView1.Refresh();
                    conn.Close();
                }
                catch (Exception ee)
                { MessageBox.Show(ee.Message); }

         //      dataGridView1.DataSource=_E_ReceptionDataSet;
                dataGridView1.RefreshEdit();
               
            }
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.tb_self_studyTableAdapter.FillBy(this._E_ReceptionDataSet.tb_self_study);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome w = new Welcome();
            w.Show();
            this.Hide();
        }
    }
}
