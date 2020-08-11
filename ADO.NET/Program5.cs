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
            FacturaActiveRecord f1 = new FacturaActiveRecord(4, "Televisor");
            f1.Insertar();
        }
    }
}
