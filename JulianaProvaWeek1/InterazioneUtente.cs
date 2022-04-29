using JulianaProvaWeek1.Entities;
using JulianaProvaWeek1.Interface;
using JulianaProvaWeek1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1
{
    internal class InterazioneUtente
    {
       // static IRepository<Alimentari> repoAlimentari = new RepositoryProdAlimentareMOCK();
        static IRepository<Alimentari> repoAlimentari = new RepositoryAlimentareFile();
        
        //static IRepository<Tecnologici> repoTecnologici = new RepositoryProdTecnologicoMOCK();
        static RepositoryProdTecnologicoMOCK repoTecnologici = new RepositoryProdTecnologicoMOCK();

        internal static void Start()
        {
            bool continua = true;
            while (continua) // equivale continua==true 
            {
                int scelta = Menu();
                switch (scelta)
                {
                    case 1:
                       VisualizzaTuttiProdotti();
                        break;
                    case 2:
                        VisuzlizzaProdottiAlimentari();
                        break;
                    case 3:
                        VisualizzaProdottiTecnologici();
                        break;
                    case 4:
                      AggiungiNuovoProdottoTecnologico();
                        break;
                    case 5:
                        AggiungiNuovoProdottoAlimentare();
                        break;
                    case 6:
                        CercaProdottoAlimentarePerCodice();
                        break;
                    case 7:
                        CercaProdottoTecnologicoPerMarca();
                        break;
                    case 8:
                        VisualizzareProdottoTecnologicoNuovo();
                        break;
                    case 9:
                        VisualizzaProdottoScadenzaOggi();
                        break;
                    case 10:
                        VisualizzaProdottoScadenzaTreGiorni();
                        break;
                    case 0:
                        continua = false;
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta errata");
                        break;

                }
            }

            
        }

        private static void VisualizzaProdottoScadenzaTreGiorni()
        {
            bool esito = false;
            var listaProdottiAlimentare = repoAlimentari.GetAll();
            foreach (var item in listaProdottiAlimentare)
            {
                if (item.GiorniMancano <= 3)
                {
                    Console.WriteLine(item.ToString());
                    esito = true;
                }
            }
            if (esito == false)
            {
                Console.WriteLine("Senza prodotto in scadenza tra 3 giorni");
            }
        }

        private static void VisualizzaProdottoScadenzaOggi()
        {
            bool esito=false;
            var listaProdottiAlimentare = repoAlimentari.GetAll();
            foreach (var item in listaProdottiAlimentare)
            {
                if (item.GiorniMancano == 0)
                {
                    Console.WriteLine(item.ToString());
                    esito = true;
                }
            }
            if (esito == false)
            {
                Console.WriteLine("Senza prodotto in scadenza oggi");
            }
        }

        private static void VisualizzareProdottoTecnologicoNuovo()
        {
            var listaProdottiTec = repoTecnologici.GetAll();
            foreach (var item in listaProdottiTec)
            {
                if(item.Usato == false)
                {
                    Console.WriteLine(item.ToString());
                }
            }

        }

        private static void CercaProdottoTecnologicoPerMarca()
        {
            Console.WriteLine("inserisci la marca che vuoi cercare:");
            var marca1 = Console.ReadLine();
            var listaTecnologico = repoTecnologici.GetbyMarca(marca1);
            if (listaTecnologico == null)
            {
                Console.WriteLine("non ha prodotti tecnologico con questo marca");
            }
            else
            {
                Console.WriteLine(listaTecnologico.ToString());
            }
            

            //una altra forma de cercare per marca 

            //Console.WriteLine("Inserisci la marca che vuoi cercare");
            //string marca1 = Console.ReadLine();
            //var listaTecnologico = repoTecnologici.GetAll();
            //foreach (var t in listaTecnologico)
            //{
            //    if (t.Marca == marca1)
            //    {
            //        Console.WriteLine(t);
            //        return;
            //    }
            //}
            //Console.WriteLine("codice inesistente");
        }

        private static void CercaProdottoAlimentarePerCodice()
        {
            Console.WriteLine("Inserisci il codice che vuoi cercare");
            string codiceA1 = Console.ReadLine();
            var listaAlimentare = repoAlimentari.GetbyCode(codiceA1);
                if (listaAlimentare.Codice == codiceA1)
                {
                    Console.WriteLine(listaAlimentare.ToString());
                    return;
                }
                else
                {

                Console.WriteLine("codice inesistente");
                }
            
            
                // altra forma di cercare prodotti alimentare per codice 



            //Console.WriteLine("Inserisci il codice che vuoi cercare");
            //string codiceA1 = Console.ReadLine();
            //var listaAlimentare = repoAlimentari.GetAll();
            //foreach (var a in listaAlimentare)
            //{
            //    if(a.Codice == codiceA1)
            //    {
            //        Console.WriteLine(a);
            //        return;
            //    }
            //}
            //Console.WriteLine("codice inesistente");
               
            
        }

        private static void AggiungiNuovoProdottoAlimentare()
        {
            string codiceA;
            do
            {
                Console.WriteLine("codice gia esistente, riprova:");
                codiceA = Console.ReadLine();

            } while (!(repoAlimentari.GetbyCode(codiceA) == null));
            Console.WriteLine("inserisci codice prodotto:");
            
            Console.WriteLine("Inserisci la descrizione del prodotto:");
            string descrizioneA = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo del prodotto:");
            double prezzoA = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la quantita del prodotto:");
            int quantita = int.Parse(Console.ReadLine());
            DateTime dataScadenza;
            do
            {
                Console.WriteLine("inserisci la data di scadenza:");
            } while (!(DateTime.TryParse(Console.ReadLine(), out dataScadenza) && dataScadenza>DateTime.Now));


            var nuovoAlimentare = new Alimentari() { Codice = codiceA, Descrizione = descrizioneA, Prezzo = prezzoA, Quantita=quantita, DataScadenza= dataScadenza };

            var esito = repoAlimentari.Add(nuovoAlimentare);
            if (esito == true)
            {
                Console.WriteLine("Prodotto alimentare aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("errore");
            }
        }

        private static void AggiungiNuovoProdottoTecnologico()
        {
            string codiceT;
            do
            {
                Console.WriteLine("codice gia esistente, riprova:");
                codiceT = Console.ReadLine();

            } while (!(repoTecnologici.GetbyCode(codiceT) == null));

            Console.WriteLine("inserisci codice prodotto:");
            Console.WriteLine("Inserisci la descrizione del prodotto:");
            string descrizioneT = Console.ReadLine();
            Console.WriteLine("Inserisci il prezzo del prodotto:");
            double prezzoT = double.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci la marca del prodotto:");
            string marcaT = Console.ReadLine();
            bool usato;
            do
            {
                Console.WriteLine("il prodotto è usato(true, false):");
            }while(!bool.TryParse(Console.ReadLine(), out usato));
            
            var nuovoTecnologico = new Tecnologici() {Codice = codiceT, Descrizione=descrizioneT, Prezzo=prezzoT,Marca=marcaT,Usato=usato};

            var esito = repoTecnologici.Add(nuovoTecnologico);
            if(esito == true)
            {
                Console.WriteLine("Prodotto tecnologico aggiunto corretamente");
            }
            else
            {
                Console.WriteLine("errore");
            }
            
        }

        private static void VisualizzaProdottiTecnologici()
        {
            var listaTecnologici = repoTecnologici.GetAll();
            if (listaTecnologici.Count == 0)
            {
                Console.WriteLine("Lista Vuota");
            }
            else
            {
                Console.WriteLine("ecco l'elenco dei prodotti tecnologici");
                foreach (var t in listaTecnologici)
                {
                    Console.WriteLine(t);
                }
            }
        }

        private static void VisuzlizzaProdottiAlimentari()
        {
            var listaAlimentare = repoAlimentari.GetAll();
            if (listaAlimentare.Count == 0)
            {
                Console.WriteLine("Lista Vuota");
            }
            else
            {
                Console.WriteLine("ecco l'elenco dei prodotti alimentare");
                foreach (var a in listaAlimentare)
                {
                    Console.WriteLine(a);
                }
            }
        }

        private static void VisualizzaTuttiProdotti()
        {
            Console.WriteLine("Tutti i prodotti sono: ");
            var listaAlimentareRecuperata = repoAlimentari.GetAll();
            var listaTecnologici = repoTecnologici.GetAll();
            List<Prodotto> listaCompleta = new List<Prodotto>();
            listaCompleta.AddRange(listaAlimentareRecuperata);
            listaCompleta.AddRange(listaTecnologici);

            foreach (var item in listaCompleta)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static int Menu()
        {
            Console.WriteLine("HELLOOO RENATA");
            Console.WriteLine("cosa vuoi fare oggi? \n");

            Console.WriteLine("---------------Menu--------------");
            Console.WriteLine("1.Visualizza tutti i prodotti presente in store");
            Console.WriteLine("2.Visuzlizzare solo i prodotti alimentari");
            Console.WriteLine("3.Visualizzare solo i prodotti tecnologici");
            Console.WriteLine("4.Aggiungi nuovo prodotto tecnologico");
            Console.WriteLine("5.Aggiungi nuovo prodotto alimentare");
            Console.WriteLine("6.Cercare un prodotto alimentare per codice");
            Console.WriteLine("7. Cercare un prodotto tecnologico per marca");
            Console.WriteLine("8. Visualizzare i prodotti tecnologici nuovi");
            Console.WriteLine("9. Visualizzare i prodotti alimentari in scadenza oggi");
            Console.WriteLine("10. Visualizzare i prodotti alimentari che scadono tra meno 3 giorni");

            Console.WriteLine("\n 0. Exit");
            Console.WriteLine("\n Inserisci la tua scelta");

            //int sceltaUtente=int.Parse(Console.ReadLine());
            int sceltaUtente;
            while (!int.TryParse(Console.ReadLine(), out sceltaUtente) && sceltaUtente>=0 && sceltaUtente<=10)
            {
                Console.WriteLine("Riprova, devi inserire un numero intero");
            }
            return sceltaUtente;
        }
    }
}
