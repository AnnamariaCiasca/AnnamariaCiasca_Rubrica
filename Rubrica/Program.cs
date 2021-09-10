using Rubrica.Core.BusinessLayer;
using Rubrica.Core.Entities;
using Rubrica.RepositoryEF.RepositoriesEF;
using Rubrica.RepositoryMock;
using System;

namespace Rubrica
{
    class Program
    {

        //private static readonly IBusinessLayer bl = new MainBusinessLayer(new ContattiRepositoryMock(), new IndirizziRepositoryMock());
        private static readonly IBusinessLayer bl = new MainBusinessLayer(new ContattiRepositoryEF(), new IndirizziRepositoryEF());
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto!\n");
            bool continua = true;
            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n**********************Menu**********************");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("1. Visualizza tutti i Contatti");  //ok
            Console.WriteLine("2. Inserisci un nuovo Contatto");  //ok
            Console.WriteLine("3. Associa un nuovo Indirizzo ad un Contatto"); //ok
            Console.WriteLine("4. Elimina Contatto");  //ok

            //Exit
            Console.WriteLine("\n0. Exit");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("********************************************");
            Console.ForegroundColor = ConsoleColor.White;

            int scelta;
            Console.Write("Inserisci scelta:\n");
            while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 4)
            {
                Console.Write("\nScelta errata. Inserisci scelta corretta: ");
            }
            return scelta;
        }



        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    VisualizzaContatti();
                    break;
                case 2:
                    InserisciNuovoContatto();
                    break;
                case 3:
                    InserisciNuovoIndirizzo();
                    break;
                case 4:
                    EliminaContatto();
                    break;

                case 0:
                    return false;
            }
            return true;
        }

        private static void EliminaContatto()
        {
            Console.WriteLine("Ecco l'elenco dei Contatti presenti in Rubrica:");
            VisualizzaContatti();
            Console.WriteLine("\nQuale Contatto vuoi eliminare? Inserisci il codice");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Inserire valore corretto");
            }
            string esito = bl.EliminaContatto(id);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoIndirizzo()
        {
            Console.WriteLine("\nInserisci Tipologia");
            string descrizione = Console.ReadLine();
            Console.WriteLine("\nInserisci Via");
            string via = Console.ReadLine();
            Console.WriteLine("\nInserisci Città");
            string città = Console.ReadLine();
            Console.WriteLine("\nInserisci CAP");
            int cap;
            while (!int.TryParse(Console.ReadLine(), out cap))
            {
                Console.WriteLine("Inserire valore corretto");
            }

            Console.WriteLine("\nInserisci Provincia");
            string provincia = Console.ReadLine();

            Console.WriteLine("\nInserisci Nazione");
            string nazione = Console.ReadLine();



            VisualizzaContatti();
            Console.WriteLine("\nInserisci l'id del contatto a cui è associato questo indirizzo ");
            int idContatto;
            while (!int.TryParse(Console.ReadLine(), out idContatto))
            {
                Console.WriteLine("Inserire valore corretto");
            }


            Indirizzo newIndirizzo = new Indirizzo();
            newIndirizzo.Tipologia = descrizione;
            newIndirizzo.Via = via;
            newIndirizzo.CAP = cap;
            newIndirizzo.Città = città;
            newIndirizzo.Provincia = provincia;
            newIndirizzo.Nazione = nazione;
            newIndirizzo.IdContatto = idContatto;


            var esito = bl.InserisciNuovoIndirizzo(newIndirizzo);
            Console.WriteLine(esito);
        }

        private static void InserisciNuovoContatto()
        {
            
            Console.WriteLine("Inserisci Nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Inserisci Cognome: ");
            string cognome = Console.ReadLine();

        
            Contatto newContatto = new Contatto();
            newContatto.Nome = nome;
            newContatto.Cognome = cognome;

        
            string esito = bl.InserisciNuovoContatto(newContatto);
            Console.WriteLine(esito);
        }

        private static void VisualizzaContatti()
        {
            var contatti = bl.FetchContatti();
            if (contatti.Count == 0)
            {
                Console.WriteLine("Lista vuota. Non ci sono contatti!");
            }
            else
            {
                Console.WriteLine("\nI Contatti registrati in rubrica sono:");
                foreach (var item in contatti)
                {
                    Console.WriteLine(item.ToString());
                }
            }
        }


    }
}
