﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rubrica.RepositoryEF;

namespace Rubrica.RepositoryEF.Migrations
{
    [DbContext(typeof(RubricaContext))]
    [Migration("20210910090304_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Property<int>("IdContatto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdContatto");

                    b.ToTable("Contatto");
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.Property<int>("IdIndirizzo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CAP")
                        .HasColumnType("int");

                    b.Property<string>("Città")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdContatto")
                        .HasColumnType("int");

                    b.Property<string>("Nazione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("Tipologia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Via")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdIndirizzo");

                    b.HasIndex("IdContatto");

                    b.ToTable("Indirizzo");
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Indirizzo", b =>
                {
                    b.HasOne("Rubrica.Core.Entities.Contatto", "Contatto")
                        .WithMany("Indirizzi")
                        .HasForeignKey("IdContatto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contatto");
                });

            modelBuilder.Entity("Rubrica.Core.Entities.Contatto", b =>
                {
                    b.Navigation("Indirizzi");
                });
#pragma warning restore 612, 618
        }
    }
}
