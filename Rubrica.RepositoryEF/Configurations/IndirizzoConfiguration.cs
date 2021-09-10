using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrica.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubrica.RepositoryEF.Configurations
{
  public class IndirizzoConfiguration : IEntityTypeConfiguration<Indirizzo>
    {
        public void Configure(EntityTypeBuilder<Indirizzo> modelBuilder)
        {
            modelBuilder.ToTable("Indirizzo");
            modelBuilder.HasKey(i => i.IdIndirizzo);
            modelBuilder.Property(i => i.Tipologia).IsRequired();
            modelBuilder.Property(i => i.Via).IsRequired();
            modelBuilder.Property(i => i.Città).IsRequired();
            modelBuilder.Property(i => i.CAP).IsRequired();
            modelBuilder.Property(i => i.Provincia).IsRequired();
            modelBuilder.Property(i => i.Nazione).IsRequired();


            //Relazione 1 a molti (un indirizzo può appartenere ad un unico contatto, ma ad un contatto possono essere associati diversi indirizzi)
            modelBuilder.HasOne(i => i.Contatto).WithMany(c => c.Indirizzi).HasForeignKey(i => i.IdContatto);
  


        }
    }
}
