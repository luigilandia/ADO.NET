using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Dominio
{
    public class LineaFactura
    {
        public int Numero { get; set; }
        public int Factura_Numero { get; set; }
        public string Producto_Id { get; set; }
        public int Unidades { get; set; }
    }
}
