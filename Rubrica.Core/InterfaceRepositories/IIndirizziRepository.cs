using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.Core.InterfaceRepositories
{
  public interface IIndirizziRepository : IRepository<Indirizzo>
    {
        public Indirizzo GetById(int idIndirizzo);
    }
}

