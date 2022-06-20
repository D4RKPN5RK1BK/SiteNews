using Microsoft.AspNetCore.Mvc;
using SiteNews.sakila;

namespace SiteNews.Controllers
{
    public class CategoryController : Controller
    {
        private readonly goreftinskyContext _context;
        public CategoryController(goreftinskyContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<NewsCategory> model = _context.NewsCategories;
            return View(model);
        }

        [HttpGet]
        public IActionResult Read(int id)
        {
            NewsCategory model = _context.NewsCategories.First(o => o.NewsCategoryId == id);
            return PartialView(model);
        }

        [HttpPost]
        public IActionResult Create(NewsCategory model)
        {
            if(ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges(); 
            }
            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult Edit(int id )
        {
            NewsCategory model = _context.NewsCategories.First(o => o.NewsCategoryId == id);
            return PartialView(model);
        }

        [HttpPut]
        public IActionResult Edit(NewsCategory model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                _context.SaveChanges();
            }
            return PartialView();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            if (_context.NewsCategories.Any(o => o.NewsCategoryId == id))
            {
                _context.NewsCategories.Remove(_context.NewsCategories.First(o => o.NewsCategoryId == id));
            }

            Ok();
        }

    }
}
