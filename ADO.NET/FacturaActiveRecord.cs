using System;
using System.Collections.Generic;
using System.Configuration;
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
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into factura (numero, concepto) " +
                    "values (" + Numero + ", '" + Concepto + "')";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public void Borrar()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from factura where numero="+Numero;
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }
        }

        public static List<FacturaActiveRecord> BuscarTodos()
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector=comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString()));

                }
                return lista;
            }
        }

        public static FacturaActiveRecord BuscarUna(int Numero)
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura where numero="+Numero;
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    FacturaActiveRecord factura = new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }

            }
        }

        public void Actualizar()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update factura set concepto='"+Concepto+"' where numero=" + Numero;
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.ExecuteNonQuery();
            }
        }

        public void Borrar2()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from factura where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.ExecuteNonQuery();
            }
        }

        public void Insertar2()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into factura (numero, concepto) " +
                    "values (@Numero, @Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                comando.ExecuteNonQuery();
            }
        }

        

        public static FacturaActiveRecord BuscarUna2(int Numero)
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    FacturaActiveRecord factura = new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }

            }
        }

        public void Actualizar2()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update factura set concepto=@Concepto where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", Numero);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                comando.ExecuteNonQuery();
            }
        }

        public static FacturaActiveRecord BuscarPorConcepto(string Concepto)
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura where concepto=@Concepto";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Concepto", Concepto);
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    FacturaActiveRecord factura = new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }

            }
        }

        public override string ToString()
        {
            return Numero +" "+ Concepto;
        }

    }
}
