using JulianaProvaWeek1.Entities;
using JulianaProvaWeek1.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Repository
{
    internal class RepositoryProdTecnologicoMOCK : IRespositoryTecnologico
    {
        List<Tecnologici> tecnologico = new List<Tecnologici>()
        {
            new Tecnologici() {Codice = "T1", Descrizione = "celullare", Prezzo= 600.00, Marca="Apple", Usato=false},
            new Tecnologici() {Codice = "T2", Descrizione = "tablet", Prezzo= 900.00, Marca="Apple", Usato=false},
            new Tecnologici() {Codice = "T3", Descrizione = "hub", Prezzo= 50.00, Marca="dell", Usato=false}

          };
        public bool Add(Tecnologici item)
        {
            if (item == null)
            {
                return false;
            }
            tecnologico.Add(item);
            return true;
        }

        public List<Tecnologici> GetAll()
        {
            return tecnologico;
        }

        public Tecnologici GetbyCode(string codice)
        {
            foreach (var item in tecnologico)
            {
                if(item.Codice == codice)
                {
                    return item;
                }
            }
            return null;
        }

        public Tecnologici GetbyMarca(string marca)
        {
            foreach (var item in tecnologico)
            {
                if (item.Marca == marca)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
