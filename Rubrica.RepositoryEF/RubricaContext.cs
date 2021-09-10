using Microsoft.EntityFrameworkCore;
using Rubrica.Core.Entities;
using Rubrica.RepositoryEF.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryEF
{
    public class RubricaContext : DbContext
    {
       
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Indirizzo> Indirizzi { get; set; }
   


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; 
                                          Database=Rubrica; 
                                          Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contatto>(new ContattoConfiguration());
            modelBuilder.ApplyConfiguration<Indirizzo>(new IndirizzoConfiguration());
        }
    }
}
