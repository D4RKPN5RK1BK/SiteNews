using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteNews.FilterModels;
using SiteNews.sakila;
using SiteNews.SortModels;
using SiteNews.ViewModels;

namespace SiteNews.Controllers
{
    public class NewsController : Controller
    {
        private goreftinskyContext _context;
        public NewsController(goreftinskyContext context) : base()
        {
            _context = context;
        }

        // GET: NewsController
        public ActionResult Index()
        {
            var model = new NewsViewModel();
            model.Filter = new NewsFilterModel();
            model.Sort = new NewsSortModel();
            model.Elements = new List<News>();

            model.Elements = _context.News.Where(model.Filter.FilterPredicate).Skip(0).Take(20).ToList();
            return View(model);
        }

        // GET: NewsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NewsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
