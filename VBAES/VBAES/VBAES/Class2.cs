
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Data.SqlClient; 
/// <summary>
/// Summary description for Class1
/// </summary>
public class Class2
{
    //public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\myshopdb.mdf;Integrated Security=True");

    public SqlConnection con = new SqlConnection("server=DESKTOP-JOAPCGV\\SQLEXPRESS;database=library;integrated security=true");

    public SqlCommand cmd = new SqlCommand();

    public SqlDataReader dr, dr1;
    public SqlDataAdapter da = new SqlDataAdapter();
    public DataSet ds = new DataSet();

    public DataTable ss = new DataTable();

    public bool cmdload1(string query, ComboBox c)
    {
        try
        {
            string field, val;
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
                //val=c.ValueMember = dr[1].ToString();
                //field=c.DisplayMember = dr[0].ToString();
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

    public bool slct(String query)
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
            return true;
        }
        catch (Exception ex)
        {
            // MsgBox(ex.ToString);
            return false;
        }
        finally
        {
            con.Close();
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

    public bool listload(string query, ListBox l)
    {
        try
        {
            string field;
            l.Items.Clear();
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
                l.Items.Add(field);
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
            // gv.DataBinding();
            return true;
        }

        catch (Exception e)
        {
            //MessageBox.Show(e.ToString());
            return false;

        }
    }

    public bool cmdload(string query, ComboBox c)
    {
        try
        {
            string field, val;
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
                field = dr[0].ToString();
                //val=c.ValueMember = dr[1].ToString();
                val = dr[1].ToString();
                //field=c.DisplayMember = dr[0].ToString();
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