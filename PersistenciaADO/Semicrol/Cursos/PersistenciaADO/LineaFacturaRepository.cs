using Persistencia.Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.PersistenciaADO
{
    class LineaFacturaRepository : ILineaFacturaRepository
    {
        public void Insertar(LineaFactura lf)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into lineasfactura (numero, factura_numero, " +
                    "unidades, producto_id) " +
                    "values (@Numero, @Factura_Numero, @Unidades, @Producto_id)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                comando.Parameters.AddWithValue("@factura_numero", lf.factura);
                comando.Parameters.AddWithValue("@Unidades", lf.Unidades);
                comando.Parameters.AddWithValue("@Producto_id", lf.Producto_Id);
                comando.ExecuteNonQuery();
            }
        }

        public void Borrar(LineaFactura lf)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "delete from LineasFactura where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                comando.ExecuteNonQuery();
            }
        }

        public void Actualizar(LineaFactura lf)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "update lineasFactura set concepto=@Concepto where numero=@Numero";
                SqlCommand comando = new SqlCommand(sql, conexion);
                comando.Parameters.AddWithValue("@Numero", lf.Numero);
                //comando.Parameters.AddWithValue("@Concepto", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }
    }
}
