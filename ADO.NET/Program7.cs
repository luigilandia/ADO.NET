using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program7
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f= FacturaActiveRecord.BuscarUna(58);
            Console.WriteLine(f.Concepto);
            Console.ReadLine();
        }
    }
}
