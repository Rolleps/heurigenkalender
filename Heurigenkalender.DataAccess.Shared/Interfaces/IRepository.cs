using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heurigenkalender.DataAccess.Shared.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T t);
        T Update(T t);
        void Delete(T t);
    }
}
