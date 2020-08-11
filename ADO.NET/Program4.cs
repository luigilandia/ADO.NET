using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program4
    {
        static void Main(string[] args)
        {
            SqlConnection conexion = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\formacion\Documents\prueba.mdf; Integrated Security = True; Connect Timeout = 30");
            conexion.Open();
            String sql = "update factura set concepto='compraC' where numero=2";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();

            Console.ReadLine();
        }
    }
}
