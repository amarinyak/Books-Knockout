using System;
using System.Threading.Tasks;
using System.Web.Http;
using Books.BL.Interfaces.Services;

namespace Books.WebApi.Controllers.v1
{
    [AllowAnonymous]
    [RoutePrefix("v1/auth")]
    public class AuthController : ApiController
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IBookCreator _bookCreator;

        public AuthController(ITokenProvider tokenProvider, IBookCreator bookCreator)
        {
            _tokenProvider = tokenProvider;
            _bookCreator = bookCreator;
        }

        /// <summary>
        /// Get auth token
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("token")]
        public async Task<Guid> GetToken()
        {
            var token = _tokenProvider.Create();

            await _bookCreator.CreateDefaultBooks(token);

            return token;
        }
    }
}
