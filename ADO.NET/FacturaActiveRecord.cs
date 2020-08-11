using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FacturaActiveRecord
    {
        public FacturaActiveRecord(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public int Numero { get; set; }
        public string Concepto { get; set; }

        public void Insertar()
        {
            SqlConnection conexion = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\formacion\Documents\prueba.mdf; Integrated Security = True; Connect Timeout = 30");
            conexion.Open();
            String sql = "insert into factura (numero, concepto) " +
                "values ("+Numero+", '"+Concepto+"')";
            SqlCommand comando = new SqlCommand(sql, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
        }
    }
}
