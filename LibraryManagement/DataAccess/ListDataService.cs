using LibraryManagement.Core.Services;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.DataAccess
{
    public class ListDataService : DataService
    {
        private static List<IBook> books;

        public ListDataService(List<IBook> list = null)
        {
            books = list ?? new()
            {
                new Book
                {
                    Id = 1,
                    ISBN = "ISBN 1234-1234",
                    Title = "Test",
                    Author = "Max Mustermann"
                },
                new Book
                {
                    Id = 2,
                    ISBN = "ISBN 1234-3421",
                    Title = "Test2",
                    Author = "Alice Mustermann"
                }
            };
        }

        public override void Insert(IBook item)
        {
            base.Insert(item);

            item.Id = books?.Count > 0 ? books.Last().Id : 1;
            books.Add(item);

            base.DoUpdate(EventArgs.Empty);
        }

        public override void Delete(int id)
        {
            base.Delete(id);
            books.Remove(books.FirstOrDefault(b => b.Id == id));

            base.DoUpdate(EventArgs.Empty);
        }

        public override void Update(int id, IBook item)
        {
            base.Update(id, item);

            IBook b = books.Where(b => b.Id == id).FirstOrDefault();

            b.ISBN = item.ISBN;
            b.Title = item.Title;
            b.Author = item.Author;

            base.DoUpdate(EventArgs.Empty);
        }

        public override List<IBook> Get()
        {
            return books;
        }
    }
}
