using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteNews.Controllers
{
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
