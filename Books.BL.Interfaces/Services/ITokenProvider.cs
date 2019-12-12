using System;
using System.Net.Http;

namespace Books.BL.Interfaces.Services
{
	public interface ITokenProvider
	{
		Guid Create();

		void SetToken(HttpRequestMessage httpRequestMessage, Guid value);

		Guid GetToken(HttpRequestMessage httpRequestMessage);
	}
}
