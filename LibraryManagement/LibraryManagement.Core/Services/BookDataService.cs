using LibraryManagement.Domain;
using LibraryManagement.Domain.Extensions;

namespace LibraryManagement.Core.Services
{
    public abstract class BookDataService : IDataService<Book>
    {
        public virtual void Insert(Book item)
        {
            item.IsNotNull()
                .RemoveCharsFromISBN()
                .Validate()
                .Duplicate(GetAll());
        }

        public virtual void Update(int id, Book item)
        {
            if (!item
                .IsNotNull()
                .RemoveCharsFromISBN()
                .Validate()
                .IdExists(GetAll()))
                throw new Exception(nameof(Update));
        }

        public virtual void Delete(int id)
        {
            if (!id.IdExists(GetAll()))
                throw new Exception(nameof(Delete));
        }

        public abstract List<Book> GetAll();

        public abstract void Dispose();
    }
}
