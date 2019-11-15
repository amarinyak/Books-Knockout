using System;
using System.Collections.Generic;
using System.Data;
using Books.DAL.Models;

namespace Books.DAL.DataTables
{
	public static class AuthorCollectionDataTable
	{
		public static DataTable Init(IEnumerable<AuthorDb> values)
		{
			var dataTable = new DataTable("[dbo].[AuthorCollection]");

			dataTable.Columns.Add("[Id]", typeof(Guid));
			dataTable.Columns.Add("[BookId]", typeof(Guid));
			dataTable.Columns.Add("[FirstName]", typeof(string));
			dataTable.Columns.Add("[LastName]", typeof(string));

			foreach (var value in values)
			{
				dataTable.Rows.Add(value.Id, value.BookId, value.FirstName, value.LastName);
			}

			return dataTable;
		}
	}
}
