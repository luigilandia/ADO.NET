using ADO.NET.Persistencia;
using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaADO.Semicrol.Cursos.PersistenciaADO
{
    class FacturaLineaRepository : IFacturaLineaRepository
    {
        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public void Actualizar(Factura factura)
        {
            throw new NotImplementedException();
        }

        public void Borrar(Factura factura)
        {
            throw new NotImplementedException();
        }

        public List<Factura> BuscarTodos()
        {
            throw new NotImplementedException();
        }

        public Factura BuscarUno(int numero)
        {
            throw new NotImplementedException();
        }

        public void Insertar(Factura factura)
        {
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "insert into lineasfactura (numero, factura_numero, producto_id, unidades) " +
                    "values (@Numero, @factura_numero, @producto_id, @unidades)";
                SqlCommand comando = new SqlCommand(sql, conexion);
                //comando.Parameters.AddWithValue("@Numero",);
                comando.Parameters.AddWithValue("@factura_numero", factura.Concepto);
                comando.Parameters.AddWithValue("@producto_id", factura.Concepto);
                comando.Parameters.AddWithValue("@unidades", factura.Concepto);
                comando.ExecuteNonQuery();
            }
        }
    }
}
