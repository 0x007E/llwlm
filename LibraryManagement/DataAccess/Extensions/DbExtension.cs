using LibraryManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.DataAccess.Extensions
{
    public static class DbExtension
    {
        public static void Parameter(this DbCommand cmd, int id)
        {
            cmd.SetupParameter(nameof(IBook.Id), DbType.Int32, id);
        }

        public static void Parameter(this DbCommand cmd, IBook book)
        {
            if(book.Id > 0)
                cmd.SetupParameter(nameof(IBook.Id), DbType.Int32, book.Id);

            cmd.SetupParameter(nameof(IBook.ISBN), DbType.String, book.ISBN);
            cmd.SetupParameter(nameof(IBook.Title), DbType.String, book.Title);
            cmd.SetupParameter(nameof(IBook.Author), DbType.String, book.Author);
        }

        private static DbCommand SetupParameter(this DbCommand cmd, string name, DbType type, object value)
        {
            DbParameter parameter = cmd.CreateParameter();
            parameter.ParameterName = name.ToUpper();
            parameter.DbType = type;
            parameter.Value = value;

            cmd.Parameters.Add(parameter);

            return cmd;
        }
    }
}
