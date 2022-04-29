using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Entities
{
    public class Alimentari : Prodotto
    {
       public int Quantita { get; set; }
       public DateTime DataScadenza { get; set; }
        public int GiorniMancano { get { return CalcoloGiorni(); } }

        public Alimentari ()
        {

        }
        public Alimentari (string codice, string descrizione, double prezzo, int quantita, DateTime dataScadenza, int giorniMancano)
            :base (codice, descrizione, prezzo)
        {
            Quantita = quantita;   
            DataScadenza = dataScadenza;
            
        }

        private int CalcoloGiorni()
        {
            return (int)DataScadenza.Subtract(DateTime.Today).TotalDays;
        }

        public override string ToString()
        {
            return base.ToString() + $"Quantita {Quantita} - Scadenza {DataScadenza.ToShortDateString()} - Giorni mancano per scadenza {GiorniMancano}";
        }
    }
}
