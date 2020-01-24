using System;
using System.Collections.Generic;
using System.Data;
using Books.DAL.Models;

namespace Books.DAL.DataTables
{
    public static class AuthorCollectionDataTable
    {
        public static DataTable Init(IEnumerable<AuthorDb> authorsDb)
        {
            var dataTable = new DataTable("[dbo].[AuthorCollection]");

            dataTable.Columns.Add("[Id]", typeof(Guid));
            dataTable.Columns.Add("[BookId]", typeof(Guid));
            dataTable.Columns.Add("[FirstName]", typeof(string));
            dataTable.Columns.Add("[LastName]", typeof(string));

            foreach (var authorDb in authorsDb)
            {
                dataTable.Rows.Add(authorDb.Id, authorDb.BookId, authorDb.FirstName, authorDb.LastName);
            }

            return dataTable;
        }
    }
}
