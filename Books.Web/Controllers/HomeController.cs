using System.Web.Mvc;
using Books.Web.ViewModels;

namespace Books.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string sortField = "title", bool descSort = false)
        {
            var model = new HomeViewModel
            {
                Sort = new SortViewModel
                {
                    SortField = sortField,
                    DescSort = descSort
                }
            };

            return View(model);
        }
    }
}