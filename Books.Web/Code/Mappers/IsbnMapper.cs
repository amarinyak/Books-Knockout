using System.Text.RegularExpressions;
using Books.Web.Interfaces.Mappers;

namespace Books.Web.Code.Mappers
{
	public class IsbnMapper : IIsbnMapper
	{
		public string ToString(long isbnNumber)
		{
			return isbnNumber.ToString("###-##########");
		}

		public long ToNumber(string isbnString)
		{
			return long.Parse(Regex.Replace(isbnString, @"\D", string.Empty));
		}
	}
}