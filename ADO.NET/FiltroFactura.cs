using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class FiltroFactura
    {
        public FiltroFactura(int numero, string concepto)
        {
            Numero = numero;
            Concepto = concepto;
        }

        public FiltroFactura()
        {
        }

        public int Numero { get; set; }
        public string Concepto { get; set; }
    }
}
