using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IContattiRepository cRep;
        private readonly IIndirizziRepository iRep;


        public MainBusinessLayer(IContattiRepository contatti, IIndirizziRepository indirizzi)
        {
            cRep = contatti;
            iRep = indirizzi;
        }

        #region Funzionalità Corsi
        public List<Contatto> FetchContatti()
        {
            return cRep.Fetch();
        }

        public string InserisciNuovoContatto(Contatto newContatto)
        {
           
            Contatto contattoEsistente = cRep.GetById(newContatto.IdContatto);
            if (contattoEsistente != null)
            {
                return "Errore: id Contatto già presente";
            }
            cRep.Add(newContatto);
            return "Contatto aggiunto correttamente";
        }

   

        public string EliminaContatto(int idContattoDaEliminare)
        {
            Contatto contattoEsistente = cRep.GetById(idContattoDaEliminare);
            if (contattoEsistente == null)
            {
                return "Errore: id errato.";
            }

            //non deve essere possibile eliminare un contatto che ha almeno un indirizzo associato
            var indirizzoAssociatoAlContatto = FetchIndirizzi().FirstOrDefault(i=> i.IdContatto == contattoEsistente.IdContatto);
            if (indirizzoAssociatoAlContatto != null)
            {
                return "Impossibile cancellare il contatto perchè risulta associato ad almeno un indirizzo";
            }

            cRep.Delete(contattoEsistente);
            return "Contatto eliminato correttamente";

        }

        #endregion





        #region Funzionalità Indirizzi
        public List<Indirizzo> FetchIndirizzi()
        {
            return iRep.Fetch();
        }

        public string InserisciNuovoIndirizzo(Indirizzo newIndirizzo)
        {

            var contatto = cRep.GetById(newIndirizzo.IdContatto);
            if (contatto == null)
            {
                return "\nId Contatto errato o inesistente";
            }

            iRep.Add(newIndirizzo);
            return "\nIndirizzo aggiunto correttamente";
        }

        #endregion




    }
}
