using ADO.NET.Persistencia;
using Persistencia.Semicrol.Cursos.Persistencia;
using Semicrol.Cursos.Dominio;
using Semicrol.Cursos.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Semicrol.Cursos.Servicios
{
    class ServicioFacturas : IServicioFacturacion
    {
        private IFacturaRepository repoFacturas;
        private ILineaFacturaRepository repoLineas;

        public ServicioFacturas(IFacturaRepository repoFacturas, ILineaFacturaRepository repoLineas)
        {
            this.repoFacturas = repoFacturas;
            this.repoLineas = repoLineas;
        }

        public List<Factura> BuscarTodasLasFacturas()
        {
            return repoFacturas.BuscarTodos();
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
