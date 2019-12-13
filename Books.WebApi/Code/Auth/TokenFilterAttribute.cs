using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Autofac;
using Books.BL.Interfaces.Services;
using Books.WebApi.DiConfiguration;

namespace Books.WebApi.Code.Auth
{
	public class TokenFilterAttribute: AuthorizationFilterAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			var tokenProvider = DiConfig.Container.Resolve<ITokenProvider>();
			
			if (IsAllowedAnonymous(actionContext.ActionDescriptor))
			{
				return;
			}
			
			var authorization = actionContext.Request.Headers.Authorization;

			if (IsAuthorized(authorization, out var token))
			{
				tokenProvider.SetToken(actionContext.Request, token);
			}
			else
			{
				actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
			}
		} 

		private static bool IsAuthorized(AuthenticationHeaderValue value, out Guid token)
		{
			token = Guid.Empty;

			return value != null
			       && value.Scheme == "Basic"
			       && Guid.TryParse(value.Parameter, out token);
		}

		private static bool IsAllowedAnonymous(HttpActionDescriptor actionDescriptor)
		{
			return actionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any()
			       || actionDescriptor.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>(true).Any();
		}
	}
}
