using LibraryManagement.Core.Services;
using LibraryManagement.Domain;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Databases
{
    public class SQLiteDataService : DbDataService
    {
        public SQLiteDataService(string connectionString, string storage) : base(new SqliteConnection(connectionString), new DirectoryInfo(storage))
        {
        }
    }
}
