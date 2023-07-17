using LibraryManagement.Domain;

namespace LibraryManagement.Core
{
    public interface IDataService<T> : IDisposable
    {
        void Delete(int id);
        void Insert(T item);
        void Update(int id, T item);
        List<T> GetAll();
    }
}