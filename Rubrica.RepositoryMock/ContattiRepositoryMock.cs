using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryMock
{
    public class ContattiRepositoryMock : IContattiRepository 
    {
        public static List<Contatto> Contatti = new List<Contatto>()
        {
            new Contatto{IdContatto = 1, Nome = "Marco", Cognome = "Rossi"},
            new Contatto{IdContatto = 2, Nome = "Luisa", Cognome = "Neri"}
        };

        public Contatto Add(Contatto item)
        {
            if (Contatti.Count == 0)
            {
                item.IdContatto = 1;
            }
            else
            {
                item.IdContatto = Contatti.Max(c => c.IdContatto) + 1;
            }

            Contatti.Add(item);
            return item;
        }

        public bool Delete(Contatto item)
        {
            Contatti.Remove(item);
            return true;
        }

        public List<Contatto> Fetch()
        {
            return Contatti;
        }

        public Contatto GetById(int idContatto)
        {
            return Contatti.Find(c => c.IdContatto == idContatto);
        }

        public Contatto Update(Contatto item)
        {
            var old = Contatti.FirstOrDefault(c => c.IdContatto == item.IdContatto);
            old.Nome = item.Nome;
            old.Cognome = item.Cognome;
            return item;
        }
    }
}
