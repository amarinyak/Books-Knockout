using System.Web.Mvc;
using Books.Web.ViewModels;

namespace Books.Web.Controllers
{
    public class HomeController : Controller
    {
		public ActionResult Index()
		{
			var model = new HomeViewModel
			{
				AppConfig = AppConfigViewModel.Create()
			};

	        return View(model);
        }
    }
}
