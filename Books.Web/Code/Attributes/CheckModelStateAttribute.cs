using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Books.Web.Code.Attributes
{
	public class CheckModelStateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid) return;

			var errorList = actionContext.ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage);
			var errorListStr = string.Join(" ", errorList);

			actionContext.Response = actionContext.Request.CreateResponse(
				HttpStatusCode.BadRequest,
				new { Error = errorListStr }
			);
		}
	}
}