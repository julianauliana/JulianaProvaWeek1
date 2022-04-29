using JulianaProvaWeek1.Entities;
using JulianaProvaWeek1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Repository
{
    public class RepositoryAlimentareFile : IRepository<Alimentari>
    {
        string path = @"C:\Users\j.de.carvalho.uliana\Desktop\Academy\Week 1 - 26.04\Prova\Week1JulianaProvaWeek1\JulianaProvaWeek1\Repository\Alimentare.txt";
        public bool Add(Alimentari item)
        {
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine($"{item.Codice},{item.Descrizione},{item.Prezzo},{item.Quantita},{item.DataScadenza}");
            }
            return true;
        }

        public List<Alimentari> GetAll()
        {
            List<Alimentari> listaAlimentari = new List<Alimentari>();
            using (StreamReader sr = new StreamReader(path))
            {
                
                string contenutoFile = sr.ReadToEnd();

                if(string.IsNullOrEmpty(contenutoFile))
                {
                    return listaAlimentari;
                }
                else
                {
                    var righeDelFile = contenutoFile.Split("\r\n");
                    for (int i = 0; i < righeDelFile.Length; i++)
                    {
                        var campiDellaRiga = righeDelFile[i].Split(",");
                        Alimentari a = new Alimentari();
                        a.Codice = campiDellaRiga[0];
                        a.Descrizione = campiDellaRiga[1];
                        a.Prezzo = double.Parse(campiDellaRiga[2]);
                        a.Quantita = int.Parse(campiDellaRiga[3]);
                        a.DataScadenza = DateTime.Parse(campiDellaRiga[4]);
                        listaAlimentari.Add(a);
                    }
                    
                }
                return listaAlimentari;

            }
        }

        public Alimentari GetbyCode(string codice)
        {

            using (StreamReader sr = new StreamReader(path))
            {
                string contenutoFile = sr.ReadToEnd();
                var righeDelFile = contenutoFile.Split("\r\n");
                for (int i = 0; i < righeDelFile.Length; i++)
                {
                    var campiDellaRiga = righeDelFile[i].Split(",");
                    Alimentari a = new Alimentari();
                    a.Codice = campiDellaRiga[0];
                    a.Descrizione = campiDellaRiga[1];
                    a.Prezzo = double.Parse(campiDellaRiga[2]);
                    a.Quantita = int.Parse(campiDellaRiga[3]);
                    a.DataScadenza = DateTime.Parse(campiDellaRiga[4]);
                    if (campiDellaRiga[0] == codice)
                    {
                        return a;
                    }

                    
                }
                return null;


            }
        }
    }
}
