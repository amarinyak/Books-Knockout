using System;
using System.Web.Http;
using Books.BL.Interfaces.Services;

namespace Books.WebApi.Controllers
{
    public class BaseController : ApiController
    {
        private readonly ITokenProvider _tokenProvider;

        public BaseController(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        protected Guid Token => _tokenProvider.GetToken(Request);
    }
}
