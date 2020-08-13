using ADO.NET.ActiveRecord;

using ADO.NET.Persistencia;
using ADO.NET.Persistencia.Filtros;
using Semicrol.Cursos.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO.NET
{
    class Program10
    {
        static void Main(string[] args)
        {
            FacturaRepository repositorio = new FacturaRepository();
            //repositorio.Insertar(new Factura(21, "tablet"));
            //repositorio.Borrar(new Factura(20));
            Factura factura=repositorio.BuscarUno(1);
            //Console.WriteLine(factura.Concepto);
            List<Factura> facturas = repositorio.BuscarTodos();
            /*foreach(Factura f in facturas)
            {
                Console.WriteLine(f.Numero);
                Console.WriteLine(f.Concepto);
            }*/
            //FiltroFactura filtro = new FiltroFactura();
            //filtro.Numero = 4;
            //filtro.Concepto = "Televisor";
            //FiltroFacturaNuevo filtro = new FiltroFacturaNuevo();
            //FiltroFacturaNuevo otro= filtro.AddConcepto("Televisor").AddNumero(1);
            //List<Factura> facturas2 = repositorio.BuscarTodos(otro);
            /*foreach (Factura f in facturas2)
            {
                Console.WriteLine(f.Numero);
                Console.WriteLine(f.Concepto);
            }*/

            //List<FacturaLineaDTO> fc=repositorio.BuscarTodasFacturasLineas();
            //Console.WriteLine(fc.ToString());
            FiltroFacturaNuevo filtro = new FiltroFacturaNuevo();
            filtro.AddConcepto("Televisor").AddNumero(1);
            
            Console.ReadLine();
        }
    }
}
