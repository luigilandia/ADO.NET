using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.Persistencia
{
    public interface IFacturaLineaRepository
    {
        void Insertar(Factura factura);
        void Borrar(Factura factura);
        void Actualizar(Factura factura);
        List<Factura> BuscarTodos();

        Factura BuscarUno(int numero);
    }
}
