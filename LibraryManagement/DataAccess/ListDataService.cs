using LibraryManagement.Core;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess
{
    public class ListDataService : DataService
    {
        private static List<Book> books = new()
        {
            new Book
            {
                Id = 1,
                ISBN = "123-1234567890",
                Title = "Gregs Tagebuch",
                Author = "Greg"
            },
            new Book
            {
                Id = 2,
                ISBN = "321-1234567890",
                Title = "Eine unendliche Geschichte der Zeit",
                Author = "Stephen Hawking"
            }
        };

        public override void Insert(Book item)
        {
            base.Insert(item);

            item.Id = books?.Count > 0 ? (books.Last().Id + 1) : 1;
            books.Add(item);
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            Book b = books?.FirstOrDefault(x => x.Id == id);

            b.ISBN = item.ISBN;
            b.Title = item.Title;
            b.Author = item.Author;
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            books.Remove(books.FirstOrDefault(x => x.Id == id));
        }

        public override List<Book> Get() => books;

        public override void Dispose()
        {
            books?.Clear();
        }
    }
}
