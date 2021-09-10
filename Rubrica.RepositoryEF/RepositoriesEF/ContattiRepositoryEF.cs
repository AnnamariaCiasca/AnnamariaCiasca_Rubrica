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
    public class ContattiRepositoryEF : IContattiRepository
    {
        public Contatto Add(Contatto item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Add(item);
                ctx.SaveChanges();
            }
            return item;
        }

        public bool Delete(Contatto item)
        {
            using (var ctx = new RubricaContext())
            {
                ctx.Contatti.Remove(item);
                ctx.SaveChanges();
            }
            return true;
        }

        public List<Contatto> Fetch()
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Contatti.Include(c => c.Indirizzi).ToList();
            }
        }

        public Contatto GetById(int idContatto)
        {
            using (var ctx = new RubricaContext())
            {
                return ctx.Contatti.Include(c => c.Indirizzi).FirstOrDefault(c => c.IdContatto == idContatto);
            }
        }

        public Contatto Update(Contatto item)
        {
            throw new NotImplementedException();
        }
    }
}
