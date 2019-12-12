using System;
using System.Threading.Tasks;

namespace Books.BL.Interfaces.Services
{
	public interface IBookCreator
	{
		Task CreateDefaultBooks(Guid token);
	}
}
