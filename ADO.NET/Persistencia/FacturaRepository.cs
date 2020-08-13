
using ADO.NET.ActiveRecord;
using ADO.NET.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Persistencia
{
    public class FacturaRepository:IFacturaRepository
    {
        public void Insertar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into factura (numero, concepto) " +
                    "values (@Numero, @Concepto)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public void Borrar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from factura where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.ExecuteNonQuery();
            }
        }

        public Factura BuscarUno(int Numero)
        {
            List<Factura> lista = new List<Factura>();
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
                    Factura factura = new Factura(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return factura;
                }
                else
                {
                    return null;
                }

            }
        }

        public List<Factura> BuscarTodos()
        {
            List<Factura> lista = new List<Factura>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from factura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while (lector.Read())
                {
                    lista.Add(new Factura(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString()));

                }
                return lista;
            }
        }

        public List<Factura> BuscarTodos(FiltroFacturaNuevo filtro)
        {
            List<Factura> lista = new List<Factura>();
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
                    Factura factura = new Factura(Convert.ToInt32(lector["numero"]), lector["concepto"].ToString());
                    return lista;
                }
                else
                {
                    return null;
                }

            }
        }

        public void Actualizar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update factura set concepto=@Concepto where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", factura.Numero);
                comando.Parameters.AddWithValue("@Concepto", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }

        public List<FacturaLineaDTO> BuscarTodasFacturasLineas()
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

    }
}
