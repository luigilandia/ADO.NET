using ADO.NET.ActiveRecord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program5
    {
        static void Main(string[] args)
        {
            FacturaActiveRecord f1 = new FacturaActiveRecord(5, "Micro");
            //f1.Insertar();
            //f1.Borrar();
            f1.Borrar2();
            Console.ReadLine();

        }
    }
}
