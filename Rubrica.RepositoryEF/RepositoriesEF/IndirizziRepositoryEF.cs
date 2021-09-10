using Microsoft.EntityFrameworkCore;
using Rubrica.Core.Entities;
using Rubrica.Core.InterfaceRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryEF.RepositoriesEF
{
    public class IndirizziRepositoryEF : IIndirizziRepository
    {
        public Indirizzo Add(Indirizzo item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

            public bool Delete(Indirizzo item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Indirizzi.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Indirizzo> Fetch()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Indirizzi.Include(x => x.Contatto).ToList();
            }
        }

        public Indirizzo GetById(int idIndirizzo)
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Indirizzi.Include(x => x.Contatto).FirstOrDefault(i => i.IdIndirizzo == idIndirizzo);
            }
        }

        public Indirizzo Update(Indirizzo item)
        {
            throw new NotImplementedException();
        }
    }
}
