using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {
        public LineaFactura(int numero, Factura factura)
        {
            Numero = numero;
            this.factura = factura;
        }

        public Factura factura { get; set; }
        public int Numero { get; set; }
        public string Producto_Id { get; set; }
        public int Unidades { get; set; }

        public override bool Equals(object obj)
        {
            var factura = obj as LineaFactura;
            return factura != null &&
                   Numero == factura.Numero;
        }

        public override int GetHashCode()
        {
            return -1449941195 + Numero.GetHashCode();
        }
    }
}
