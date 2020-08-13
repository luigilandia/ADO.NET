
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Persistencia.Filtros;
using System.Collections.Generic;


namespace ADO.NET.Persistencia
{
    public interface IFacturaRepository
    {
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> BuscarTodos();
        List<Factura> BuscarTodos(FiltroFacturaNuevo filtro);
        Factura BuscarUno(int numero);

    }
}
