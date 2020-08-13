using ADO.NET.ActiveRecord;
using ADO.NET.Persistencia.Filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program8
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = new FacturaActiveRecord(1, "comprau");
            //f1.Concepto = "CompraM";
            //f1.Actualizar();
            //f1.Actualizar2();
            List<FacturaActiveRecord> f2 =FacturaActiveRecord.BuscarPorConcepto("Televisor");
            //Console.WriteLine(f2.Numero);
            //Console.WriteLine(f2.Concepto);
            FiltroFacturaNuevo f = new FiltroFacturaNuevo();
            Console.WriteLine(f2.ToString());
   
            List<FacturaActiveRecord> f3 = FacturaActiveRecord.BuscarTodos(f);
            Console.WriteLine(f3.ToString());
            Console.ReadLine();
        }
    }
}
