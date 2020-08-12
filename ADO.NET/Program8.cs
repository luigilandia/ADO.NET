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
            f1.Concepto = "CompraH";
            f1.Actualizar();
            Console.ReadLine();
        }
    }
}
