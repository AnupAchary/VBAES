using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Windows.Forms;


namespace coll
{
    class libclass
    {
        public SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;database=library;integrated security=true");
        SqlCommand cmd = new SqlCommand();
        public SqlDataReader dr;
        public SqlDataAdapter da = new SqlDataAdapter();
        public DataSet ds = new DataSet();

        public DataTable ss = new DataTable();


        public bool dml(string query)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd.CommandText = query;

                cmd.Connection = con;

                cmd.ExecuteNonQuery();


                return true;

            }
            catch (Exception ex)
            {


                return false;
            }
            finally
            {
                con.Close();
            }
        }


        public bool gridload(string query, DataGridView gv)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                cmd.CommandText = query;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                gv.DataSource = dt.DefaultView;

                return true;
            }

            catch (Exception e)
            {
                //MessageBox.Show(e.ToString());
                return false;

            }
        }


    }
}
