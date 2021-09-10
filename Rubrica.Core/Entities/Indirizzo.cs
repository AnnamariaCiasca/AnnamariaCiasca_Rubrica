using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.Entities
{
   public class Indirizzo
    {
        public int IdIndirizzo { get; set; }
        public string Tipologia { get; set; }
        public string Via { get; set; }
        public string Città { get; set; }
        public int CAP { get; set; }
        public string Provincia { get; set; }
        public string Nazione { get; set; }

        //FK
        public int IdContatto { get; set; }
        public Contatto Contatto { get; set; }




        public override string ToString()
        {
            return $"{IdIndirizzo}\t{Tipologia}\t{Via}\t{Città}\t{CAP}\t{Provincia}\t{Nazione}";
        }
    }
}
