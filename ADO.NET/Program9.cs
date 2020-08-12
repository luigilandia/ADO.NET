using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program9
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = new FacturaActiveRecord(1, "cable");
            //LineaDeFacturaActiveRecord lf1 = new LineaDeFacturaActiveRecord(1, f1, "456", 8);
            //List<LineaDeFacturaActiveRecord> lf3 = f1.BuscarTodos2();
            /*foreach (LineaDeFacturaActiveRecord lfr in lf3)
            {
                Console.WriteLine(lfr.ToString());
            }*/
            List<FacturaLineaDTO> fldto = FacturaActiveRecord.BuscarTodasFacturasLineas();
            foreach (FacturaLineaDTO lf in fldto)
            {
                Console.WriteLine(lf.Concepto);
                //Console.WriteLine(lf.NumeroFactura);
            }
            
            Console.WriteLine();
            Console.ReadLine();
            //lf1.Insertar();

            

            
        }
    }
}
