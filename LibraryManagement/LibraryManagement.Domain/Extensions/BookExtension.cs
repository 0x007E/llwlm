using System.ComponentModel.DataAnnotations;
using LibraryManagement.Domain.Exceptions;

namespace LibraryManagement.Domain.Extensions
{
    public static class BookExtension
    {
        public static Book Validate(this Book book)
        {
            ValidationContext context = new(book);
            List<ValidationResult> results = new();

            if (!Validator.TryValidateObject(book, context, results, true))
            {
                foreach (ValidationResult result in results)
                {
                    throw new BookException(result.MemberNames?.FirstOrDefault(), result.ErrorMessage);
                }
            }
            return book;
        }

        public static Book IsNotNull(this Book book)
        {
            _ = book ?? throw new NullReferenceException(nameof(Book));

            return book;
        }

        public static Book Duplicate(this Book book, IEnumerable<Book> books)
        {
            if(books.Any(b => b.ISBN == book.ISBN))
                throw new BookException(nameof(Book.ISBN), "ISBN exisitert bereits");

            return book;
        }

        public static Book RemoveCharsFromISBN(this Book book)
        {
            book.ISBN = new(book.ISBN.Where(char.IsDigit).ToArray());
            return book;
        }

        public static bool IdExists(this int id, IEnumerable<Book> books)=> books.Any(b => b.Id == id);

        public static bool IdExists(this Book book, IEnumerable<Book> books) => books.Any(b => b.Id == book.Id);

        public static string ToString(this Book book, char seperator) => $"{book.Id}{seperator}{book.ISBN}{seperator}{book.Title}{seperator}{book.Author}";
    }
}
