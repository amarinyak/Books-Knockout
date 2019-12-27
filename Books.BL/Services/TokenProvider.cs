using System;
using System.Net.Http;
using Books.BL.Interfaces.Services;

namespace Books.BL.Services
{
    public class TokenProvider : ITokenProvider
    {
        private readonly string _authTokenKey;

        public TokenProvider(string authTokenKey)
        {
            _authTokenKey = authTokenKey;
        }

        public Guid Create()
        {
            return Guid.NewGuid();
        }

        public void SetToken(HttpRequestMessage httpRequestMessage, Guid value)
        {
            httpRequestMessage.Properties.Add(_authTokenKey, value);
        }

        public Guid GetToken(HttpRequestMessage httpRequestMessage)
        {
            var token = httpRequestMessage.Properties[_authTokenKey];

            return (Guid)token;
        }
    }
}
