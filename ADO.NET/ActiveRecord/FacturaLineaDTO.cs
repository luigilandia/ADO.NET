using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET.ActiveRecord
{
    public class FacturaLineaDTO
    {
        public FacturaLineaDTO(int numeroFactura, string concepto, int unidades, string producto_Id)
        {
            NumeroFactura = numeroFactura;
            Concepto = concepto;
            Unidades = unidades;
            Producto_Id = producto_Id;
        }

        public int NumeroFactura { get; set; }
        public string Concepto { get; set; }
        public int Unidades { get; set; }
        public string Producto_Id { get; set; }


    }
}
