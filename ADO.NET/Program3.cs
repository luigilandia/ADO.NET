using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program3
    {
        static void Main(string[] args)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\formacion\Documents\prueba.mdf; Integrated Security = True; Connect Timeout = 30");
            conexion.Open();
            String sql = "delete from factura where numero=3";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();

            Console.ReadLine();
        }
    }
}
