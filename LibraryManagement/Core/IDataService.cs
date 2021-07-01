using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Core
{
    public interface IDataService<T>
    {
        event EventHandler Refresh;
        void Insert(T item);
        void Update(int id, T item);
        void Delete(int id);
        List<T> Get();
    }
}
