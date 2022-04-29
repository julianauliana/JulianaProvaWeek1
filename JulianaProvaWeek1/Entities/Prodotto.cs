﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Entities
{
        public abstract class Prodotto
        {
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public double Prezzo { get; set; }

        public Prodotto()
        {

        }

        public Prodotto(string codice, string descrizione, double prezzo)
        {
            Codice = codice;
            Descrizione = descrizione;
            Prezzo = prezzo;    
        }

        public override string ToString()
        {
            return $"Codice {Codice} - Descrizione {Descrizione} \tPrezzo: {Prezzo} \t";
        }

    }
}
