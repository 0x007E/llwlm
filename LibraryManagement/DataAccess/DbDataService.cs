using LibraryManagement.Core.Services;
using LibraryManagement.DataAccess.Extensions;
using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess
{
    public class DbDataService : DataService, IDisposable
    {
        private const string sqlFileExtension = ".sql";

        private DbConnection Connection { get; set; }
        private DirectoryInfo Storage { get; set; }

        public DbDataService(DbConnection connection, DirectoryInfo storage)
        {
            this.Connection = connection ?? throw new NullReferenceException(nameof(Connection));
            this.Storage = storage ?? throw new NullReferenceException(nameof(Storage));

            if (!Directory.Exists(Storage.FullName))
                throw new DirectoryNotFoundException(nameof(Storage));

            if (this.Connection.State != ConnectionState.Open)
                this.Connection.Open();
        }

        public override void Insert(IBook item)
        {
            base.Insert(item);

            using (DbCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = File.ReadAllText(Path.Combine(this.Storage.ToString(), nameof(Insert) + sqlFileExtension));
                cmd.Parameter(item);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Insert));
            }

            base.DoUpdate(EventArgs.Empty);
        }

        public override void Delete(int id)
        {
            base.Delete(id);

            using (DbCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = File.ReadAllText(Path.Combine(this.Storage.ToString(), nameof(Delete) + sqlFileExtension));
                cmd.Parameter(id);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Delete));
            }

            base.DoUpdate(EventArgs.Empty);
        }

        public override void Update(int id, IBook item)
        {
            base.Update(id, item);

            using (DbCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = File.ReadAllText(Path.Combine(this.Storage.ToString(), nameof(Update) + sqlFileExtension));
                cmd.Parameter(item);

                if (cmd.ExecuteNonQuery() != 1)
                    throw new MissingFieldException(nameof(Update));
            }

            base.DoUpdate(EventArgs.Empty);
        }

        public override List<IBook> Get()
        {
            List<IBook> books = new();

            using (DbCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandText = File.ReadAllText(Path.Combine(this.Storage.ToString(), nameof(Get) + sqlFileExtension));

                using (DbDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            // SQLite uses Int64 for id so it needs to be converted cause in our example there are never more than 2^32 books...
                            Id = int.Parse(reader[nameof(IBook.Id)].ToString()),
                            ISBN = reader[nameof(IBook.ISBN)].ToString(),
                            Title = reader[nameof(IBook.Title)].ToString(),
                            Author = reader[nameof(IBook.Author)].ToString()
                        });
                    }
                }
            }
            return books;
        }

        public void Close() => this.Connection?.Close();

        public void Dispose() => this?.Close();

    }
}
