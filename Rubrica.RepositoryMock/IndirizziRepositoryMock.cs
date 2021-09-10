using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
   public class IndirizziRepositoryMock : IIndirizziRepository
    {
        public static List<Indirizzo> Indirizzi = new List<Indirizzo>()
        {
            new Indirizzo{IdIndirizzo = 1, Tipologia = "Residenza", Via = "Ponzio Pilato 12", CAP = 81020, Città = "Roma", Provincia = "RM", Nazione = "Italia"},
            new Indirizzo{IdIndirizzo = 2, Tipologia = "Ufficio", Via = "Giovanni Pascoli 4", CAP = 00137, Città = "Roma", Provincia = "RM", Nazione = "Italia"},
        };

        public Indirizzo Add(Indirizzo item)
        {
            if (Indirizzi.Count == 0)
            {
                item.IdIndirizzo = 1;
            }
            else
            {
                item.IdIndirizzo = Indirizzi.Max(i => i.IdIndirizzo) + 1;
            }

            var contatto = ContattiRepositoryMock.Contatti.FirstOrDefault(c => c.IdContatto == item.IdContatto);
            item.Contatto = contatto;
            contatto.Indirizzi.Add(item);

            Indirizzi.Add(item);
            return item;
        }

        public bool Delete(Indirizzo item)
        {
            Indirizzi.Remove(item);
            return true;
        }

        public List<Indirizzo> Fetch()
        {
            return Indirizzi;
        }

        public Indirizzo GetById(int idIndirizzo)
        {
            return Indirizzi.FirstOrDefault(i => i.IdIndirizzo == idIndirizzo);
        }

        public Indirizzo Update(Indirizzo item)
        {
            throw new NotImplementedException();
        }
    }
}
