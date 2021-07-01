using LibraryManagement.Domain;
using LibraryManagement.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LibraryManagement.Core.Extensions
{
    public static class BookExtension
    {
        public static IBook ValidateBook(this IBook book)
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

        public static IBook ValidateDuplicate(this IBook book, IEnumerable<IBook> books)
        {
            if (Exists(book.ISBN, books))
                throw new Exception(nameof(IBook.ISBN));

            return book;
        }

        public static bool Exists(this int id, IEnumerable<IBook> books)
        {
            if (books.Any(b => b.Id == id))
                return true;

            return false;
        }

        public static bool Exists(this string isbn, IEnumerable<IBook> books)
        {
            if (books.Any(b => b.ISBN == isbn))
                return true;

            return false;
        }
    }
}
