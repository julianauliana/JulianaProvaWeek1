using JulianaProvaWeek1.Entities;
using JulianaProvaWeek1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Repository
{
    public class RepositoryProdAlimentareMOCK : IRepository<Alimentari>
    {
        List<Alimentari> alimentare = new List<Alimentari>()
        {
            new Alimentari(){Codice="A1", Descrizione="cereal", Prezzo=2.99,Quantita=3, DataScadenza= new DateTime(2022,05,01)},
            new Alimentari(){Codice="A2", Descrizione="caffe", Prezzo=1.99,Quantita=6, DataScadenza= new DateTime(2022,04,30)},
            new Alimentari(){Codice="A3", Descrizione="te", Prezzo=2.99,Quantita=10, DataScadenza= new DateTime(2022,05,02)},
            new Alimentari(){Codice="A4", Descrizione="latte", Prezzo=0.99,Quantita=10, DataScadenza= new DateTime(2022,05,02)},
            new Alimentari(){Codice="A5", Descrizione="latte", Prezzo=0.99,Quantita=4, DataScadenza= new DateTime(2022,04,29)},
        };
 
        public bool Add(Alimentari item)
        {

            if (item == null)
            {
                return false;
            }
            alimentare.Add(item);
            return true;
        }
       
        List<Alimentari> IRepository<Alimentari>.GetAll()
        {
            return alimentare;
        }

        Alimentari IRepository<Alimentari>.GetbyCode(string codice)
        {
            foreach (var item in alimentare)
            {
                if (item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
