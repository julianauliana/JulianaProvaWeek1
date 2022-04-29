using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Entities
{
    public class Tecnologici : Prodotto
    {
        public string Marca { get; set; }
        public bool Usato { get; set; }

        public Tecnologici()
        {

        }

        public Tecnologici (string codice, string descrizione, double prezzo, string marca, bool usato)
            :base (codice, descrizione, prezzo)
        {
            Marca = marca;
            Usato = usato;
        }

        public override string ToString()
        {
            return base.ToString();
        }


    }
}
