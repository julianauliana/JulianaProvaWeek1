using JulianaProvaWeek1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Interface
{
    public interface IRespositoryTecnologico : IRepository<Tecnologici>
    {
        Tecnologici GetbyMarca(string marca);
    }
}
