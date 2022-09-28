using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IDAL
{
    public interface I_Base<T>
    {
        List<T> List();
        T FindByID(int id);
        void Add(T entity);
        void Delete(int id);
        void Update(int id, T entity);
    }
}
