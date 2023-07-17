using System.Data;
using Microsoft.Data.Sqlite;
using LibraryManagement.Domain;
using LibraryManagement.Domain.Exceptions;

namespace LibraryManagement.Core.Services.BookDataServices
{
    public class BookSQLiteDataService : BookDataService
    {
        private SqliteConnection _connection;

        public BookSQLiteDataService(SqliteConnection connection)
        {
            _connection = connection ?? throw new NullReferenceException(nameof(SqliteConnection));

            if (_connection.State is not ConnectionState.Open)
                _connection.Open();
        }

        public override void Insert(Book item)
        {
            base.Insert(item);

            using (SqliteCommand cmd = new SqliteCommand())
            {
                cmd.Connection = _connection;
                cmd.CommandText = $"INSERT INTO {nameof(Book)}s ({nameof(Book.ISBN).ToLower()}, {nameof(Book.Title).ToLower()}, {nameof(Book.Author).ToLower()}) VALUES (@ISBN, @TITLE, @AUTHOR);";

                cmd.Parameters.AddWithValue("@ISBN", item.ISBN);
                cmd.Parameters.AddWithValue("@TITLE", item.Title);
                cmd.Parameters.AddWithValue("@AUTHOR", item.Author);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Insert));
            }
        }

        public override void Update(int id, Book item)
        {
            base.Update(id, item);

            using (SqliteCommand cmd = new SqliteCommand())
            {
                cmd.Connection = _connection;
                cmd.CommandText = $"UPDATE {nameof(Book)}s SET {nameof(Book.ISBN).ToLower()}=@ISBN, {nameof(Book.Title).ToLower()}=@TITLE, {nameof(Book.Author).ToLower()}=@AUTHOR WHERE {nameof(Book.Id).ToLower()}=@ID";

                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@ISBN", item.ISBN);
                cmd.Parameters.AddWithValue("@TITLE", item.Title);
                cmd.Parameters.AddWithValue("@AUTHOR", item.Author);


                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Update));
            }
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            using (SqliteCommand cmd = new SqliteCommand())
            {
                cmd.Connection = _connection;
                cmd.CommandText = $"DELETE FROM {nameof(Book)}s WHERE {nameof(Book.Id).ToLower()}=@ID";

                cmd.Parameters.AddWithValue("@ID", id);


                if (cmd.ExecuteNonQuery() != 1)
                    throw new BookException(nameof(Update), string.Empty);
            }
        }

        public override List<Book> GetAll()
        {
            List<Book> books = new();

            using (SqliteCommand cmd = new SqliteCommand())
            {
                cmd.Connection = _connection;
                cmd.CommandText = $"SELECT {nameof(Book.Id)}, {nameof(Book.ISBN)}, {nameof(Book.Title)}, {nameof(Book.Author)} FROM {nameof(Book)}s;";

                using (SqliteDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new()
                        {
                            Id = reader.GetInt32(nameof(Book.Id)),
                            ISBN = reader.GetString(nameof(Book.ISBN)),
                            Title = reader.GetString(nameof(Book.Title)),
                            Author = reader.GetString(nameof(Book.Author))
                        });
                    }
                }
            }

            return books;
        }

        public void Close() => _connection.Close();

        public override void Dispose() => Close();
    }
}
