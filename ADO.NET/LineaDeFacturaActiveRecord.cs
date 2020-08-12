using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class LineaDeFacturaActiveRecord
    {
        /*public LineaDeFacturaActiveRecord(int numero, FacturaActiveRecord factura, 
            string producto_Id, int unidades)
        {
            Numero = numero;
            this.factura = factura;
            Producto_Id = producto_Id;
            Unidades = unidades;
        }*/

        public LineaDeFacturaActiveRecord(int numero, int factura_Numero, string producto_Id, int unidades)
        {
            Numero = numero;
            Factura_Numero = factura_Numero;
            Producto_Id = producto_Id;
            Unidades = unidades;
        }



        public int Numero { get; set; }
        public int Factura_Numero { get; set; }
        public string Producto_Id { get; set; }
        public int Unidades { get; set; }

        /*public int Numero { get; set; }
        public FacturaActiveRecord factura { get; set; }
        public string Producto_Id { get; set; }
        public int Unidades { get; set; }*/

        public void Insertar()
        {

                using (
                SqlConnection conexion = new SqlConnection(CadenaConexion()))
                {
                    conexion.Open();
                    String sql = "insert into lineasfactura (numero, factura_numero," +
                    " producto_id, unidades) " +
                        "values (@Numero, @Factura_Numero, @Producto_Id, @Unidades)";
                    SqlCommand comando = new SqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@Numero", Numero);
                    comando.Parameters.AddWithValue("@Factura_Numero", Factura_Numero);
                comando.Parameters.AddWithValue("@Producto_Id", Producto_Id);
                comando.Parameters.AddWithValue("@Unidades", Unidades);
                comando.ExecuteNonQuery();
                }
            

        }

        private static string CadenaConexion()
        {
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["miconexion"];
            String cadena = settings.ConnectionString;
            return cadena;
        }

        public static List<FacturaActiveRecord> BuscarTodos()
        {
            List<LineaDeFacturaActiveRecord> lista = new List<LineaDeFacturaActiveRecord>();
            using (
            SqlConnection conexion = new SqlConnection(CadenaConexion()))
            {
                conexion.Open();
                String sql = "select * from lineasfactura";
                SqlCommand comando = new SqlCommand(sql, conexion);
                SqlDataReader lector = comando.ExecuteReader();
                while(lector.Read())
                {
                    lista.Add(new LineaDeFacturaActiveRecord(Convert.ToInt32(lector["numero"]), Convert.ToInt32(lector["factura_numero"]),
                        lector["Producto_id"].ToString(), Convert.ToInt32(lector["Unidades"])));
                    
                }
                return null;
           
            }
        }

        public override string ToString()
        {
            return Numero + " ";
        }
    }
}
