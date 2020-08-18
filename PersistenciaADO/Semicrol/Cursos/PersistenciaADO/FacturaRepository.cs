

using ADO.NET.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;


namespace Semicrol.Cursos.PersistenciaADO
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

        public List<Factura> BuscarTodosConLineas()
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select factura.Numero as 'NumeroFactura', " +
                    "Factura.Concepto, LineasFactura.numero as 'NumeroLinea', " +
                    "unidades, producto_id from factura inner join lineasfactura " +
                    "on factura.numero = lineasfactura.factura_numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                List<Factura> listaFacturas = new List<Factura>();
                while (lector.Read())
                {
                    Factura f = new Factura(Convert.ToInt32(lector["NumeroFactura"]));
                    if (!listaFacturas.Contains(f))
                    {
                        f.Concepto = lector["Concepto"].ToString();
                        listaFacturas.Add(f);
                    }
                    else
                    {
                        f = listaFacturas.
                            Find((facturita) => facturita.Numero == Convert.ToInt32(lector["NumeroFactura"]));

                    }
                    LineaFactura linea = new LineaFactura(Convert.ToInt32(lector["NumeroLinea"]),f);
                    
                    linea.Unidades = Convert.ToInt32(lector["unidades"]);
                    linea.Producto_Id = lector["producto_id"].ToString();
                    
                    f.AddLinea(linea);

                    /*lista.Add(new Factura(Convert.ToInt32(lector["numero"]), 
                        lector["concepto"].ToString()));*/

                }
                return listaFacturas;
            }
        }
    }
}
