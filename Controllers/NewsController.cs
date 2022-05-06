using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SiteNews.DisplayModels;
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
        public ActionResult Index(int page = 1)
        {
            NewsViewModel model = new NewsViewModel() {
              Filter = new NewsFilterModel(),
              Sort = new NewsSortModel(),
              Display = new PageModel(_context.News.Count(), page),
              Elements = new List<News>()
            };

            model.Elements = _context.News
                .Where(model.Filter.FilterPredicate)
                .OrderByDescending(o => o.IdNews)
                .Skip(model.Display.SkipTo())
                .Take(model.Display.PageSize)
                .ToList();

            return View(model);
        }

        // GET: NewsController/Details/5
        public ActionResult Read(int id)
        {
            var model = _context.News.First(o => o.IdNews == id);
            return View(model);
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
        public ActionResult Update(int id)
        {
            var model = _context.News.First(o => o.IdNews == id);
            return View(model);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(int id, IFormCollection collection)
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
