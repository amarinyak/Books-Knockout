using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Books.WebApi.ViewModels;

namespace Books.WebApi.Code.Attributes
{
	public class CheckModelStateAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (actionContext.ModelState.IsValid) return;

			var modelStateErrorsViewModel = actionContext.ModelState.Keys.Select(key => new ModelStateErrorViewModel
			{
				FieldName = key,
				Errors = actionContext.ModelState[key].Errors.Select(p => p.ErrorMessage)
			});

			actionContext.Response = actionContext.Request.CreateResponse(
				HttpStatusCode.BadRequest,
				modelStateErrorsViewModel);
		}
	}
}
