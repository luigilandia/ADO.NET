using ADO.NET.Persistencia;
using Persistencia.Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Servicios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Semicrol.Cursos.Servicios
{
    public class ServicioFacturas : IServicioFacturacion
    {
        private IFacturaRepository repoFacturas;
        private ILineaFacturaRepository repoLineas;

        public ServicioFacturas(IFacturaRepository repoFacturas, ILineaFacturaRepository repoLineas)
        {
            this.repoFacturas = repoFacturas;
            this.repoLineas = repoLineas;
        }

        public void Actualizar(Factura factura)
        {
            repoFacturas.Actualizar(factura);
        }

        public void Borrar(Factura factura)
        {
            repoFacturas.Borrar(factura);
        }

        public List<Factura> BuscarTodasLasFacturas()
        {
            return repoFacturas.BuscarTodos();
        }

        public List<Factura> BuscarTodosConLineas()
        {
            return repoFacturas.BuscarTodosConLineas();
        }

        public void Insertar(LineaFactura lf)
        {
            repoLineas.Insertar(lf);
        }

        public void InsertarFactura(Factura f)
        {
            repoFacturas.Insertar(f);
            foreach (LineaFactura lf in f.lineas)
            {
                repoLineas.Insertar(lf);
            }
        }
    }
}
