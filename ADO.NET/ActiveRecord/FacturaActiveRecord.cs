using ADO.NET.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
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

        public static List<FacturaActiveRecord> BuscarPorConcepto(string Concepto)
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
                    return lista;
                }
                else
                {
                    return null;
                }

            }
        }

        public static List<FacturaActiveRecord> BuscarTodos(FiltroFacturaNuevo filtro)
        {
            List<FacturaActiveRecord> lista = new List<FacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura";
                SqlCommand comando = new SqlCommand();
                if (filtro.Numero != 0)
                {
                    sql += " where Numero=@Numero";
                    comando.Parameters.AddWithValue("@Numero", filtro.Numero);

                    if (filtro.Concepto != null)
                    {
                        sql += " and Concepto=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }
                else
                {
                    if (filtro.Concepto != null)
                    {
                        sql += " where Concepto=@Concepto";
                        comando.Parameters.AddWithValue("@Concepto", filtro.Concepto);
                    }
                }
                comando.Connection = conexion;
                comando.CommandText = sql;
                SqlDataReader lector = comando.ExecuteReader();
                if (lector.Read())
                {
                    FacturaActiveRecord factura = new FacturaActiveRecord(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return lista;
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

        public List<LineaDeFacturaActiveRecord> BuscarTodos2()
        {
            List<LineaDeFacturaActiveRecord> lista = new List<LineaDeFacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from lineasfactura where factura_numero=@Factura_Numero";
                
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Factura_Numero", Numero);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new LineaDeFacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToInt32(lector["factura_numero"]),
                        lector["Producto_id"].ToString(), Convert.ToInt32(lector["Unidades"])));

                }

                return lista;
            }
            
        }

        public static List<FacturaLineaDTO> BuscarTodasFacturasLineas()
        {
            List<FacturaLineaDTO> lista = new List<FacturaLineaDTO>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select factura.numero, factura.concepto, " +
                    "lineasfactura.unidades, lineasfactura.producto_id from factura inner join lineasFactura on " +
                    "factura.numero=lineasfactura.factura_numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    FacturaLineaDTO factura = new FacturaLineaDTO(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString(), Convert.ToInt32(lector["unidades"]), lector["producto_id"].ToString());
                    return lista;
                }
                return null;

            }
        }

        public static int UnidadesTotales()
        {
           using (
           SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select sum(unidades) from lineasfactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                //ejecuta para devolver un número (para funciones de agregación)
                int total=Convert.ToInt32(comando.ExecuteScalar());
                return total;
                
            }
        }

    }
}
