using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
   public interface IBusinessLayer
    {
        #region Funzionalità Contatti
        
        public List<Contatto> FetchContatti();
  
        public string InserisciNuovoContatto(Contatto newContatto);

        public string EliminaContatto(int idContattoDaEliminare);

        #endregion





        #region Funzionalità Indirizzi

        public List<Indirizzo> FetchIndirizzi();

        public string InserisciNuovoIndirizzo(Indirizzo newIndirizzo);


        #endregion
    }
}
