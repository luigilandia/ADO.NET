﻿using System;
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
            FacturaActiveRecord f2 = FacturaActiveRecord.BuscarPorConcepto("Televisor");
            Console.WriteLine(f2.Numero);
            Console.WriteLine(f2.Concepto);
            Console.WriteLine(f2.ToString());
            Console.ReadLine();
        }
    }
}
