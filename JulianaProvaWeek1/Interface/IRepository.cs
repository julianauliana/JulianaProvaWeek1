using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JulianaProvaWeek1.Interface
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        bool Add(T item);
        T GetbyCode(string codice);
    }
}
