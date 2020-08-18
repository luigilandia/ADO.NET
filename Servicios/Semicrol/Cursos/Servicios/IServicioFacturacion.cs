using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Servicios
{
    public interface IServicioFacturacion
    {
        void InsertarFactura(Factura f);
        List<Factura> BuscarTodasLasFacturas();

        List<Factura> BuscarTodosConLineas();
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        void Insertar(LineaFactura lf);

        /*
        
        
        
        
        List<Factura> BuscarTodos(FiltroFacturaNuevo filtro);
        Factura BuscarUno(int numero);*/
    }
}
