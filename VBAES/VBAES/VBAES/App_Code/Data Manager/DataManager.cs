using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for DataManager
/// </summary>
public class DataManager
{
	public DataManager()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public SqlConnection myConn;
    private SqlTransaction myTrans;
    public int ConnectionTimeOut;

    public bool OpenSqlConnection()
    {
        bool bAttemptToConnect = false;
        try
        {
            if (myConn == null)
                bAttemptToConnect = true;
            if (bAttemptToConnect == false)
            {
                if ((myConn.State == ConnectionState.Closed) || (myConn.State == ConnectionState.Broken))
                    bAttemptToConnect = true;
            }
            if (bAttemptToConnect)
            {
                myConn = new SqlConnection();
                myConn.ConnectionString = GetConnectionString();
                myConn.Open();
            }
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
        return bAttemptToConnect;
    }

    public void CloseConnection()
    {
        try
        {
            if (myConn.State == ConnectionState.Open)
                myConn.Close();
        }
        catch (Exception ex)
        {
            ex.Data.Clear();
        }
    }

    public string GetConnectionString()
    {
        string strConnectionString="";
        strConnectionString=ConfigurationSettings.AppSettings["ConnStr"];
        //strConnectionString="Data Source=.;Initial catalog=signup; Trusted_Connection=false; UserID=sa; Password=sql123";
    return strConnectionString;
    }

    public DataSet GetDataSet(string a_strDataSource) //Select query
    {
        System.Data.SqlClient.SqlDataAdapter myAdapter;
       DataSet DS;
        try
        {
            DS=new DataSet();
            myAdapter=new System.Data.SqlClient.SqlDataAdapter(a_strDataSource,GetConnectionString());
            myAdapter.SelectCommand.CommandTimeout=ConnectionTimeOut;
            myAdapter.Fill(DS);
            myAdapter.Dispose();
            myAdapter=null;
            return DS;
        }
        catch(Exception ex)
        {
            ex.Data.Clear();
            return null;
        }
        finally
        {
            //DS.Dispose();
        }
    }
    public string ExecuteQuery(string a_strSqlCommand)  //Insert and update
    {
        if(OpenSqlConnection())
        {
            CloseConnection();
            OpenSqlConnection();
        }
        System.Data.SqlClient.SqlCommand objCommand=new System.Data.SqlClient.SqlCommand(a_strSqlCommand);
        try
        {
            objCommand.Connection=myConn;
            objCommand.CommandType=CommandType.Text;
            objCommand.ExecuteNonQuery();
            objCommand.Dispose();
            return "Executed successfully";
        }
        catch(Exception ex)
        {
            return ex.Message.Trim();
        }
        finally
        {
            CloseConnection();
        }
    }
    public bool CheckIsRecordExist(string a_strChkSqlCommand)  
    {
        System.Data.SqlClient.SqlCommand objCommand;
        bool RecordExists=false;

        try
        {
            bool AttemptToConnect=OpenSqlConnection();
            objCommand=new System.Data.SqlClient.SqlCommand(a_strChkSqlCommand);
            objCommand.Connection=myConn;
            //objCommand.CommandTimeout=ConnectionTimeOut;
            objCommand.CommandType=CommandType.Text;
            string result=Convert.ToString(objCommand.ExecuteScalar());
            objCommand.Dispose();

            if(result!="")
            {
                RecordExists=true;
            }
            return RecordExists;
        }
        catch(SqlException ex)
        {
            ex.Data.Clear();
            return RecordExists;
        }
        catch(Exception ex)
        {
            ex.Data.Clear();
            return RecordExists;
        }
        finally
        {CloseConnection();
        }
    }
}