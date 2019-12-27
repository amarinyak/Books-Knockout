using System.Web.Mvc;
using Books.WebApp.Interfaces.Builders;

namespace Books.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeViewModelBuilder _homeViewModelBuilder;

        public HomeController(IHomeViewModelBuilder homeViewModelBuilder)
        {
            _homeViewModelBuilder = homeViewModelBuilder;
        }

        public ActionResult Index()
        {
            var model = _homeViewModelBuilder.Build();

            return View(model);
        }
    }
}
