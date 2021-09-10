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
   public class ContattoConfiguration : IEntityTypeConfiguration<Contatto>
    {
        public void Configure(EntityTypeBuilder<Contatto> modelBuilder)
        {
            modelBuilder.ToTable("Contatto"); 
            modelBuilder.HasKey(c => c.IdContatto); 
            modelBuilder.Property(c => c.Nome).IsRequired();
            modelBuilder.Property(c => c.Cognome).IsRequired();

            //Relazione 1 a molti (1 solo contatto può avere più indirizzi)
            modelBuilder.HasMany(c => c.Indirizzi).WithOne(i => i.Contatto).HasForeignKey(i => i.IdContatto);

            
        }
    }
}
