﻿using ADO.NET.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program6
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = new FacturaActiveRecord(4, "Televisor");
            List<FacturaActiveRecord> lista = FacturaActiveRecord.BuscarTodos();

         

            foreach (FacturaActiveRecord f in lista)
            {
                Console.WriteLine(f.Concepto);
            }

            Console.ReadLine();


        }
    }
}
