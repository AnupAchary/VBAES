using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.Shared;



namespace Buildia
{
    class BusinessLogic
    {
       public SqlConnection con = new SqlConnection("server=localhost;integrated security=true;database=buildia");

        SqlCommand cmd=new SqlCommand();
        
       public  SqlDataReader dr;
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
                MessageBox.Show("Cant load");
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
        public  void LoadCombo(string query,ComboBox obj)
        {
            try
            {
                con.Open();
                cmd.CommandText = query;
                cmd.Connection = con;
                dr=cmd.ExecuteReader();

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
       
    }
}
