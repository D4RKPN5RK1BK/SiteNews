using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            SelectList model = new SelectList(_context.NewsCategories, "NewsCategoryId", "NewsCategoryName", _context.NewsCategories.First().NewsCategoryId);
            return View(model);
        }

        // POST: NewsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(News model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: NewsController/Edit/5
        public ActionResult Update(int id)
        {
            var model = _context.News.First(o => o.IdNews == id);
            ViewBag.Categories = new SelectList(_context.NewsCategories, "NewsCategoryId", "NewsCategoryName", _context.NewsCategories.First().NewsCategoryId);
            return View(model);
        }

        // POST: NewsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(News model)
        {
            model.Public = 1;
            _context.Update(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: NewsController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _context.News.First(o=> o.IdNews == id);
            return View(model);
        }

        // POST: NewsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(News model)
        {
            _context.News.Remove(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Confirm(int id) {
             if (_context.News.Any(o => o.IdNews == id)) {
                ConfirmViewModel model = new ConfirmViewModel();
                model.News = _context.News.First(o => o.IdNews == id);
                return View(model);
            }
            
            return NotFound();
        }

        [HttpPost]
        public IActionResult Confirm(ConfirmForm model) {
            if (_context.News.Any(o => o.IdNews == model.Id)) {
                News news = _context.News.First(o => o.IdNews == model.State);
            }
            
            return RedirectToAction("Index");

        }
    }
}
