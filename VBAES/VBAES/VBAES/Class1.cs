using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_Receptionist
{
    class Class1
    {
        public SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;integrated security=true;database=library");

        SqlCommand cmd = new SqlCommand();

        public SqlDataReader dr;
        public SqlDataAdapter da = new SqlDataAdapter();

        public bool gridload(string s, DataGridView d)
        {
            try
            {
                cmd.CommandText = s;
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                d.DataSource = dt.DefaultView;
                return true;
            }
            catch
            {
                MessageBox.Show("hiiii");
                return false;
            }

        }

        public bool select(string query)
        {
            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                if (dr.HasRows == true)
                    return true;
                else return false;
            }
            catch
            {
                return true;
            }
            finally
            {
                con.Close();
            }
        }




        public bool dml(string query)
        {
            try
            {
                if (con.State != 0)
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
                MessageBox.Show(ex.ToString());
                return false;
            }
            finally
            {
                con.Close();

            }

        }

        public bool chk(string query)
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
                dr = cmd.ExecuteReader();
                if (dr.HasRows == true)
                    return true;
                else
                    return false;
            }

            finally
            {
                con.Close();
            }

        }

        public void LoadCombo(string query, ComboBox obj)
        {
            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                obj.Items.Clear();
                while (dr.Read())
                {
                    obj.Items.Add(dr.GetValue(0));
                }

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        public void LoadList(string query, ListBox obj)
        {
            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();

                obj.Items.Clear();
                while (dr.Read())
                {
                    obj.Items.Add(dr.GetValue(0));
                }

            }
            catch
            {

            }
            finally
            {
                con.Close();
            }
        }
        public SqlDataReader Reader(string query)
        {
            try
            {
                if (con.State != 0)
                {
                    con.Close();
                }

                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                return dr;
            }
            catch
            {
                return null;
            }
            finally
            {
            }
        }

        public SqlDataReader reader(string query)
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
                dr = cmd.ExecuteReader();
                return dr;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return null;
            }

        }


        public bool cmdload(string query, ComboBox  c)
        {
            try
            {
                c.Items.Clear();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    // c.Items.Add(dr[0]);
                }
                return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                con.Close();
            }

        }

        public bool cmdload1(string query, ComboBox  c)
        {
            try
            {
                string field;
                c.Items.Clear();
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    field = dr[0].ToString();
                    c.Items.Add(field);

                }
                return true;
            }
            catch
            {
                return false;
            }

            finally
            {
                con.Close();
            }
        }



    }
}
