using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class ManejoDeTransacciones
    {

        string strConnString = "myconnectionstring";
        SqlTransaction objTrans = null;

        /*using (SqlConnection objConn = new SqlConnection(strConnString))
        {

    
        objConn.Open();
        objTrans=objConn.BeginTransaction();
        SqlCommand objCmd1 = new SqlCommand();
        SqlCommand objCmd2 = new SqlCommand();

        txscope.Complete();
        try
        {
            objCmd1=ExecuteNonQuery();
            objCmd2=ExecuteNonQuery();

    } catch (Exception) {
        objTrans.Rollback();
    }
    finally{
        objConn.Close();
        

    }*/
    }
}