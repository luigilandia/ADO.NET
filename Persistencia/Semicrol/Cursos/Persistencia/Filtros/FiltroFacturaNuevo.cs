using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semicrol.Cursos.Persistencia.Filtros
{
    public class FiltroFacturaNuevo
    {
        private int _numero;
        private string _concepto;

        public int Numero
        {
            get
            {
                return _numero;
            }

        }

        public string Concepto
        {
            get
            {
                return _concepto;
            }

        }

        //programación fluida
        public FiltroFacturaNuevo AddConcepto(string concepto)
        {
            this._concepto = concepto;
            return this;
        }

        public FiltroFacturaNuevo AddNumero(int numero)
        {
            this._numero = numero;
            return this;
        }

        
    }
}
