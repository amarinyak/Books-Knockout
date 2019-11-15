namespace Books.Web.Interfaces.Mappers
{
	public interface IIsbnMapper
	{
		string ToString(long isbnNumber);

		long ToNumber(string isbnString);
	}
}
