using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace Books.Web.Attributes
{
    public class HandleApiErrorAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = context.Request.CreateResponse(
                HttpStatusCode.InternalServerError,
                new { Error = context.Exception.Message }
            );
        }
    }
}